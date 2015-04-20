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
				string query = @"select ID, Barcode, Type, ExpireDate, Status, ISNULL(StockDC, ''), ISNULL(SourceDC, ''), ISNULL(DestinationDC, ''), Operator
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

		public List<StocktakingViewData> FindPackagesInDistributionCentre(int distributionCentreId)
		{
			List<StocktakingViewData> packageList = new List<StocktakingViewData>();
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
						ExpireStatus expireStatus = ExpireStatus.NotExpired;
						if (DateTime.Now > expireDate)
						{
							expireStatus = ExpireStatus.Expired;
						}
						else if (DateTime.Now.AddDays(warningDays) > expireDate)
						{
							expireStatus = ExpireStatus.AboutToExpired;
						}
						var package = new StocktakingViewData
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
				string query = @"select ID, Barcode, Type, ExpireDate, Status, ISNULL(StockDC, ''), ISNULL(SourceDC, ''), ISNULL(DestinationDC, ''), Operator
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
				string query = @"select ID, Barcode, Type, ExpireDate, Status, ISNULL(StockDC, ''), ISNULL(SourceDC, ''), ISNULL(DestinationDC, ''), Operator
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
				string query = @"insert into MedicationPackage (Barcode, Type, ExpireDate, Status, StockDC, UpdateTime, Operator)
								 values (@barcode, @type, @expiredate, @status, @stockdc, getdate(), @operator)";
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
									set Status = @status, StockDC = @stockdc, SourceDC = @sourcedc, DestinationDC = @destinationdc, UpdateTime = getdate(), Operator = @operator
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

		#region Report

		DistributionCentreStockViewData GetDistributionCentreStockViewDataFromDataReader(SqlDataReader reader)
		{
			var row = new DistributionCentreStockViewData
			{
				Type = reader.GetString(0),
				Quantity = reader.GetInt32(1),
				Value = reader.GetDecimal(2)
			};
			return row;
		}

		/// <summary>
		/// This report shows the quantity and total value for each product type in stock at a given distribution centre.
		/// </summary>
		/// <param name="distributionCentreId"></param>
		/// <returns></returns>
		public List<DistributionCentreStockViewData> DistributionCentreStockReport(int distributionCentreId, params PackageStatus[] statuses)
		{
			List<DistributionCentreStockViewData> list = new List<DistributionCentreStockViewData>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select b.Name, count(*), sum(b.Value)
								   from MedicationPackage a
								   join MedicationType b on a.Type = b.Id
								  where a.StockDC = @id
									and a.Status in ({0})
								  group by b.Name";
				string[] paramNames = statuses.Select((s, i) => "@status" + i.ToString()).ToArray();
				string inClause = string.Join(",", paramNames);
				string cmdText = string.Format(query, inClause);
				SqlCommand command = new SqlCommand(cmdText, conn);
				command.Parameters.Add(new SqlParameter("id", distributionCentreId));
				for (int i = 0; i < paramNames.Length; i++)
				{
					command.Parameters.Add(new SqlParameter(paramNames[i], statuses[i]));
				}
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						DistributionCentreStockViewData row = GetDistributionCentreStockViewDataFromDataReader(reader);
						list.Add(row);
					}
				}
			}
			return list;
		}

		/// <summary>
		/// This report shows the quantity and total value for each product type in stock across all distribution centres.
		/// </summary>
		/// <returns></returns>
		public List<DistributionCentreStockViewData> GlobalStockReport()
		{
			List<DistributionCentreStockViewData> list = new List<DistributionCentreStockViewData>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select b.Name, count(*), sum(b.Value)
								   from MedicationPackage a
								   join MedicationType b on a.Type = b.Id
								  where a.Status = @status
								  group by b.Name";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("status", PackageStatus.InStock));
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						DistributionCentreStockViewData row = GetDistributionCentreStockViewDataFromDataReader(reader);
						list.Add(row);
					}
				}
			}
			return list;
		}

		/// <summary>
		/// This report shows the quantity, package types and values of packages distributed by a given doctor.
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public List<DistributionCentreStockViewData> DoctorActivityReport(string username)
		{
			List<DistributionCentreStockViewData> list = new List<DistributionCentreStockViewData>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select b.Name, count(*), sum(b.Value)
								   from MedicationPackage a
								   join MedicationType b on a.Type = b.Id
								  where a.Operator = @id
									and a.Status = @status
								  group by b.Name";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("id", username));
				command.Parameters.Add(new SqlParameter("status", PackageStatus.Distributed));
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						DistributionCentreStockViewData row = GetDistributionCentreStockViewDataFromDataReader(reader);
						list.Add(row);
					}
				}
			}
			return list;
		}
		
		public List<ValueInTransitViewData> DistributionCentreTransit()
		{
			List<ValueInTransitViewData> list = new List<ValueInTransitViewData>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select y1.Name, y2.Name, x.Packages, x.Value
								   from (select a.SourceDC, a.DestinationDC, count(*) Packages, sum(b.Value) Value
										   from MedicationPackage a
										   join MedicationType b on a.Type = b.Id
										  where a.Status = @status
										  group by a.SourceDC, a.DestinationDC) x
								   join DistributionCentre y1 ON x.SourceDC = y1.Id
								   join DistributionCentre y2 ON x.DestinationDC = y2.Id";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("status", PackageStatus.InTransit));
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						var row = new ValueInTransitViewData
						{
							FromDistributionCentre = reader.GetString(0),
							ToDistributionCentre = reader.GetString(1),
							Packages = reader.GetInt32(2),
							Value = reader.GetDecimal(3)
						};
						list.Add(row);
					}
				}
			}
			return list;
		}

		#endregion
	}
}
