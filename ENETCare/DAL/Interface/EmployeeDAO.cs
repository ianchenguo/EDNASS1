using System.Collections.Generic;

namespace ENETCare.Business
{
	public interface EmployeeDAO
	{
		List<Employee> FindAllEmployees();
		List<Employee> FindEmployeesByRole(Role role);
		Employee GetEmployeeByUserName(string username);
	}
}
