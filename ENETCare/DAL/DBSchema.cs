using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class DBSchema
	{
		public static string ConnectionString
		{
			// ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			get { return @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\MockupDB.mdf;Initial Catalog=MockupDB;Integrated Security=True"; }
		}
		
		public static string DistributionCentreTableName
		{
			get { return "DistributionCentre"; }
		}

		public static string EmployeeTableName
		{
			get { return "Employee"; }
		}

		public static string MedicationTypeTaleName
		{
			get { return "MedicationType"; }
		}

		public static string MedicationPackageTableName
		{
			get { return "MedicationPackage"; }
		}
	}
}
