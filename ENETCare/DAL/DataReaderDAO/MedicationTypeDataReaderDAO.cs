using System.Collections.Generic;
using System.Data.SqlClient;

namespace ENETCare.Business
{
	/// <summary>
	/// MedicationType DataReader implementation
	/// </summary>
	public class MedicationTypeDataReaderDAO : DataReaderDAO, MedicationTypeDAO
	{
		/// <summary>
		/// Retrieves all medication types in the database.
		/// </summary>
		/// <returns>a list of all the medication types</returns>
		public List<MedicationType> FindAllMedicationTypes()
		{
			List<MedicationType> medicationTypeList = new List<MedicationType>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
				conn.Open();
				string query = @"select ID, Name, ISNULL(Description, ''), ShelfLife, Value, IsSensitive
								   from MedicationType";
				SqlCommand command = new SqlCommand(query, conn);
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						MedicationType type = GetMedicationTypeFromDataReader(reader);
						medicationTypeList.Add(type);
					}
				}
			}
			return medicationTypeList;
		}

		/// <summary>
		/// Retrieves a medication type by looking up its id.
		/// </summary>
		/// <param name="id">medication type id</param>
		/// <returns>a medication type corresponding to the id, or null if no matching medication type was found</returns>
		public MedicationType GetMedicationTypeById(int id)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
				conn.Open();
				string query = @"select ID, Name, ISNULL(Description, ''), ShelfLife, Value, IsSensitive
								   from MedicationType
								  where ID = @id";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("id", id));
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						return GetMedicationTypeFromDataReader(reader);
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Helper-method to create a medication type for a row of the database.
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		MedicationType GetMedicationTypeFromDataReader(SqlDataReader reader)
		{
			MedicationType type = new MedicationType();
			type.ID = reader.GetInt32(0);
			type.Name = reader.GetString(1);
			type.Description = reader.GetString(2);
			type.ShelfLife = reader.GetInt16(3);
			type.Value = reader.GetDecimal(4);
			type.IsSensitive = reader.GetBoolean(5);
			return type;
		}
	}
}
