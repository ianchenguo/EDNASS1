using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ENETCare.Business
{
	/// <summary>
	/// MedicationPackage DataReader implementation
	/// </summary>
	public class MedicationPackageDataReaderDAO : DataReaderDAO, MedicationPackageDAO
	{
		string selectStatement = "select ID, Barcode, Type, ExpireDate, Status, ISNULL(StockDC, ''), ISNULL(SourceDC, ''), ISNULL(DestinationDC, ''), Operator";
		string fromClause = "from MedicationPackage";

		/// <summary>
		/// Retrieves all medication packages in the database.
		/// </summary>
		/// <returns>a list of all the medication packages</returns>
		public List<MedicationPackage> FindAllPackages()
		{
			List<MedicationPackage> packageList = new List<MedicationPackage>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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
		
		/// <summary>
		/// Retrieves medication packages of given medication type at a given distribution centre.
		/// </summary>
		/// <param name="distributionCentreId">distribution centre id</param>
		/// <param name="medicationTypeId">medication type id</param>
		/// <returns>a list of the medication packages</returns>
		public List<MedicationPackage> FindInStockPackagesInDistributionCentre(int distributionCentreId, int? medicationTypeId = null)
		{
			List<MedicationPackage> packageList = new List<MedicationPackage>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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
		
		/// <summary>
		/// Retrieves a medication package by looking up its barcode.
		/// </summary>
		/// <param name="barcode">medication package barcode</param>
		/// <returns>a medication package corresponding to the barcode, or null if no matching medication package was found</returns>
		public MedicationPackage FindPackageByBarcode(string barcode)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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

		/// <summary>
		/// Inserts a medication package record into the database.
		/// </summary>
		/// <param name="package">medication package</param>
		public void InsertPackage(MedicationPackage package)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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

		/// <summary>
		/// Updates a medication package record in the database corresponding to the package id.
		/// </summary>
		/// <param name="package">medication package</param>
		public void UpdatePackage(MedicationPackage package)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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

		/// <summary>
		/// Deletes a medication package record from the database corresponding to the package id.
		/// </summary>
		/// <param name="packageId">medication package id</param>
		public void DeletePackage(int packageId)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
				conn.Open();
				string query = @"delete from MedicationPackage
								  where ID = @id";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("id", packageId));
				command.ExecuteNonQuery();
			}
		}

		/// <summary>
		/// Helper-method to create a medication package for a row of the database.
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
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
