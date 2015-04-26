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

		public Employee GetEmployeeByUserName(string username)
		{
			return EmployeeDAO.GetEmployeeByUserName(username);
		}

		public List<Employee> GetEmployeeList()
		{
			return EmployeeDAO.FindAllEmployees();
		}

		public List<Employee> GetEmployeeListByRole(Role role)
		{
			return EmployeeDAO.FindEmployeesByRole(role);
		}
	}
}
