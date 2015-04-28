using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;

namespace ENETCareTest
{
	[TestClass]
	public class DatabaseAccessTest
	{
		//TransactionScope _trans;
		MedicationPackageDataReaderDAO dao;
		string connectionString;
		string barcode;
		DistributionCentre dc;
		MedicationType type;

		[AssemblyInitialize]
		public static void SetupDataDirectory(TestContext context)
		{
			AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetFullPath(@"..\..\..\ENETCare.Presentation\App_Data\"));
		}

		[TestInitialize]
		public void Setup()
		{
			// MSDTC is not availabe on LocalDB, therefore transaction handling is commented
			//_trans = new TransactionScope();
			dao = new MedicationPackageDataReaderDAO();
			connectionString = ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;
			PrepareTestData();
		}

		[TestCleanup()]
		public void Cleanup()
		{
			//_trans.Dispose();
		}

		void PrepareTestData()
		{
			barcode = "123456";
			dc = FetchTestDistributionCentre();
			type = FetchTestMedicationType();
			DeletePackageIfExists();
		}

		DistributionCentre FetchTestDistributionCentre()
		{
			DistributionCentre dc = new DistributionCentre(); ;
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = "select top 1 ID, Name, Address, Phone from DistributionCentre";
				SqlCommand command = new SqlCommand(query, conn);
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						dc.ID = reader.GetInt32(0);
						dc.Name = reader.GetString(1);
						dc.Address = reader.GetString(2);
						dc.Phone = reader.GetString(3);
					}
				}
			}
			return dc;
		}

		MedicationType FetchTestMedicationType()
		{
			MedicationType type = new MedicationType(); ;
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = "select top 1 ID, Name, ISNULL(Description, ''), ShelfLife, Value, IsSensitive from MedicationType";
				SqlCommand command = new SqlCommand(query, conn);
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						type.ID = reader.GetInt32(0);
						type.Name = reader.GetString(1);
						type.Description = reader.GetString(2);
						type.ShelfLife = reader.GetInt16(3);
						type.Value = reader.GetDecimal(4);
						type.IsSensitive = reader.GetBoolean(5);
					}
				}
			}
			return type;
		}

		void DeletePackageIfExists()
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = "delete from MedicationPackage where Barcode = @barcode";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("barcode", barcode));
				command.ExecuteNonQuery();
			}
		}

		[TestMethod()]
		public void Connection_OpenClose_Succeeds()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			conn.Close();
		}

		[TestMethod()]
		public void MedicationPackageDAO_CRUD_ShouldSucceed()
		{
			// Find package by non-existing barcode
			MedicationPackage package = dao.FindPackageByBarcode(barcode);
			Assert.IsNull(package);

			// Insert package
			package = new MedicationPackage();
			package.Barcode = barcode;
			package.Type = type;
			package.Status = PackageStatus.InStock;
			package.ExpireDate = new DateTime(2015, 12, 31);
			package.StockDC = dc;
			package.SourceDC = null;
			package.DestinationDC = null;
			package.Operator = "blizzard";
			dao.InsertPackage(package);

			// Find package after insert
			package = dao.FindPackageByBarcode(barcode);
			Assert.IsNotNull(package);
			Assert.AreEqual(PackageStatus.InStock, package.Status);
			Assert.AreEqual("blizzard", package.Operator);

			// Update package
			package.Status = PackageStatus.Distributed;
			package.Operator = "popcap";
			dao.UpdatePackage(package);

			// Find package after update
			package = dao.FindPackageByBarcode(barcode);
			Assert.IsNotNull(package);
			Assert.AreEqual(PackageStatus.Distributed, package.Status);
			Assert.AreEqual("popcap", package.Operator);

			// Delete package
			dao.DeletePackage(package.ID);

			// Find package after delete
			package = dao.FindPackageByBarcode(barcode);
			Assert.IsNull(package);
		}
	}
}
