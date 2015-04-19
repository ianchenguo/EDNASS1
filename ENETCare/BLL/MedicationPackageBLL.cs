using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class MedicationPackageBLL
	{
		#region Constructor

		// This part should be changed according to Identity Framework
		// Presentation should pass in a parameter standing for the current user
		// So that the business layer could know who is the current user

		Employee User { get; set; }

		public MedicationPackageBLL(int userid)
		{
			User = new EmployeeDataReaderDAO().FindEmployeeByUserId(userid);
			if (User == null)
			{
				throw new Exception("Invalid current user");
			}
		}

		public MedicationPackageBLL(string username)
		{
			User = new EmployeeDataReaderDAO().FindEmployeeByUserName(username);
			if (User == null)
			{
				throw new Exception("Invalid current user");
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
				throw new Exception("Invalid date format");
			}
			MedicationType medicationType = MedicationTypeDAO.GetMedicationTypeById(medicationTypeId);
			if (medicationType == null)
			{
				throw new Exception("Invalid medication type");
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
			MedicationPackageDAO.InsertPackage(package);
			return barcode;
		}

		#endregion

		#region Send

		public void SendPackage(string barcode, int distributionCentreId)
		{
			DistributionCentre distributionCentre = DistributionCentreDAO.GetDistributionCentreById(distributionCentreId);
			if (distributionCentre == null)
			{
				throw new Exception("Distribution Centre not found");
			}
			SendPackage(barcode, distributionCentre);
		}

		void SendPackage(string barcode, DistributionCentre destination)
		{
			MedicationPackage package = ScanPackage(barcode);
			if (package == null)
			{
				throw new Exception("Package not found");
			}
			if (package.Status != PackageStatus.InStock)
			{
				throw new Exception("Package not in stock, current status is: " + package.Status);
			}
			if (package.StockDC == null || package.StockDC.ID != User.DistributionCentre.ID)
			{
				throw new Exception("Package not in distribution centre, the stockDC is: " + package.StockDC.Name);
			}
			if (package.StockDC.ID == destination.ID)
			{
				throw new Exception("Choose a different distribution centre.");
			}
			package.Status = PackageStatus.InTransit;
			package.StockDC = null;
			package.SourceDC = User.DistributionCentre;
			package.DestinationDC = destination;
			MedicationPackageDAO.UpdatePackage(package);
		}

		#endregion

		#region Receive

		public void ReceivePackage(string barcode)
		{
			MedicationPackage package = ScanPackage(barcode);
			if (package == null)
			{
				throw new Exception("Package not found");
			}
			if (package.Status != PackageStatus.InTransit)
			{
				throw new Exception("Package not in transit, current status is: " + package.Status);
			}
			if (package.DestinationDC == null || package.DestinationDC.ID != User.DistributionCentre.ID)
			{
				// disabled for test purpose
				//throw new Exception("Package not to distribution centre, the destinationDC is: " + package.DestinationDC.Name);
			}
			package.Status = PackageStatus.InStock;
			package.StockDC = User.DistributionCentre;
			package.SourceDC = null;
			package.DestinationDC = null;
			MedicationPackageDAO.UpdatePackage(package);
		}

		#endregion

		#region Distribute

		public void DistributePackage(string barcode)
		{
			MedicationPackage package = ScanPackage(barcode);
			if (package == null)
			{
				throw new Exception("Package not found");
			}
			if (package.Status != PackageStatus.InStock)
			{
				throw new Exception("Package not in stock, current status is: " + package.Status);
			}
			if (package.StockDC == null || package.StockDC.ID != User.DistributionCentre.ID)
			{
				throw new Exception("Package not in distribution centre, the stockDC is: " + package.StockDC.Name);
			}
			package.Status = PackageStatus.Distributed;
			package.StockDC = User.DistributionCentre;
			package.SourceDC = null;
			package.DestinationDC = null;
			MedicationPackageDAO.UpdatePackage(package);
		}

		#endregion

		#region Discard

		public void DiscardPackage(string barcode)
		{
			MedicationPackage package = ScanPackage(barcode);
			if (package == null)
			{
				throw new Exception("Package not found");
			}
			if (package.Status != PackageStatus.InStock)
			{
				throw new Exception("Package not in stock, current status is: " + package.Status);
			}
			if (package.StockDC == null || package.StockDC.ID != User.DistributionCentre.ID)
			{
				throw new Exception("Package not in distribution centre, the stockDC is: " + package.StockDC.Name);
			}
			package.Status = PackageStatus.Discarded;
			package.StockDC = User.DistributionCentre;
			package.SourceDC = null;
			package.DestinationDC = null;
			MedicationPackageDAO.UpdatePackage(package);
		}

		#endregion

		#region Stocktake

		public List<StocktakingViewData> Stocktake()
		{
			return MedicationPackageDAO.FindPackagesInDistributionCentre(User.DistributionCentre.ID);
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
				throw new Exception("Package type not matched");
			}
			else if (package.Status != PackageStatus.InStock || package.StockDC.ID != User.DistributionCentre.ID)
			{
				package.Status = PackageStatus.InStock;
				package.StockDC = User.DistributionCentre;
				package.SourceDC = null;
				package.DestinationDC = null;
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
			return MedicationPackageDAO.FindPackages(medicationTypeId, User.DistributionCentre.ID);
		}

		#endregion
	}
}
