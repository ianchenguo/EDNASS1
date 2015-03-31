using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;

namespace ENETCareTest
{
	[TestClass]
	public class MedicationPackageTest
	{
		DistributionCentre dc;
		MedicationPackage package;

		[TestInitialize]
		public void Setup()
		{
			dc = new DistributionCentre();
			package = new MedicationPackage();
		}

		[TestMethod]
		public void MedicationPackage_barcode_canBeStored()
		{
			string barcode = "mock barcode";
			package.Barcode = barcode;
			Assert.AreEqual(package.Barcode, barcode);
		}

		[TestMethod]
		public void MedicationPackage_medicationType_canBeAssociated()
		{
			MedicationType medType = new MedicationType();
			package.Type = medType;
			Assert.AreEqual(package.Type, medType);
		}

		[TestMethod]
		public void MedicationPackage_expireDate_canBeStored()
		{
			DateTime expireDate = new DateTime();
			package.ExpireDate = expireDate;
			Assert.AreEqual(package.ExpireDate, expireDate);
		}

		[TestMethod]
		public void MedicationPackage_packageStatus_canBeStored()
		{
			PackageStatus packageStatus = PackageStatus.InStock;
			package.Status = packageStatus;
			Assert.AreEqual(package.Status, packageStatus);
		}

		[TestMethod]
		public void MedicationPackage_stockDC_canBeStored()
		{
			package.StockDC = dc;
			Assert.AreEqual(package.StockDC, dc);
		}

		[TestMethod]
		public void MedicationPackage_sourceDC_canBeStored()
		{
			package.SourceDC = dc;
			Assert.AreEqual(package.SourceDC, dc);
		}

		[TestMethod]
		public void MedicationPackage_destinationDC_canBeStored()
		{
			package.DestinationDC = dc;
			Assert.AreEqual(package.DestinationDC, dc);
		}

		[TestMethod]
		public void MedicationPackage_updateTime_canBeStored()
		{
			DateTime updateTime = new DateTime();
			package.UpdateTime = updateTime;
			Assert.AreEqual(package.UpdateTime, updateTime);
		}
	}
}
