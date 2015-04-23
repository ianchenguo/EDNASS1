using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public interface EmployeeDAO
	{
		List<Employee> FindAllEmployees();
        List<Employee> FindEmployeesByRole(Role role);
		Employee GetEmployeeByUserName(string username);
	}
}
