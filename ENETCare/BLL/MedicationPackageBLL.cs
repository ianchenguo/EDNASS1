﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace ENETCare.Business
{
	public class MedicationPackageBLL
	{
		#region Properties

		string username;
		Employee user;
		public Employee User
		{
			get
			{
				if (user == null)
				{
					user = GetEmployeeByUserName(username);
				}
				return user;
			}
		}
		public MedicationPackageDAO MedicationPackageDAO { get; set; }
		public MedicationTypeDAO MedicationTypeDAO { get; set; }
		public DistributionCentreDAO DistributionCentreDAO { get; set; }
		public EmployeeDAO EmployeeDAO { get; set; }

		#endregion

		#region Constructor

		public MedicationPackageBLL(string username)
		{
			this.username = username;
			MedicationPackageDAO = DAOFactory.GetMedicationPackageDAO();
			MedicationTypeDAO = DAOFactory.GetMedicationTypeDAO();
			DistributionCentreDAO = DAOFactory.GetDistributionCentreDAO();
			EmployeeDAO = DAOFactory.GetEmployeeDAO();
		}

		#endregion

		#region Employee

		Employee GetEmployeeByUserName(string username)
		{
			Employee employee = EmployeeDAO.GetEmployeeByUserName(username);
			if (employee == null)
			{
				throw new ENETCareException(string.Format("{0}: {1}", Properties.Resources.InvalidUser, username));
			}
			return employee;
		}

		#endregion

		#region Scan

		public MedicationPackage ScanPackage(string barcode)
		{
			return MedicationPackageDAO.FindPackageByBarcode(barcode);
		}

		#endregion

		#region Register

		public string RegisterPackage(int medicationTypeId, string expireDate, string barcode = "")
		{
			DateTime parsedExpireDate;
			if (!DateTime.TryParse(expireDate, out parsedExpireDate))
			{
				throw new ENETCareException(Properties.Resources.InvalidDateFormat);
			}
			MedicationType medicationType = MedicationTypeDAO.GetMedicationTypeById(medicationTypeId);
			if (medicationType == null)
			{
				throw new ENETCareException(Properties.Resources.MedicationTypeNotFound);
			}
			return RegisterPackage(medicationType, parsedExpireDate, barcode);
		}

		string RegisterPackage(MedicationType medicationType, DateTime expireDate, string barcode)
		{
			MedicationPackage package = new MedicationPackage();
			if (string.IsNullOrEmpty(barcode))
			{
				barcode = BarcodeHelper.GenerateBarcode();
			}
			package.Barcode = barcode;
			package.Type = medicationType;
			package.ExpireDate = expireDate;
			package.Status = PackageStatus.InStock;
			package.StockDC = User.DistributionCentre;
			package.Operator = User.Username;
			MedicationPackageDAO.InsertPackage(package);
			return barcode;
		}

		#endregion

		#region Send

		public void SendPackage(string barcode, int distributionCentreId, bool isTrusted = true)
		{
			DistributionCentre distributionCentre = DistributionCentreDAO.GetDistributionCentreById(distributionCentreId);
			if (distributionCentre == null)
			{
				throw new ENETCareException(Properties.Resources.DistributionCentreNotFound);
			}
			SendPackage(barcode, distributionCentre, isTrusted);
		}

		void SendPackage(string barcode, DistributionCentre destination, bool isTrusted)
		{
			MedicationPackage package = ScanPackage(barcode);
			if (package == null)
			{
				throw new ENETCareException(Properties.Resources.MedicationPackageNotFound);
			}
			if (User.DistributionCentre.ID == destination.ID)
			{
				throw new ENETCareException(Properties.Resources.AnotherDistributionCentre);
			}
			if (!isTrusted)
			{
				if (package.Status != PackageStatus.InStock)
				{
					throw new ENETCareException(Properties.Resources.IncorrectPackageStatus);
				}
				if (package.StockDC == null || package.StockDC.ID != User.DistributionCentre.ID)
				{
					throw new ENETCareException(Properties.Resources.IncorrectDistributionCentreStock);
				}
			}
			package.Status = PackageStatus.InTransit;
			package.StockDC = null;
			package.SourceDC = User.DistributionCentre;
			package.DestinationDC = destination;
			package.Operator = User.Username;
			MedicationPackageDAO.UpdatePackage(package);
		}

		#endregion

		#region Receive

		public void ReceivePackage(string barcode, bool isTrusted = true)
		{
			MedicationPackage package = ScanPackage(barcode);
			if (package == null)
			{
				throw new ENETCareException(Properties.Resources.MedicationPackageNotFound);
			}
			if (!isTrusted)
			{
				if (package.Status != PackageStatus.InTransit)
				{
					throw new ENETCareException(Properties.Resources.IncorrectPackageStatus);
				}
				if (package.DestinationDC == null || package.DestinationDC.ID != User.DistributionCentre.ID)
				{
					throw new ENETCareException(Properties.Resources.IncorrectDistributionCentreDestination);
				}
			}
			package.Status = PackageStatus.InStock;
			package.StockDC = User.DistributionCentre;
			package.SourceDC = null;
			package.DestinationDC = null;
			package.Operator = User.Username;
			MedicationPackageDAO.UpdatePackage(package);
		}

		#endregion

		#region Distribute

		public void DistributePackage(string barcode, bool isTrusted = true)
		{
			MedicationPackage package = ScanPackage(barcode);
			if (package == null)
			{
				throw new ENETCareException(Properties.Resources.MedicationPackageNotFound);
			}
			if (!isTrusted)
			{
				if (package.Status != PackageStatus.InStock)
				{
					throw new ENETCareException(Properties.Resources.IncorrectPackageStatus);
				}
				if (package.StockDC == null || package.StockDC.ID != User.DistributionCentre.ID)
				{
					throw new ENETCareException(Properties.Resources.IncorrectDistributionCentreStock);
				}
			}
			package.Status = PackageStatus.Distributed;
			package.StockDC = User.DistributionCentre;
			package.SourceDC = null;
			package.DestinationDC = null;
			package.Operator = User.Username;
			MedicationPackageDAO.UpdatePackage(package);
		}

		#endregion

		#region Discard

		public void DiscardPackage(string barcode, bool isTrusted = true)
		{
			MedicationPackage package = ScanPackage(barcode);
			if (package == null)
			{
				throw new ENETCareException(Properties.Resources.MedicationPackageNotFound);
			}
			if (!isTrusted)
			{
				if (package.Status != PackageStatus.InStock)
				{
					throw new ENETCareException(Properties.Resources.IncorrectPackageStatus);
				}
				if (package.StockDC == null || package.StockDC.ID != User.DistributionCentre.ID)
				{
					throw new ENETCareException(Properties.Resources.IncorrectDistributionCentreStock);
				}
			}
			package.Status = PackageStatus.Discarded;
			package.StockDC = User.DistributionCentre;
			package.SourceDC = null;
			package.DestinationDC = null;
			package.Operator = User.Username;
			MedicationPackageDAO.UpdatePackage(package);
		}

		#endregion

		#region Stocktake

		public List<StocktakingViewData> Stocktake()
		{
			List<MedicationPackage> packages = MedicationPackageDAO.FindInStockPackagesInDistributionCentre(User.DistributionCentre.ID);
			List<StocktakingViewData> list = new List<StocktakingViewData>();
			const int warningDays = 7;
			foreach (MedicationPackage package in packages)
			{
				ExpireStatus expireStatus = ExpireStatus.NotExpired;
				if (TimeProvider.Current.Now > package.ExpireDate)
				{
					expireStatus = ExpireStatus.Expired;
				}
				else if (TimeProvider.Current.Now.AddDays(warningDays) > package.ExpireDate)
				{
					expireStatus = ExpireStatus.AboutToExpired;
				}
				var row = new StocktakingViewData
				{
					Barcode = package.Barcode,
					Type = package.Type.Name,
					ExpireDate = package.ExpireDate.ToString("d", new CultureInfo("en-au")),
					ExpireStatus = expireStatus
				};
				list.Add(row);
			}
			return list;
		}

		#endregion

		#region Audit

		public void CheckAndUpdatePackage(int medicationTypeId, string barcode)
		{
			MedicationPackage package = MedicationPackageDAO.FindPackageByBarcode(barcode);
			if (package == null)
			{
				MedicationType medicationType = MedicationTypeDAO.GetMedicationTypeById(medicationTypeId);
				DateTime expireDate = DateTime.Today.AddDays(medicationType.ShelfLife);
				RegisterPackage(medicationType, expireDate, barcode);
			}
			else if (package.Type.ID != medicationTypeId)
			{
				throw new ENETCareException(Properties.Resources.MedicationTypeNotMatched);
			}
			else if (package.Status != PackageStatus.InStock || package.StockDC.ID != User.DistributionCentre.ID)
			{
				package.Status = PackageStatus.InStock;
				package.StockDC = User.DistributionCentre;
				package.SourceDC = null;
				package.DestinationDC = null;
				package.Operator = User.Username;
				MedicationPackageDAO.UpdatePackage(package);
			}
		}

		public List<MedicationPackage> AuditPackages(int medicationTypeId, List<string> scannedList)
		{
			List<MedicationPackage> lostPackages = new List<MedicationPackage>();
			List<MedicationPackage> inStockList = GetInStockList(medicationTypeId);
			foreach (MedicationPackage package in inStockList)
			{
				if (!scannedList.Contains(package.Barcode))
				{
					package.Status = PackageStatus.Lost;
					package.Operator = User.Username;
					lostPackages.Add(package);
					MedicationPackageDAO.UpdatePackage(package);
				}
			}
			return lostPackages;
		}

		public List<MedicationPackage> GetInStockList(int medicationTypeId)
		{
			return MedicationPackageDAO.FindInStockPackagesInDistributionCentre(User.DistributionCentre.ID, medicationTypeId);
		}

		#endregion
	}
}
