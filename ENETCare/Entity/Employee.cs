using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class Employee
	{
		public string ID { get; set; }
		public string Username { get; set; }
		public string Fullname { get; set; }
		public string Email { get; set; }
		public Role Role { get; set; }
		public DistributionCentre DistributionCentre { get; set; }
	}

	public enum Role
	{
		Agent,
		Doctor,
		Manager
	};
}
