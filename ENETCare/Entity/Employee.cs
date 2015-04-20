using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class Employee
	{
		public int ID { get; set; }
		public string UserId { get; set; }
		public Role Role { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Fullname { get; set; }
		public string Email { get; set; }
		public DistributionCentre DistributionCentre { get; set; }
		/*
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
			if (distributionCentre != null)
			{
				DistributionCentre = distributionCentre;
				SimDB.UpdateEmployee(this);
			}
		}
		*/
		// for mockup test only
		public static string LoginUserName()
		{
			return "starcraft";
		}
	}

	public enum Role
	{
		Agent,
		Doctor,
		Manager
	};
}
