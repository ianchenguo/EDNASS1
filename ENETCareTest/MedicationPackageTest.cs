using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare;

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
			package.barcode = barcode;
			Assert.AreEqual(package.barcode, barcode);
		}

		[TestMethod]
		public void MedicationPackage_medicationType_canBeAssociated()
		{
			MedicationType medType = new MedicationType();
			package.type = medType;
			Assert.AreEqual(package.type, medType);
		}

		[TestMethod]
		public void MedicationPackage_expireDate_canBeStored()
		{
			DateTime expireDate = new DateTime();
			package.expireDate = expireDate;
			Assert.AreEqual(package.expireDate, expireDate);
		}

		[TestMethod]
		public void MedicationPackage_packageStatus_canBeStored()
		{
			PackageStatus packageStatus = PackageStatus.InStock;
			package.status = packageStatus;
			Assert.AreEqual(package.status, packageStatus);
		}

		[TestMethod]
		public void MedicationPackage_stockDC_canBeStored()
		{
			package.stockDC = dc;
			Assert.AreEqual(package.stockDC, dc);
		}

		[TestMethod]
		public void MedicationPackage_sourceDC_canBeStored()
		{
			package.sourceDC = dc;
			Assert.AreEqual(package.sourceDC, dc);
		}

		[TestMethod]
		public void MedicationPackage_destinationDC_canBeStored()
		{
			package.destinationDC = dc;
			Assert.AreEqual(package.destinationDC, dc);
		}

		[TestMethod]
		public void MedicationPackage_updateTime_canBeStored()
		{
			DateTime updateTime = new DateTime();
			package.updateTime = updateTime;
			Assert.AreEqual(package.updateTime, updateTime);
		}
	}
}
