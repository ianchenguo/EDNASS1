using System.Collections.Generic;

namespace ENETCare.Business
{
	public class EmployeeBLL
	{
		EmployeeDAO EmployeeDAO { get; set; }

		public EmployeeBLL()
		{
			EmployeeDAO = DAOFactory.GetEmployeeDAO();
		}

		/// <summary>
		/// Retrieves all employees in the database.
		/// </summary>
		/// <returns>a list of all the employees</returns>
		public List<Employee> GetEmployeeList()
		{
			return EmployeeDAO.FindAllEmployees();
		}

		/// <summary>
		/// Retrieves an employee by looking up its username.
		/// </summary>
		/// <param name="username">employee username</param>
		/// <returns>an employee corresponding to the username, or null if no matching employee was found</returns>
		public Employee GetEmployeeByUserName(string username)
		{
			return EmployeeDAO.GetEmployeeByUserName(username);
		}

		/// <summary>
		/// Retrieves employees of given role.
		/// </summary>
		/// <param name="role">employee role</param>
		/// <returns>a list of the employees corresponding to the role</returns>
		public List<Employee> GetEmployeeListByRole(Role role)
		{
			return EmployeeDAO.FindEmployeesByRole(role);
		}
	}
}
