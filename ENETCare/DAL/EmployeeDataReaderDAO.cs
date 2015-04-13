using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class EmployeeDataReaderDAO : EmployeeDAO
	{
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
	}
}
