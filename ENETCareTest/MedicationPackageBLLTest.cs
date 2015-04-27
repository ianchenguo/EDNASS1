using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;
using System.Collections.Generic;

namespace ENETCareTest
{
	[TestClass]
	public class MedicationPackageBLLTest
	{
		DistributionCentre dc1;
		DistributionCentre dc2;
		Employee agent;
		Employee doctor;
		MedicationType type1;
		MedicationType type2;
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

		[TestCleanup]
		public void TearDown()
		{
			TimeProvider.ResetToDefault();
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

			type1 = new MedicationType();
			type1.ID = 1;
			type1.Name = "100 polio vaccinations";
			type1.ShelfLife = 365;
			type1.Value = 500;
			type1.IsSensitive = true;

			type2 = new MedicationType();
			type2.ID = 2;
			type2.Name = "box of 500 x 28 pack chloroquine pills";
			type2.ShelfLife = 7300;
			type2.Value = 3000;
			type2.IsSensitive = true;
		}

		[TestMethod]
		public void RegisterPackage_WithValidData_ShouldBeRegistered()
		{
			string username = agent.Username;
			string barcode = "123456";
			string expireDate = "2016-04-30";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(agent);
			medicationTypeDAO.Setup(x => x.GetMedicationTypeById(It.IsAny<int>())).Returns(type1);
			medicationPackageDAO.Setup(x => x.InsertPackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationTypeDAO = medicationTypeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			bll.RegisterPackage(type1.ID, expireDate, barcode);

			// Assert
			AssertPackage(barcode, PackageStatus.InStock, dc1, null, null, username, result);
		}

		[TestMethod]
		[ExpectedException(typeof(ENETCareException))]
		public void RegisterPackage_WithInvalidType_ShouldFail()
		{
			string username = agent.Username;
			string barcode = "123456";
			string expireDate = "2016-04-30";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(agent);
			medicationTypeDAO.Setup(x => x.GetMedicationTypeById(It.IsAny<int>())).Returns((MedicationType)null);
			medicationPackageDAO.Setup(x => x.InsertPackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationTypeDAO = medicationTypeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			bll.RegisterPackage(type1.ID, expireDate, barcode);

			// Assert
			Assert.Fail();
		}

		[TestMethod]
		[ExpectedException(typeof(ENETCareException))]
		public void RegisterPackage_WithInvalidDate_ShouldFail()
		{
			string username = agent.Username;
			string barcode = "123456";
			string expireDate = "2016-13-30";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(agent);
			medicationTypeDAO.Setup(x => x.GetMedicationTypeById(It.IsAny<int>())).Returns(type1);
			medicationPackageDAO.Setup(x => x.InsertPackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationTypeDAO = medicationTypeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			bll.RegisterPackage(type1.ID, expireDate, barcode);

			// Assert
			Assert.Fail();
		}

		[TestMethod]
		public void SendPackage_WithValidData_ShouldBeSent()
		{
			string username = agent.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			// Arrange
			distributionCentreDAO.Setup(x => x.GetDistributionCentreById(It.IsAny<int>())).Returns(dc2);
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(agent);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Status = PackageStatus.InStock, StockDC = dc1, SourceDC = null, DestinationDC = null, Operator = username });
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.DistributionCentreDAO = distributionCentreDAO.Object;
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			bll.SendPackage(barcode, dc2.ID);

			// Assert
			AssertPackage(barcode, PackageStatus.InTransit, null, dc1, dc2, username, result);
		}

		[TestMethod]
		[ExpectedException(typeof(ENETCareException))]
		public void SendPackage_WithNonExistingBarcode_ShouldFail()
		{
			string username = agent.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			// Arrange
			distributionCentreDAO.Setup(x => x.GetDistributionCentreById(It.IsAny<int>())).Returns(dc2);
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(agent);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns((MedicationPackage)null);
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.DistributionCentreDAO = distributionCentreDAO.Object;
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			bll.SendPackage(barcode, dc2.ID);

			// Assert
			Assert.Fail();
		}

		[TestMethod]
		[ExpectedException(typeof(ENETCareException))]
		public void SendPackage_ToCurrentDistributionCentre_ShouldFail()
		{
			string username = agent.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			// Arrange
			distributionCentreDAO.Setup(x => x.GetDistributionCentreById(It.IsAny<int>())).Returns(dc1);
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(agent);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Status = PackageStatus.InStock, StockDC = dc1, SourceDC = null, DestinationDC = null, Operator = username });
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.DistributionCentreDAO = distributionCentreDAO.Object;
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			bll.SendPackage(barcode, dc1.ID);

