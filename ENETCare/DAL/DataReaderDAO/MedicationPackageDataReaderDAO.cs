using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ENETCare.Business
{
	public class MedicationPackageDataReaderDAO : MedicationPackageDAO
	{
		string connectionString = DBSchema.ConnectionString;
		string selectStatement = "select ID, Barcode, Type, ExpireDate, Status, ISNULL(StockDC, ''), ISNULL(SourceDC, ''), ISNULL(DestinationDC, ''), Operator";
		string fromClause = "from MedicationPackage";

		public List<MedicationPackage> FindAllPackages()
		{
			List<MedicationPackage> packageList = new List<MedicationPackage>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = string.Format("{0} {1}", selectStatement, fromClause);
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
		
		public List<MedicationPackage> FindInStockPackagesInDistributionCentre(int distributionCentreId, int? medicationTypeId = null)
		{
			List<MedicationPackage> packageList = new List<MedicationPackage>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string whereClause = "where Status = @status and StockDC = @stockdc";
				if (medicationTypeId != null)
				{
					whereClause += " and Type = @type";
				}
				string query = string.Format("{0} {1} {2}", selectStatement, fromClause, whereClause);
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("status", PackageStatus.InStock));
				command.Parameters.Add(new SqlParameter("stockdc", distributionCentreId));
				if (medicationTypeId != null)
				{
					command.Parameters.Add(new SqlParameter("type", medicationTypeId));
				}
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
				string whereClause = "where Barcode = @barcode";
				string query = string.Format("{0} {1} {2}", selectStatement, fromClause, whereClause);
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("barcode", barcode));
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						return GetMedicationPackageFromDataReader(reader);
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
				string query = @"insert into MedicationPackage (Barcode, Type, ExpireDate, Status, StockDC, Operator, UpdateTime)
								 values (@barcode, @type, @expiredate, @status, @stockdc, @operator, getdate())";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("barcode", package.Barcode));
				command.Parameters.Add(new SqlParameter("type", package.Type.ID));
				command.Parameters.Add(new SqlParameter("expiredate", package.ExpireDate));
				command.Parameters.Add(new SqlParameter("status", package.Status));
				command.Parameters.Add(new SqlParameter("stockdc", package.StockDC.ID));
				command.Parameters.Add(new SqlParameter("operator", package.Operator));
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
									set Status = @status, StockDC = @stockdc, SourceDC = @sourcedc, DestinationDC = @destinationdc, Operator = @operator, UpdateTime = getdate()
								  where ID = @id";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("id", package.ID));
				command.Parameters.Add(new SqlParameter("status", package.Status));
				command.Parameters.Add(new SqlParameter("stockdc", package.StockDC != null ? (object)package.StockDC.ID : DBNull.Value));
				command.Parameters.Add(new SqlParameter("sourcedc", package.SourceDC != null ? (object)package.SourceDC.ID : DBNull.Value));
				command.Parameters.Add(new SqlParameter("destinationdc", package.DestinationDC != null ? (object)package.DestinationDC.ID : DBNull.Value));
				command.Parameters.Add(new SqlParameter("operator", package.Operator));
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
			package.Operator = reader.GetString(8);
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
	}
}
