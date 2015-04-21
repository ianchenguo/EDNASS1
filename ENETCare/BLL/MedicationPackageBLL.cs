﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class MedicationPackageBLL
	{
		#region Constructor

		Employee User { get; set; }

		public MedicationPackageBLL(string username)
		{
			User = EmployeeDAO.GetEmployeeByUserName(username);
			if (User == null)
			{
				throw new ENETCareException("Invalid current user: " + username);
			}
		}

		#endregion

		#region Properties

		MedicationPackageDAO MedicationPackageDAO
		{
			get { return DAOFactory.GetMedicationPackageDAO(); }
		}

		MedicationTypeDAO MedicationTypeDAO
		{
			get { return DAOFactory.GetMedicationTypeDAO(); }
		}

		DistributionCentreDAO DistributionCentreDAO
		{
			get { return DAOFactory.GetDistributionCentreDAO(); }
		}

		EmployeeDAO EmployeeDAO
		{
			get { return DAOFactory.GetEmployeeDAO(); }
		}

		#endregion

		#region Scan

		public MedicationPackage ScanPackage(string barcode)
		{
			return MedicationPackageDAO.FindPackageByBarcode(barcode);
		}

		#endregion

		#region Register

		public string RegisterPackage(int medicationTypeId, string expireDate)
		{
			DateTime parsedExpireDate;
			if (!DateTime.TryParse(expireDate, out parsedExpireDate))
			{
				throw new ENETCareException("Invalid date format");
			}
			MedicationType medicationType = MedicationTypeDAO.GetMedicationTypeById(medicationTypeId);
			if (medicationType == null)
			{
				throw new ENETCareException("Invalid medication type");
			}
			return RegisterPackage(medicationType, parsedExpireDate);
		}

		string RegisterPackage(MedicationType medicationType, DateTime expireDate)
		{
			MedicationPackage package = new MedicationPackage();
			string barcode = BarcodeHelper.GenerateBarcode();
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
				throw new ENETCareException("Distribution Centre not found");
			}
			SendPackage(barcode, distributionCentre, isTrusted);
		}

		void SendPackage(string barcode, DistributionCentre destination, bool isTrusted)
		{
			MedicationPackage package = ScanPackage(barcode);
			if (package == null)
			{
				throw new ENETCareException("Package not found");
			}
			if (package.StockDC != null && package.StockDC.ID == destination.ID)
			{
				throw new ENETCareException("Choose a different distribution centre.");
			}
			if (!isTrusted)
			{
				if (package.Status != PackageStatus.InStock)
				{
					throw new ENETCareException("Package status is not in stock");
				}
				if (package.StockDC == null || package.StockDC.ID != User.DistributionCentre.ID)
				{
					throw new ENETCareException("Package not in distribution centre");
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
				throw new ENETCareException("Package not found");
			}
			if (!isTrusted)
			{
				if (package.Status != PackageStatus.InTransit)
				{
					throw new ENETCareException("Package not in transit");
				}
				if (package.DestinationDC == null || package.DestinationDC.ID != User.DistributionCentre.ID)
				{
					throw new ENETCareException("Package not to distribution centre");
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
				throw new ENETCareException("Package not found");
			}
			if (!isTrusted)
			{
				if (package.Status != PackageStatus.InStock)
				{
					throw new ENETCareException("Package not in stock");
				}
				if (package.StockDC == null || package.StockDC.ID != User.DistributionCentre.ID)
				{
					throw new ENETCareException("Package not in distribution centre");
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
				throw new ENETCareException("Package not found");
			}
			if (!isTrusted)
			{
				if (package.Status != PackageStatus.InStock)
				{
					throw new ENETCareException("Package not in stock");
				}
				if (package.StockDC == null || package.StockDC.ID != User.DistributionCentre.ID)
				{
					throw new ENETCareException("Package not in distribution centre");
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
				if (DateTime.Now > package.ExpireDate)
				{
					expireStatus = ExpireStatus.Expired;
				}
				else if (DateTime.Now.AddDays(warningDays) > package.ExpireDate)
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
				RegisterPackage(medicationType, expireDate);
			}
			else if (package.Type.ID != medicationTypeId)
			{
				throw new ENETCareException("Package type not matched");
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

		public void AuditPackages(int medicationTypeId, List<int> scannedList)
		{
			List<MedicationPackage> inStockList = GetInStockList(medicationTypeId);
			foreach (MedicationPackage package in inStockList)
			{
				if (!scannedList.Contains(package.ID))
				{
					package.Status = PackageStatus.Lost;
					MedicationPackageDAO.UpdatePackage(package);
				}
			}
		}

		public List<MedicationPackage> GetInStockList(int medicationTypeId)
		{
			return MedicationPackageDAO.FindInStockPackagesInDistributionCentre(User.DistributionCentre.ID, medicationTypeId);
		}

		#endregion
	}
}
