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
		protected string ConnectionString
		{
			get
			{
				if (string.IsNullOrEmpty(connectionString))
				{
					connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;
				}
				return connectionString;
			}
		}
	}
}
