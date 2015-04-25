using System.Collections.Generic;
using System.Data.SqlClient;

namespace ENETCare.Business
{
	public class MedicationTypeDataReaderDAO : MedicationTypeDAO
	{
		string connectionString = DBSchema.ConnectionString;

		public List<MedicationType> FindAllMedicationTypes()
		{
			List<MedicationType> medicationTypeList = new List<MedicationType>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
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

		public MedicationType GetMedicationTypeById(int id)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
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
