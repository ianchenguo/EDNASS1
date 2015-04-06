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

		public void RegisterPackage(int medicationTypeId, string expireDate)
		{
			DateTime parsedExpireDate;
			if (!DateTime.TryParse(expireDate, out parsedExpireDate))
			{
				throw new Exception("Invalid date format");
			}
			MedicationType medicationType = MedicationTypeDAO.GetMedicationTypeByID(medicationTypeId);
			if (medicationType == null)
			{
				throw new Exception("Invalid medication type");
			}
			RegisterPackage(medicationType, parsedExpireDate);
		}

		void RegisterPackage(MedicationType medicationType, DateTime expireDate)
		{
			MedicationPackage package = new MedicationPackage();
			package.Barcode = BarcodeHelper.GenerateBarcode();
			package.Type = medicationType;
			package.ExpireDate = expireDate;
			package.Status = PackageStatus.InStock;
			package.StockDC = User.DistributionCentre;
			MedicationPackageDAO.InsertPackage(package);
		}

		#endregion

		#region Send

		public void SendPackage(string barcode, int distributionCentreId)
		{
			DistributionCentre distributionCentre = DistributionCentreDAO.GetDistributionCentreByID(distributionCentreId);
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

		#region Audit

		public void RemoveLostPackages(List<MedicationPackage> inStockList, List<MedicationPackage> scannedList)
		{
			throw new System.NotImplementedException();
		}

		public void UpdateFoundPackages(List<MedicationPackage> inStockList, List<MedicationPackage> scannedList)
		{
			throw new System.NotImplementedException();
		}

		#endregion
	}
}
