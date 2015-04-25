using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;

namespace ENETCareTest
{
	[TestClass]
	public class MedicationPackageBLLTest
	{
		DistributionCentre dc1;
		DistributionCentre dc2;
		Employee agent;
		Employee doctor;
		MedicationType type;
		Mock<DistributionCentreDAO> distributionCentreDAO;
		Mock<EmployeeDAO> employeeDAO;
		Mock<MedicationTypeDAO> medicationTypeDAO;
		Mock<MedicationPackageDAO> medicationPackageDAO;

		[TestInitialize]
		public void Setup()
		{
			PrepareTestData();
			distributionCentreDAO = new Mock<DistributionCentreDAO>();
			employeeDAO = new Mock<EmployeeDAO>();
			medicationTypeDAO = new Mock<MedicationTypeDAO>();
			medicationPackageDAO = new Mock<MedicationPackageDAO>();
		}

		void PrepareTestData()
		{
			dc1 = new DistributionCentre();
			dc1.ID = 1;
			dc1.Name = "Head Office";
			dc1.Address = "Bennelong Point, Sydney NSW 2000";
			dc1.Phone = "92507111";

			dc2 = new DistributionCentre();
			dc2.ID = 2;
			dc2.Name = "Liverpool Office";
			dc2.Address = "Macquarie Street, Liverpool NSW 2170";
			dc2.Phone = "96026633";

			agent = new Employee();
			agent.Username = "hearthstone";
			agent.Fullname = "Innkeeper";
			agent.Email = "hearthstone@blizzard.com";
			agent.Role = Role.Agent;
			agent.DistributionCentre = dc1;

			doctor = new Employee();
			doctor.Username = "starcraft";
			doctor.Fullname = "Jim Raynor";
			doctor.Email = "starCraft@blizzard.com";
			doctor.Role = Role.Doctor;
			doctor.DistributionCentre = dc2;

			type = new MedicationType();
			type.ID = 1;
			type.Name = "100 polio vaccinations";
			type.ShelfLife = 365;
			type.Value = 500;
			type.IsSensitive = true;
		}

		[TestMethod]
		public void RegisterPackage()
		{
			string username = agent.Username;
			string barcode = "123456";
			string expireDate = "2016-04-30";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(agent);
			medicationTypeDAO.Setup(x => x.GetMedicationTypeById(It.IsAny<int>())).Returns(type);
			medicationPackageDAO.Setup(x => x.InsertPackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);

			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationTypeDAO = medicationTypeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;
			bll.RegisterPackage(type.ID, expireDate, barcode);
			AssertPackage(barcode, PackageStatus.InStock, dc1, null, null, username, result);
		}

		[TestMethod]
		public void SendPackage()
		{
			string username = agent.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			distributionCentreDAO.Setup(x => x.GetDistributionCentreById(It.IsAny<int>())).Returns(dc2);
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(agent);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Status = PackageStatus.InStock, StockDC = dc1, SourceDC = null, DestinationDC = null, Operator = username });
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);

			bll.DistributionCentreDAO = distributionCentreDAO.Object;
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;
			bll.SendPackage(barcode, dc2.ID);
			AssertPackage(barcode, PackageStatus.InTransit, null, dc1, dc2, username, result);
		}

		[TestMethod]
		public void ReceivePackage()
		{
			string username = doctor.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Status = PackageStatus.InTransit, StockDC = null, SourceDC = dc1, DestinationDC = dc2, Operator = agent.Username });
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);

			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;
			bll.ReceivePackage(barcode);
			AssertPackage(barcode, PackageStatus.InStock, dc2, null, null, username, result);
		}

		[TestMethod]
		public void DistributePackage()
		{
			string username = doctor.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = agent.Username });
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);

			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;
			bll.DistributePackage(barcode);
			AssertPackage(barcode, PackageStatus.Distributed, dc2, null, null, username, result);
		}

		[TestMethod]
		public void DiscardPackage()
		{
			string username = doctor.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = agent.Username });
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);

			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;
			bll.DiscardPackage(barcode);
			AssertPackage(barcode, PackageStatus.Discarded, dc2, null, null, username, result);
		}

		void AssertPackage(string expectedBarcode, PackageStatus expectedStatus, DistributionCentre expectedStockDC, DistributionCentre expectedSourceDC, DistributionCentre expectedDestinationDC, string expectedUsername, MedicationPackage result)
		{
			Assert.AreEqual(expectedBarcode, result.Barcode);
			Assert.AreEqual(expectedStatus, result.Status);
			AssertDistributionCentre(expectedStockDC, result.StockDC);
			AssertDistributionCentre(expectedSourceDC, result.SourceDC);
			AssertDistributionCentre(expectedDestinationDC, result.DestinationDC);
			Assert.AreEqual(expectedUsername, result.Operator);
		}

		void AssertDistributionCentre(DistributionCentre expected, DistributionCentre result)
		{
			if (expected != null)
			{
				Assert.AreEqual(expected.ID, result.ID);
			}
			else
			{
				Assert.IsNull(result);
			}
		}
	}
}
