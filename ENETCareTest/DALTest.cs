using System;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ENETCareTest
{
	[TestClass]
	public class DALTest
	{
		[AssemblyInitialize]
		public static void SetupDataDirectory(TestContext context)
		{
			AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetFullPath(@"..\..\..\ENETCare.Presentation\App_Data\"));
		}

		[TestMethod()]
		public void Connection_OpenClose_Succeeds()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			conn.Close();
		}
	}
}
