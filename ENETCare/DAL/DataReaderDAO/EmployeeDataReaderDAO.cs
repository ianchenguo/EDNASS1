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

		public List<Employee> FindAllEmployees()
		{
			List<Employee> employeeList = new List<Employee>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select Id, UserName, Fullname, Email, DistributionCentre_ID
								   from AspNetUsers";
				SqlCommand command = new SqlCommand(query, conn);
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						Employee employee = GetEmployeeFromDataReader(reader);
						employeeList.Add(employee);
					}
				}
			}
			return employeeList;
		}

		public Employee GetEmployeeByUserName(string username)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = @"select Id, UserName, Fullname, Email, DistributionCentre_ID
								   from AspNetUsers
								  where UserName = @username";
				SqlCommand command = new SqlCommand(query, conn);
				command.Parameters.Add(new SqlParameter("username", username));
				using (SqlDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						return GetEmployeeFromDataReader(reader);
					}
				}
			}
			return null;
			/*
			// Mockup Test
			Employee employee = new Employee();
			employee.ID = "1";
			employee.Username = "starcraft";
			employee.Role = Role.Doctor;
			employee.Fullname = "StarCraft";
			employee.Email = "StarCraft@blizzard.com";
			DistributionCentre dc = new DistributionCentreDataReaderDAO().GetDistributionCentreById(1);
			employee.DistributionCentre = dc;
			return employee;
			*/
		}

		Employee GetEmployeeFromDataReader(SqlDataReader reader)
		{
			Employee employee = new Employee();
			employee.ID = reader.GetString(0);
			employee.Username = reader.GetString(1);
			employee.Fullname = reader.GetString(2);
			employee.Email = reader.GetString(3);
			employee.DistributionCentre = new DistributionCentreDataReaderDAO().GetDistributionCentreById(reader.GetInt32(4));
			return employee;
		}
	}
}
