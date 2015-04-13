using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class DistributionCentreDataReaderDAO : DistributionCentreDAO
	{
		string connectionString = DBSchema.ConnectionString;

		public List<DistributionCentre> FindAllDistributionCentres()
		{
			List<DistributionCentre> distributionCentreList = new List<DistributionCentre>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select ID, Name, Address, Phone
								   from DistributionCentre";
				SqlCommand command = new SqlCommand(query, conn);
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						DistributionCentre dc = GetDistributionCentreFromDataReader(reader);
						distributionCentreList.Add(dc);
					}
				}
			}
			return distributionCentreList;
		}

		public DistributionCentre GetDistributionCentreById(int id)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select ID, Name, Address, Phone
								   from DistributionCentre
								  where ID = @id";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("id", id));
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						return GetDistributionCentreFromDataReader(reader); ;
					}
				}
			}
			return null;
		}

		DistributionCentre GetDistributionCentreFromDataReader(SqlDataReader reader)
		{
			DistributionCentre dc = new DistributionCentre();
			dc.ID = reader.GetInt32(0);
			dc.Name = reader.GetString(1);
			dc.Address = reader.GetString(2);
			dc.Phone = reader.GetString(3);
			return dc;
		}
	}
}
