using System;
using System.Configuration;
using System.IO;

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
	}
}
