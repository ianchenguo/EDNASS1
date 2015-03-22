using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare
{
	public class SimDB
	{
		#region Medication Package

		public static List<MedicationPackage> FindAllPackages(DistributionCentre dc)
		{
			return new List<MedicationPackage>();
		}

		public static MedicationPackage FindPackageByBarcode(string barcode)
		{
			return new MedicationPackage();
		}

		public static void InsertPackage(MedicationPackage package)
		{

		}

		public static void UpdatePackage(MedicationPackage package)
		{

		}

		#endregion

		#region Medication Type

		public static MedicationType GetMedicationTypeByID(string id)
		{
			return new MedicationType();
		}

		#endregion

		#region Distribution Centre

		public static DistributionCentre GetDistributionCentreByID(string id)
		{
			return new DistributionCentre();
		}

		#endregion

		#region Employee

		public static Employee FindEmployeeByUserName(String username)
		{
			return new Employee();
		}

		public static void UpdateEmployee(Employee employee)
		{

		}

		#endregion
	}
}
