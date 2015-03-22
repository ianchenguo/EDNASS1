using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare
{
	public class Employee
	{
		public int ID { get; set; }
		public Role Role { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Fullname { get; set; }
		public string Email { get; set; }
		public DistributionCentre DistributionCentre { get; set; }

		public void UpdatePassword(string oldPassword, string newPassword)
		{
			Password = newPassword;
			SimDB.UpdateEmployee(this);
		}

		public void UpdateProfile(string fullname, string email, string distributionCentreID)
		{
			Fullname = fullname;
			Email = email;
			DistributionCentre distributionCentre = SimDB.GetDistributionCentreByID(distributionCentreID);
			DistributionCentre = distributionCentre;
			SimDB.UpdateEmployee(this);
		}

		public static Employee LoginUser()
		{
			Employee employee = new Employee();
			employee.Role = Role.Doctor;
			employee.Fullname = "StarCraft";
			employee.Email = "StarCraft@blizzard.com";
			employee.DistributionCentre = new DistributionCentre();
			return employee;
		}
	}

	public enum Role
	{
		Agent,
		Doctor,
		Manager
	};
}
