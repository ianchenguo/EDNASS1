using System;

namespace ENETCare.Business
{
	/// <summary>
	/// Employee entity
	/// </summary>
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
		Agent = 1,
		Doctor = 2,
		Manager = 3,
		Undefined = 4
	};
}
