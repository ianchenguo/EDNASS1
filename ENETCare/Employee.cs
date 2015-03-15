using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare
{
	public class Employee
	{
		public int id;
		public Role role;
		public string username;
		public string password;
		public string fullname;
		public string email;
		public DistributionCentre distributionCentre;

		public void UpdateProfile(string fullname, string email)
		{
			this.fullname = fullname;
			this.email = email;
		}

		public bool CheckPackage(string barcode)
		{
			if (barcode == "000000")
				return true;
			else
				return false;
		}

		public void RegisterPackage(MedicationPackage package)
		{
			distributionCentre.packages.Add(package);
		}

		public void SendPackage(MedicationPackage package, DistributionCentre destination)
		{
			package.status = PackageStatus.InTransit;
		}

		public void ReceivePackage(MedicationPackage package)
		{
			distributionCentre.packages.Add(package);
			package.status = PackageStatus.InStock;
		}
	}

	public enum Role
	{
		Agent,
		Doctor,
		Manager
	};
}
