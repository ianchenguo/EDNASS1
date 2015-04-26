﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ENETCare.Business
{
	/// <summary>
	/// Report DataReader implementation
	/// </summary>
	public class ReportDataReaderDAO : DataReaderDAO, ReportDAO
	{
		/// <summary>
		/// Retrieves the quantity and total value for each product type of given statuses at a given distribution centre.
		/// </summary>
		/// <param name="distributionCentreId">distribution centre id</param>
		/// <param name="statuses">package statuses</param>
		/// <returns>a list of MedicationTypeViewData</returns>
		public List<MedicationTypeViewData> FindDistributionCentreStockByStatus(int distributionCentreId, params PackageStatus[] statuses)
		{
			List<MedicationTypeViewData> list = new List<MedicationTypeViewData>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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

		/// <summary>
		/// Retrieves the quantity and total value for each product type in stock across all distribution centres.
		/// </summary>
		/// <returns>a list of MedicationTypeViewData</returns>
		public List<MedicationTypeViewData> FindGlobalStock()
		{
			List<MedicationTypeViewData> list = new List<MedicationTypeViewData>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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

		/// <summary>
		/// Retrieves the quantity and total value for each product type distributed by a given doctor.
		/// </summary>
		/// <param name="username">doctor username</param>
		/// <returns>a list of MedicationTypeViewData</returns>
		public List<MedicationTypeViewData> FindDoctorActivityByUserName(string username)
		{
			List<MedicationTypeViewData> list = new List<MedicationTypeViewData>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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

		/// <summary>
		/// Retrieves total value and number of packages in transit between distribution centres.
		/// </summary>
		/// <returns>a list of ValueInTransitViewData</returns>
		public List<ValueInTransitViewData> FindAllValueInTransit()
		{
			List<ValueInTransitViewData> list = new List<ValueInTransitViewData>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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

		/// <summary>
		/// Helper-method to create a medication type view data for a row of the database.
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
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
