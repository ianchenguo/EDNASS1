using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class EmployeeDataReaderDAO : EmployeeDAO
	{
		string connectionString = DBSchema.ConnectionString;

		public Employee FindEmployeeByUserId(int userid)
		{
			// should be changed according to Identity Framework
			Employee employee = new Employee();
			employee.ID = 1;
			employee.Username = "starcraft";
			employee.Role = Role.Doctor;
			employee.Fullname = "StarCraft";
			employee.Email = "StarCraft@blizzard.com";
			DistributionCentre dc = new DistributionCentreDataReaderDAO().GetDistributionCentreById(1);
			employee.DistributionCentre = dc;
			return employee;
		}

		public Employee FindEmployeeByUserName(string username)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select Id, Fullname, Email, DistributionCentre_ID
								   from AspNetUsers
								  where UserName = @username";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("username", username));
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						Employee employee = new Employee();
						//employee.ID = reader.GetInt32(0);
						employee.Username = username;
						employee.UserId = reader.GetString(0);
						employee.Fullname = reader.GetString(1);
						employee.Email = reader.GetString(2);
						employee.DistributionCentre = new DistributionCentreDataReaderDAO().GetDistributionCentreById(reader.GetInt32(3));
						return employee;
					}
				}
			}
			return null;
			/*
			// should be changed according to Identity Framework
			Employee employee = new Employee();
			employee.ID = 1;
			employee.Username = "starcraft";
			employee.Role = Role.Doctor;
			employee.Fullname = "StarCraft";
			employee.Email = "StarCraft@blizzard.com";
			DistributionCentre dc = new DistributionCentreDataReaderDAO().GetDistributionCentreById(1);
			employee.DistributionCentre = dc;
			return employee;
			*/
		}
	}
}
