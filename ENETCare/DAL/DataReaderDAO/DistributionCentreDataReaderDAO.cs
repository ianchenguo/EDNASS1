using System.Collections.Generic;
using System.Data.SqlClient;

namespace ENETCare.Business
{
	/// <summary>
	/// DistributionCentre DataReader implementation
	/// </summary>
	public class DistributionCentreDataReaderDAO : DataReaderDAO, DistributionCentreDAO
	{
		/// <summary>
		/// Retrieves all distribution centres in the database.
		/// </summary>
		/// <returns>a list of all the distribution centres</returns>
		public List<DistributionCentre> FindAllDistributionCentres()
		{
			List<DistributionCentre> distributionCentreList = new List<DistributionCentre>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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

		/// <summary>
		/// Retrieves a distribution centre by looking up its id.
		/// </summary>
		/// <param name="id">distribution centre id</param>
		/// <returns>a distribution centre corresponding to the id, or null if no matching distribution centre was found</returns>
		public DistributionCentre GetDistributionCentreById(int id)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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
						return GetDistributionCentreFromDataReader(reader);
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Helper-method to create a distribution centre for a row of the database.
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
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
