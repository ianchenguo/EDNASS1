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
		string selectStatement = "select a.Id, a.UserName, a.Fullname, a.Email, a.DistributionCentre_ID, c.Name";
		string fromClause = "from AspNetUsers a";
		string joinClause1 = "join AspNetUserRoles b on a.Id = b.UserId";
		string joinClause2 = "join AspNetRoles c on b.RoleId = c.Id";

		public List<Employee> FindAllEmployees()
		{
			List<Employee> employeeList = new List<Employee>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = connectionString;
				conn.Open();
				string query = string.Format("{0} {1} {2} {3}", selectStatement, fromClause, joinClause1, joinClause2);
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

        public List<Employee> FindEmployeesByRole(Role role)
        {
            List<Employee> employeeList = new List<Employee>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                string whereClause = "where c.Name = @role";
                string query = string.Format("{0} {1} {2} {3} {4}", selectStatement, fromClause, joinClause1, joinClause2, whereClause);
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("role", role.ToString()));
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
				string whereClause = "where a.UserName = @username";
				string query = string.Format("{0} {1} {2} {3} {4}", selectStatement, fromClause, joinClause1, joinClause2, whereClause);
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
			employee.Role = GetRoleFromRoleName(reader.GetString(5));
			return employee;
		}

		Role GetRoleFromRoleName(string roleName)
		{
			if (roleName == Properties.Resources.RoleAgent)
			{
				return Role.Agent;
			}
			else if (roleName == Properties.Resources.RoleDoctor)
			{
				return Role.Doctor;
			}
			else if (roleName == Properties.Resources.RoleManager)
			{
				return Role.Manager;
			}
			else
			{
				return Role.Undefined;
			}
		}
	}
}
