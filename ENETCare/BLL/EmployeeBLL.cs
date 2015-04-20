using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class EmployBLL
	{
		EmployeeDAO EmployeeDAO
		{
			get { return DAOFactory.GetEmployeeDAO(); }
		}

		public Employee GetEmployeeByUserName(string username)
		{
			return EmployeeDAO.GetEmployeeByUserName(username);
		}

		public List<Employee> GetEmployeeList()
		{
			return EmployeeDAO.FindAllEmployees();
		}
	}
}
