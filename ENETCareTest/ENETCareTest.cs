using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;

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
			employee.Role = Role.Doctor;
			employee.Fullname = "StarCraft";
			employee.Email = "StarCraft@blizzard.com";
			employee.DistributionCentre = dc;
		}

		[TestMethod]
		public void Employee_UpdateProfile()
		{
			Assert.AreEqual("StarCraft", employee.Fullname);
			Assert.AreEqual("StarCraft@blizzard.com", employee.Email);
			string newName = "WarCraft";
			string newEmail = "WarCraft@blizzard.com";
			string newDistributionCentre = "1";
			employee.UpdateProfile(newName, newEmail, newDistributionCentre);
			Assert.AreEqual("WarCraft", employee.Fullname);
			Assert.AreEqual("WarCraft@blizzard.com", employee.Email);
		}
		/*
		[TestMethod]
		public void Employee_CheckPackage()
		{
			MedicationPackage package;
			string validBarcode = "000000";
			package = SimDB.FindPackageByBarcode(validBarcode);
			Assert.IsNotNull(package);
			string invalidBarcode = "111111";
			package = SimDB.FindPackageByBarcode(invalidBarcode);
			Assert.IsNull(package);
		}

		[TestMethod]
		public void Employee_RegisterPackage()
		{
			Assert.AreEqual(0, dc.packages.Count);
			MedicationPackage package = new MedicationPackage();
			dc.RegisterPackage("1", DateTime.Today);
			Assert.AreEqual(1, dc.packages.Count);
		}

		[TestMethod]
		public void Employee_SendPackage()
		{
			string barcode = "000000";
			dc.SendPackage(barcode, new DistributionCentre());
			Assert.AreEqual(PackageStatus.InTransit, package.Status);
		}

		[TestMethod]
		public void Employee_ReceivePackage()
		{
			Assert.AreEqual(0, dc.packages.Count);
			string barcode = "000000";
			package.Status = PackageStatus.InTransit;
			dc.ReceivePackage(barcode);
			Assert.AreEqual(1, dc.packages.Count);
			Assert.AreEqual(PackageStatus.InStock, package.Status);
		}
		*/ 
	}
}
