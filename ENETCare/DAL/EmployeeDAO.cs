using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public interface EmployeeDAO
	{
		Employee FindEmployeeByUserName(string username);
	}
}