			// Assert
			Assert.Fail();
		}

		[TestMethod]
		public void ReceivePackage_WithValidData_ShouldBeReceived()
		{
			string username = doctor.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Status = PackageStatus.InTransit, StockDC = null, SourceDC = dc1, DestinationDC = dc2, Operator = agent.Username });
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			bll.ReceivePackage(barcode);

			// Assert
			AssertPackage(barcode, PackageStatus.InStock, dc2, null, null, username, result);
		}

		[TestMethod]
		public void ReceivePackage_WithLostStatus_ShouldBeReceived()
		{
			string username = doctor.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Status = PackageStatus.Lost, StockDC = null, SourceDC = dc1, DestinationDC = dc2, Operator = agent.Username });
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			bll.ReceivePackage(barcode);

			// Assert
			AssertPackage(barcode, PackageStatus.InStock, dc2, null, null, username, result);
		}

		[TestMethod]
		public void DistributePackage_WithValidData_ShouldBeDistributed()
		{
			string username = doctor.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = agent.Username });
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			bll.DistributePackage(barcode);

			// Assert
			AssertPackage(barcode, PackageStatus.Distributed, dc2, null, null, username, result);
		}

		[TestMethod]
		public void DistributePackage_WithAnotherStockDistributionCentre_ShouldBeDistributed()
		{
			string username = doctor.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Status = PackageStatus.InStock, StockDC = dc1, SourceDC = null, DestinationDC = null, Operator = agent.Username });
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			bll.DistributePackage(barcode);

			// Assert
			AssertPackage(barcode, PackageStatus.Distributed, dc2, null, null, username, result);
		}

		[TestMethod]
		public void DiscardPackage_WithValidData_ShouldBeDiscarded()
		{
			string username = doctor.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = agent.Username });
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			bll.DiscardPackage(barcode);

			// Assert
			AssertPackage(barcode, PackageStatus.Discarded, dc2, null, null, username, result);
		}

		[TestMethod]
		public void DiscardPackage_WithDistributedStatus_ShouldBeDiscarded()
		{
			string username = doctor.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Status = PackageStatus.Distributed, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = agent.Username });
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			bll.DiscardPackage(barcode);

			// Assert
			AssertPackage(barcode, PackageStatus.Discarded, dc2, null, null, username, result);
		}

		[TestMethod]
		public void Stocktake_WithDifferentExpireStatus_ShouldBeIdentified()
		{
			MedicationPackageBLL bll = new MedicationPackageBLL(agent.Username);

			// Arrange
			var timeMock = new Mock<TimeProvider>();
			timeMock.SetupGet(tp => tp.Now).Returns(new DateTime(2015, 4, 25));
			TimeProvider.Current = timeMock.Object;
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(agent);
			medicationPackageDAO.Setup(x => x.FindInStockPackagesInDistributionCentre(It.IsAny<int>(), null)).Returns(
				new List<MedicationPackage>()
				{
					new MedicationPackage { Barcode = "100001", Type = type1, ExpireDate = new DateTime(2015, 3, 30) },
					new MedicationPackage { Barcode = "100002", Type = type1, ExpireDate = new DateTime(2015, 4, 30) },
					new MedicationPackage { Barcode = "100003", Type = type1, ExpireDate = new DateTime(2015, 5, 30) }
				});
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			List<StocktakingViewData> list = bll.Stocktake();

			// Assert
			Assert.AreEqual(3, list.Count);
			Assert.AreEqual("100001", list[0].Barcode);
			Assert.AreEqual(ExpireStatus.Expired, list[0].ExpireStatus);
			Assert.AreEqual("100002", list[1].Barcode);
			Assert.AreEqual(ExpireStatus.AboutToExpired, list[1].ExpireStatus);
			Assert.AreEqual("100003", list[2].Barcode);
			Assert.AreEqual(ExpireStatus.NotExpired, list[2].ExpireStatus);
		}

		[TestMethod]
		public void AuditScan_WithNonExistingBarcode_ShouldBeRegistered()
		{
			string username = doctor.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;
			bool updated = false;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationTypeDAO.Setup(x => x.GetMedicationTypeById(It.IsAny<int>())).Returns(type1);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns((MedicationPackage)null);
			medicationPackageDAO.Setup(x => x.InsertPackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationTypeDAO = medicationTypeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			updated = bll.CheckAndUpdatePackage(type1.ID, barcode);

			// Assert
			AssertPackage(barcode, PackageStatus.InStock, dc2, null, null, username, result);
			Assert.AreEqual(true, updated);
		}

		[TestMethod]
		public void AuditScan_WithUnexpectedPackage_ShouldBeUpdated()
		{
			string username = doctor.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;
			bool updated = false;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationTypeDAO.Setup(x => x.GetMedicationTypeById(It.IsAny<int>())).Returns(type1);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Type = type1, Status = PackageStatus.Lost, StockDC = dc1, SourceDC = null, DestinationDC = null, Operator = username });
			medicationPackageDAO.Setup(x => x.InsertPackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationTypeDAO = medicationTypeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			updated = bll.CheckAndUpdatePackage(type1.ID, barcode);

			// Assert
			Assert.AreEqual(true, updated);
			AssertPackage(barcode, PackageStatus.InStock, dc2, null, null, username, result);
		}

		[TestMethod]
		[ExpectedException(typeof(ENETCareException))]
		public void AuditScan_WithNonMatchedPackageType_ShouldFail()
		{
			string username = doctor.Username;
			string barcode = "123456";
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			MedicationPackage result = null;
			bool updated = false;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationTypeDAO.Setup(x => x.GetMedicationTypeById(It.IsAny<int>())).Returns(type1);
			medicationPackageDAO.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns(
				new MedicationPackage { Barcode = barcode, Type = type2, Status = PackageStatus.Lost, StockDC = dc1, SourceDC = null, DestinationDC = null, Operator = username });
			medicationPackageDAO.Setup(x => x.InsertPackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationTypeDAO = medicationTypeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			updated = bll.CheckAndUpdatePackage(type1.ID, barcode);

			// Assert
			Assert.Fail();
		}

		[TestMethod]
		public void Audit_WithPartialPackagesScanned_ShouldIdentifyLostPackages()
		{
			string username = doctor.Username;
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			List<string> scannedList = new List<string>() { "100001", "100003", "100005" };
			MedicationPackage result = null;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationPackageDAO.Setup(x => x.FindInStockPackagesInDistributionCentre(It.IsAny<int>(), It.IsAny<int>())).Returns(
				new List<MedicationPackage>()
				{
					new MedicationPackage { Barcode = "100001", Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = agent.Username },
					new MedicationPackage { Barcode = "100002", Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = agent.Username },
					new MedicationPackage { Barcode = "100003", Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = agent.Username },
					new MedicationPackage { Barcode = "100004", Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = doctor.Username },
					new MedicationPackage { Barcode = "100005", Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = doctor.Username }
				});
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			List<MedicationPackage> lostPackages = bll.AuditPackages(type1.ID, scannedList);

			// Assert
			Assert.AreEqual(2, lostPackages.Count);
			AssertPackage("100002", PackageStatus.Lost, dc2, null, null, username, lostPackages[0]);
			AssertPackage("100004", PackageStatus.Lost, dc2, null, null, username, lostPackages[1]);
		}

		[TestMethod]
		public void Audit_WithAllPackagesScaned_ShouldReturnEmptyList()
		{
			string username = doctor.Username;
			MedicationPackageBLL bll = new MedicationPackageBLL(username);
			List<string> scannedList = new List<string>() { "100001", "100002", "100003", "100004", "100005" };
			MedicationPackage result = null;

			// Arrange
			employeeDAO.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns(doctor);
			medicationPackageDAO.Setup(x => x.FindInStockPackagesInDistributionCentre(It.IsAny<int>(), It.IsAny<int>())).Returns(
				new List<MedicationPackage>()
				{
					new MedicationPackage { Barcode = "100001", Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = agent.Username },
					new MedicationPackage { Barcode = "100002", Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = agent.Username },
					new MedicationPackage { Barcode = "100003", Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = agent.Username },
					new MedicationPackage { Barcode = "100004", Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = doctor.Username },
					new MedicationPackage { Barcode = "100005", Status = PackageStatus.InStock, StockDC = dc2, SourceDC = null, DestinationDC = null, Operator = doctor.Username }
				});
			medicationPackageDAO.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>())).Callback<MedicationPackage>(r => result = r);
			bll.EmployeeDAO = employeeDAO.Object;
			bll.MedicationPackageDAO = medicationPackageDAO.Object;

			// Act
			List<MedicationPackage> lostPackages = bll.AuditPackages(type1.ID, scannedList);

			// Assert
			Assert.AreEqual(0, lostPackages.Count);
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
