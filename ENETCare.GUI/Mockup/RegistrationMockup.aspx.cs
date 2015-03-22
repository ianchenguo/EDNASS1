using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare;

namespace ENETCare.GUI.Mockup
{
	public partial class RegistrationMockup : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (TypeDropDownList.Items.Count <= 1)
			{
				TypeDropDownList.Items.Add(new ListItem("100 polio vaccinations", "1"));
				TypeDropDownList.Items.Add(new ListItem("box of 500 x 28 pack chloroquine pills", "2"));
				TypeDropDownList.Items.Add(new ListItem("10L Polyheme", "3"));
				TypeDropDownList.Items.Add(new ListItem("water purification kit", "4"));
			}
		}

		protected void RegisterButton_Click(object sender, EventArgs e)
		{
			string type = TypeDropDownList.SelectedValue;
			DateTime expireDate = Convert.ToDateTime(ExpireDateTextBox.Text);
			Msg.Text = string.Format("Register: {0}; Expire date: {1}", type, expireDate);
			Employee.LoginUser().DistributionCentre.RegisterPackage(type, expireDate);
		}
	}
}