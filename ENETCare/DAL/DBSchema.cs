using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class DBSchema
	{
		private static string connectionString;
		public static string ConnectionString
		{
			get
			{
				if (string.IsNullOrEmpty(connectionString))
				{
					string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\ENETCare.Presentation\App_Data\"));
					AppDomain.CurrentDomain.SetData("DataDirectory", path); // ,Path.GetFullPath(@"ENETCare.GUI\App_Data\"));
					connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;
				}
				return connectionString;
			}
			//get { return @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\MockupDB.mdf;Initial Catalog=MockupDB;Integrated Security=True"; }
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
