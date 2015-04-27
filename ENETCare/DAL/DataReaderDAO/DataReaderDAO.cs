using System;
using System.Configuration;
using System.IO;

namespace ENETCare.Business
{
	/// <summary>
	/// Base class for DataReader implementation
	/// </summary>
	public class DataReaderDAO
	{
		private string connectionString;
		public string ConnectionString
		{
			get
			{
				if (string.IsNullOrEmpty(connectionString))
				{
					string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\ENETCare.Presentation\App_Data\"));
					AppDomain.CurrentDomain.SetData("DataDirectory", path);
					connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;
				}
				return connectionString;
			}
		}
	}
}
