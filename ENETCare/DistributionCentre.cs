using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare
{
	public class DistributionCentre
	{
		public int id;
		public string name;
		public string address;
		public string phone;

		public List<MedicationPackage> packages = new List<MedicationPackage>();
	}
}
