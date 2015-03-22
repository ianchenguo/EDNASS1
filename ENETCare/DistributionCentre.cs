using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class DistributionCentre
	{
		#region Properties

		public int ID { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }

		public List<MedicationPackage> packages = new List<MedicationPackage>();

		#endregion

		#region Register

		public void RegisterPackage(string type, DateTime expireDate)
		{
			MedicationPackage package = new MedicationPackage();
			string barcode = MedicationPackage.GenerateBarcode();
			package.Barcode = barcode;
			package.Type = SimDB.GetMedicationTypeByID(type);
			package.ExpireDate = expireDate;
			package.Status = PackageStatus.InStock;
			package.StockDC = this;
			SimDB.InsertPackage(package);
			//packages.Add(package);
		}

		#endregion

		#region Send

		public void SendPackage(string barcode, string distributionCentreID)
		{
			DistributionCentre distributionCentre = SimDB.GetDistributionCentreByID(distributionCentreID);
			SendPackage(barcode, distributionCentre);
		}

		public void SendPackage(string barcode, DistributionCentre destination)
		{
			MedicationPackage package = ScanPackage(barcode);
			package.Status = PackageStatus.InTransit;
			package.StockDC = null;
			package.SourceDC = this;
			package.DestinationDC = destination;
			SimDB.UpdatePackage(package);
		}

		#endregion

		#region Receive

		public void ReceivePackage(string barcode)
		{
			MedicationPackage package = ScanPackage(barcode);
			package.Status = PackageStatus.InStock;
			package.StockDC = this;
			package.SourceDC = null;
			package.DestinationDC = null;
			SimDB.UpdatePackage(package);
		}

		#endregion

		#region Distribute

		public void DistributePackage(string barcode)
		{
			MedicationPackage package = ScanPackage(barcode);
			package.Status = PackageStatus.Distributed;
			SimDB.UpdatePackage(package);
		}

		#endregion

		#region Discard

		public void DiscardPackage(string barcode)
		{
			MedicationPackage package = ScanPackage(barcode);
			package.Status = PackageStatus.Discarded;
			SimDB.UpdatePackage(package);
		}

		#endregion

		#region Audit

		public MedicationPackage ScanPackage(string barcode)
		{
			MedicationPackage package = SimDB.FindPackageByBarcode(barcode);
			return package;
		}

		public void RemoveLostPackages(List<MedicationPackage> inStockList, List<MedicationPackage> scannedList)
		{

		}

		public void UpdateFoundPackages(List<MedicationPackage> inStockList, List<MedicationPackage> scannedList)
		{

		}

		#endregion
	}
}
