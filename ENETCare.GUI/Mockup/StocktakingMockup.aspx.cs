using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.GUI.Mockup
{
	public partial class StocktakingMockup : System.Web.UI.Page
	{
		private MedicationPackageBLL medicationPackageBLL;

		protected void Page_Load(object sender, EventArgs e)
		{
			medicationPackageBLL = new MedicationPackageBLL("LoginUserName");
			/*
			foreach (object o in medicationPackageBLL.Stocktake())
			{
				Type t = o.GetType();
				PropertyInfo p = t.GetProperty("ExpireDate");
				object v = p.GetValue(o, null);
				dynamic d = o;
				string s = (string)d.ExpireStatus;
			}
			*/
			GridView1.DataSource = medicationPackageBLL.Stocktake();
			GridView1.DataBind();
		}
	}
}