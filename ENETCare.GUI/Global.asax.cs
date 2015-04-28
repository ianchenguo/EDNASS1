using System;
using System.IO;

namespace ENETCare.GUI
{
	public class Global : System.Web.HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\ENETCare.Presentation\App_Data\"));
			AppDomain.CurrentDomain.SetData("DataDirectory", path);
		}
	}
}