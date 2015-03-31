using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class PackageBUS
	{
		#region Properties

		private PackageDAO packageDAO;
		PackageDAO PackageDAO
		{
			get
			{
				if (packageDAO == null)
				{
					packageDAO = new SQLServerPackageDAO();
				}
				return packageDAO;
			}
		}

		#endregion

		#region Scan

		public MedicationPackage ScanPackage(string barcode)
		{
			MedicationPackage package = SimDB.FindPackageByBarcode(barcode);
			return package;
		}

		#endregion

		#region Register

		public void RegisterPackage(string medicationType, string expireDate)
		{
			DateTime convertedDate;
			if (!DateTime.TryParse(expireDate, out convertedDate))
			{
				//convertedDate = SimDB.GetMedicationTypeByID(medicationType).DefaultExpireDate;
				throw new Exception("Invalid date format");
			}
			MedicationType convertedType;
			convertedType = SimDB.GetMedicationTypeByID(medicationType);
			if (convertedType == null)
			{
				throw new Exception("Invalid medication type");
			}
			RegisterPackage(convertedType, convertedDate);
		}

		void RegisterPackage(MedicationType medicationType, DateTime expireDate)
		{
			MedicationPackage package = new MedicationPackage();
			package.Barcode = BarcodeHelper.GenerateBarcode();
			package.Type = medicationType;
			package.ExpireDate = expireDate;
			package.Status = PackageStatus.InStock;
			package.StockDC = Employee.LoginUser().DistributionCentre;
			SimDB.InsertPackage(package);
		}

		#endregion

		#region Send

		public void SendPackage(string barcode, string distributionCentreID)
		{
			DistributionCentre distributionCentre = SimDB.GetDistributionCentreByID(distributionCentreID);
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
			if (package.StockDC == null || package.StockDC.ID != Employee.LoginUser().DistributionCentre.ID)
			{
				throw new Exception("Package not in distribution centre, the stockDC is: " + package.StockDC.Name);
			}
			if (package.StockDC.ID == destination.ID)
			{
				throw new Exception("Choose a different distribution centre.");
			}
			package.Status = PackageStatus.InTransit;
			package.StockDC = null;
			package.SourceDC = Employee.LoginUser().DistributionCentre;
			package.DestinationDC = destination;
			SimDB.UpdatePackage(package);
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
			if (package.DestinationDC == null || package.DestinationDC.ID != Employee.LoginUser().DistributionCentre.ID)
			{
				// disabled for test purpose
				//throw new Exception("Package not to distribution centre, the destinationDC is: " + package.DestinationDC.Name);
			}
			package.Status = PackageStatus.InStock;
			package.StockDC = Employee.LoginUser().DistributionCentre;
			package.SourceDC = null;
			package.DestinationDC = null;
			SimDB.UpdatePackage(package);
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
			if (package.StockDC == null || package.StockDC.ID != Employee.LoginUser().DistributionCentre.ID)
			{
				throw new Exception("Package not in distribution centre, the stockDC is: " + package.StockDC.Name);
			}
			package.Status = PackageStatus.Distributed;
			package.StockDC = Employee.LoginUser().DistributionCentre;
			package.SourceDC = null;
			package.DestinationDC = null;
			SimDB.UpdatePackage(package);
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
			if (package.StockDC == null || package.StockDC.ID != Employee.LoginUser().DistributionCentre.ID)
			{
				throw new Exception("Package not in distribution centre, the stockDC is: " + package.StockDC.Name);
			}
			package.Status = PackageStatus.Discarded;
			package.StockDC = Employee.LoginUser().DistributionCentre;
			package.SourceDC = null;
			package.DestinationDC = null;
			SimDB.UpdatePackage(package);
		}

		#endregion

		#region Audit

		public void RemoveLostPackages(List<MedicationPackage> inStockList, List<MedicationPackage> scannedList)
		{

		}

		public void UpdateFoundPackages(List<MedicationPackage> inStockList, List<MedicationPackage> scannedList)
		{

		}

		#endregion
	}
}
