using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class ReportDataReaderDAO : ReportDAO
	{
		string connectionString = DBSchema.ConnectionString;

		public List<MedicationTypeViewData> FindDistributionCentreStockByStatus(int distributionCentreId, params PackageStatus[] statuses)
		{
			List<MedicationTypeViewData> list = new List<MedicationTypeViewData>();
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
						MedicationTypeViewData row = GetDistributionCentreStockViewDataFromDataReader(reader);
						list.Add(row);
					}
				}
			}
			return list;
		}

		public List<MedicationTypeViewData> FindGlobalStock()
		{
			List<MedicationTypeViewData> list = new List<MedicationTypeViewData>();
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
						MedicationTypeViewData row = GetDistributionCentreStockViewDataFromDataReader(reader);
						list.Add(row);
					}
				}
			}
			return list;
		}

		public List<MedicationTypeViewData> FindDoctorActivityByUserName(string username)
		{
			List<MedicationTypeViewData> list = new List<MedicationTypeViewData>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select b.Name, count(*), sum(b.Value)
								   from MedicationPackage a
								   join MedicationType b on a.Type = b.Id
								  where a.Operator = @username
									and a.Status = @status
								  group by b.Name";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("username", username));
				command.Parameters.Add(new SqlParameter("status", PackageStatus.Distributed));
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						MedicationTypeViewData row = GetDistributionCentreStockViewDataFromDataReader(reader);
						list.Add(row);
					}
				}
			}
			return list;
		}

		public List<ValueInTransitViewData> FindAllValueInTransit()
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

		MedicationTypeViewData GetDistributionCentreStockViewDataFromDataReader(SqlDataReader reader)
		{
			var row = new MedicationTypeViewData
			{
				Type = reader.GetString(0),
				Quantity = reader.GetInt32(1),
				Value = reader.GetDecimal(2)
			};
			return row;
		}
	}
}
