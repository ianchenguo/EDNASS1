using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare;

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
			dc.name = dcName;
			Assert.AreEqual(dc.name, dcName);
		}

		[TestMethod]
		public void DistributionCentre_address_canBeStored()
		{
			string dcAddress = "15 Broadway, Ultimo NSW 2007";
			dc.address = dcAddress;
			Assert.AreEqual(dc.address, dcAddress);
		}

		[TestMethod]
		public void DistributionCentre_phone_canBeStored()
		{
			string dcPhone = "(02) 9514 2000";
			dc.phone = dcPhone;
			Assert.AreEqual(dc.phone, dcPhone);
		}

		[TestMethod]
		public void DistributionCentre_packagelist_canBeStored()
		{
			List<MedicationPackage> dcPackages = new List<MedicationPackage>();
			dc.packages = dcPackages;
			Assert.AreEqual(dc.packages, dcPackages);
		}
	}
}
