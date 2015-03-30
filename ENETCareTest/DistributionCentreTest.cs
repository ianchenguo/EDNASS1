using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;

namespace ENETCareTest
{
	[TestClass]
	public class DistributionCentreTest
	{
		DistributionCentre dc;

		[TestInitialize]
		public void Setup()
		{
			dc = new DistributionCentre();
		}

		[TestMethod]
		public void DistributionCentre_name_canBeStored()
		{
			string dcName = "UTS";
			dc.Name = dcName;
			Assert.AreEqual(dc.Name, dcName);
		}

		[TestMethod]
		public void DistributionCentre_address_canBeStored()
		{
			string dcAddress = "15 Broadway, Ultimo NSW 2007";
			dc.Address = dcAddress;
			Assert.AreEqual(dc.Address, dcAddress);
		}

		[TestMethod]
		public void DistributionCentre_phone_canBeStored()
		{
			string dcPhone = "(02) 9514 2000";
			dc.Phone = dcPhone;
			Assert.AreEqual(dc.Phone, dcPhone);
		}
		/*
		[TestMethod]
		public void DistributionCentre_packagelist_canBeStored()
		{
			List<MedicationPackage> dcPackages = new List<MedicationPackage>();
			dc.packages = dcPackages;
			Assert.AreEqual(dc.packages, dcPackages);
		}
		*/
	}
}
