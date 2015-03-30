using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.GUI.Mockup
{
	public partial class IndexMockup : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			GridView1.DataSource = SimDB.FindAllPackagesTest();
			GridView1.DataBind();
		}
	}
}