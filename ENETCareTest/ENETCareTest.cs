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

		[TestInitialize]
		public void Setup()
		{
			dc = new DistributionCentre();
			employee = new Employee();
			employee.role = Role.Doctor;
			employee.fullname = "StarCraft";
			employee.email = "StarCraft@blizzard.com";
			employee.distributionCentre = dc;
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
