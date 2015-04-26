using System.Collections.Generic;
using System.Data.SqlClient;

namespace ENETCare.Business
{
	/// <summary>
	/// Employee DataReader implementation
	/// </summary>
	public class EmployeeDataReaderDAO : DataReaderDAO, EmployeeDAO
	{
		string selectStatement = "select a.Id, a.UserName, a.Fullname, a.Email, a.DistributionCentre_ID, c.Name";
		string fromClause = "from AspNetUsers a";
		string joinClause1 = "join AspNetUserRoles b on a.Id = b.UserId";
		string joinClause2 = "join AspNetRoles c on b.RoleId = c.Id";

		/// <summary>
		/// Retrieves all employees in the database.
		/// </summary>
		/// <returns>a list of all the employees</returns>
		public List<Employee> FindAllEmployees()
		{
			List<Employee> employeeList = new List<Employee>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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

		/// <summary>
		/// Retrieves employees of given role.
		/// </summary>
		/// <param name="role">employee role</param>
		/// <returns>a list of the employees corresponding to the role</returns>
		public List<Employee> FindEmployeesByRole(Role role)
		{
			List<Employee> employeeList = new List<Employee>();
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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

		/// <summary>
		/// Retrieves an employee by looking up its username.
		/// </summary>
		/// <param name="username">employee username</param>
		/// <returns>an employee corresponding to the username, or null if no matching employee was found</returns>
		public Employee GetEmployeeByUserName(string username)
		{
			using (SqlConnection conn = new SqlConnection())
			{
				conn.ConnectionString = ConnectionString;
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
		}

		/// <summary>
		/// Helper-method to create an employee for a row of the database.
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Gets Role enum from role name
		/// </summary>
		/// <param name="roleName"></param>
		/// <returns></returns>
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
