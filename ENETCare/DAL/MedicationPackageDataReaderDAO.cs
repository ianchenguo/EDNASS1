using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class MedicationPackageDataReaderDAO : MedicationPackageDAO
	{
		string connectionString = DBSchema.ConnectionString;

		public List<MedicationPackage> FindAllPackages()
		{
			List<MedicationPackage> packageList = new List<MedicationPackage>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select ID, Barcode, Type, ExpireDate, Status, ISNULL(StockDC, ''), ISNULL(SourceDC, ''), ISNULL(DestinationDC, ''), UpdateTime
								   from MedicationPackage";
				SqlCommand command = new SqlCommand(query, conn);
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						MedicationPackage package = GetMedicationPackageFromDataReader(reader);
						packageList.Add(package);
					}
				}
			}
			return packageList;
		}
		
		public List<object> FindPackagesInDistributionCentre(int distributionCentreId)
		{
			List<object> packageList = new List<object>();
			const int warningDays = 7;
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select Barcode, Type, ExpireDate
								   from MedicationPackage
								  where StockDC = @id
									and Status = @status";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("id", distributionCentreId));
				command.Parameters.Add(new SqlParameter("status", PackageStatus.InStock));
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						string barcode = reader.GetString(0);
						string type = GetMedicationTypeByID(reader.GetInt32(1)).Name;
						DateTime expireDate = reader.GetDateTime(2);
						string expireStatus = "NotExpired";
						if (DateTime.Now > expireDate)
						{
							expireStatus = "Expired";
						}
						else if (DateTime.Now.AddDays(warningDays) > expireDate)
						{
							expireStatus = "AboutToExpired";
						}
						var package = new
						{
							Barcode = barcode,
							Type = type,
							ExpireDate = expireDate.ToString("d", new CultureInfo("en-au")),
							ExpireStatus = expireStatus
						};
						packageList.Add(package);
					}
				}
			}
			return packageList;
		}

		public List<MedicationPackage> FindPackages(int medicationTypeId, int distributionCentreId)
		{
			List<MedicationPackage> packageList = new List<MedicationPackage>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select ID, Barcode, Type, ExpireDate, Status, ISNULL(StockDC, ''), ISNULL(SourceDC, ''), ISNULL(DestinationDC, ''), UpdateTime
								   from MedicationPackage
								  where Type = @type
									and StockDC = @dc";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("type", medicationTypeId));
				command.Parameters.Add(new SqlParameter("dc", distributionCentreId));
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						MedicationPackage package = GetMedicationPackageFromDataReader(reader);
						packageList.Add(package);
					}
				}
			}
			return packageList;
		}
		
		public MedicationPackage FindPackageByBarcode(string barcode)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select ID, Barcode, Type, ExpireDate, Status, ISNULL(StockDC, ''), ISNULL(SourceDC, ''), ISNULL(DestinationDC, ''), UpdateTime
								   from MedicationPackage
								  where Barcode = @barcode";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("barcode", barcode));
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						return GetMedicationPackageFromDataReader(reader); ;
					}
				}
			}
			return null;
		}

		public void InsertPackage(MedicationPackage package)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"insert into MedicationPackage (Barcode, Type, ExpireDate, Status, StockDC, UpdateTime)
								 values (@barcode, @type, @expiredate, @status, @stockdc, getdate())";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("barcode", package.Barcode));
				command.Parameters.Add(new SqlParameter("type", package.Type.ID));
				command.Parameters.Add(new SqlParameter("expiredate", package.ExpireDate));
				command.Parameters.Add(new SqlParameter("status", package.Status));
				command.Parameters.Add(new SqlParameter("stockdc", package.StockDC.ID));
				command.ExecuteNonQuery();
			}
		}

		public void UpdatePackage(MedicationPackage package)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"update MedicationPackage
									set Status = @status, StockDC = @stockdc, SourceDC = @sourcedc, DestinationDC = @destinationdc, UpdateTime = getdate()
								  where ID = @id";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("id", package.ID));
				command.Parameters.Add(new SqlParameter("status", package.Status));
				command.Parameters.Add(new SqlParameter("stockdc", package.StockDC != null ? (object)package.StockDC.ID : DBNull.Value));
				command.Parameters.Add(new SqlParameter("sourcedc", package.SourceDC != null ? (object)package.SourceDC.ID : DBNull.Value));
				command.Parameters.Add(new SqlParameter("destinationdc", package.DestinationDC != null ? (object)package.DestinationDC.ID : DBNull.Value));
				command.ExecuteNonQuery();
			}
		}

		MedicationPackage GetMedicationPackageFromDataReader(SqlDataReader reader)
		{
			MedicationPackage package = new MedicationPackage();
			package.ID = reader.GetInt32(0);
			package.Barcode = reader.GetString(1);
			package.Type = GetMedicationTypeByID(reader.GetInt32(2));
			package.ExpireDate = reader.GetDateTime(3);
			package.Status = (PackageStatus)reader.GetInt16(4);
			package.StockDC = GetDistributionCentreByID(reader.GetInt32(5));
			package.SourceDC = GetDistributionCentreByID(reader.GetInt32(6));
			package.DestinationDC = GetDistributionCentreByID(reader.GetInt32(7));
			return package;
		}

		MedicationType GetMedicationTypeByID(int id)
		{
			return new MedicationTypeDataReaderDAO().GetMedicationTypeById(id);
		}

		DistributionCentre GetDistributionCentreByID(int id)
		{
			return new DistributionCentreDataReaderDAO().GetDistributionCentreById(id);
		}

		#region Report

		/*
		 * This report shows the quantity and total value for each product type in stock at a given distribution centre. 
		 * It also has a grand total for all products at the distribution centre.
		 */
		public List<object> DistributionCentreStockReport(int distributionCentreId)
		{
			List<object> list = new List<object>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select b.Name, count(*), sum(b.Value)
								   from MedicationPackage a, MedicationType b
								  where a.Type = b.Id
									and a.Status = 0
									and a.StockDC = @id
								  group by b.Name";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("id", distributionCentreId));
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						string name = reader.GetString(0);
						int quantity = reader.GetInt32(1);
						decimal value = reader.GetDecimal(2);
						var type = new
						{
							Name = name,
							Quantity = quantity,
							Value = value
						};
						list.Add(type);
					}
				}
			}
			return list;
		}

		#endregion
	}
}
