using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare;

namespace ENETCareTest
{
	[TestClass]
	public class ENETCareTest
	{
		DistributionCentre dc;
		Employee employee;
        MedicationPackage package;

		[TestInitialize]
		public void Setup()
		{
			dc = new DistributionCentre();
            package = new MedicationPackage();

			employee = new Employee();
			employee.role = Role.Doctor;
			employee.fullname = "StarCraft";
			employee.email = "StarCraft@blizzard.com";
			employee.distributionCentre = dc;
		}

        [TestMethod]
        public void MedicationPackage_barcode_canBeStored()
        {
            string barcode = "mock barcode";
            package.barcode = barcode;
            Assert.AreEqual(package.barcode,barcode);
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

		[TestMethod]
		public void Employee_UpdateProfile()
		{
			Assert.AreEqual("StarCraft", employee.fullname);
			Assert.AreEqual("StarCraft@blizzard.com", employee.email);
			string newName = "WarCraft";
			string newEmail = "WarCraft@blizzard.com";
			employee.UpdateProfile(newName, newEmail);
			Assert.AreEqual("WarCraft", employee.fullname);
			Assert.AreEqual("WarCraft@blizzard.com", employee.email);
		}

		[TestMethod]
		public void Employee_CheckPackage()
		{
			bool result;
			string validBarcode = "000000";
			result = employee.CheckPackage(validBarcode);
			Assert.AreEqual(true, result);
			string invalidBarcode = "111111";
			result = employee.CheckPackage(invalidBarcode);
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void Employee_RegisterPackage()
		{
			Assert.AreEqual(0, dc.packages.Count);
			MedicationPackage package = new MedicationPackage();
			employee.RegisterPackage(package);
			Assert.AreEqual(1, dc.packages.Count);
		}

		[TestMethod]
		public void Employee_SendPackage()
		{
			MedicationPackage package = new MedicationPackage();
			employee.SendPackage(package, new DistributionCentre());
			Assert.AreEqual(PackageStatus.InTransit, package.status);
		}

		[TestMethod]
		public void Employee_ReceivePackage()
		{
			Assert.AreEqual(0, dc.packages.Count);
			MedicationPackage package = new MedicationPackage();
			package.status = PackageStatus.InTransit;
			employee.ReceivePackage(package);
			Assert.AreEqual(1, dc.packages.Count);
			Assert.AreEqual(PackageStatus.InStock, package.status);
		}
	}
}
