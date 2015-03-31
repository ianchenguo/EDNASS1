using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.GUI.Mockup
{
	public partial class RegistrationMockup : System.Web.UI.Page
	{
		private PackageBUS packageBUS;

		protected void Page_Load(object sender, EventArgs e)
		{
			packageBUS = new PackageBUS();
			if (!Page.IsPostBack)
			{
				if (!SimDB.HasInitTestData)
				{
					SimDB.PrepareTestData();
				}
				TypeDropDownList.DataSource = SimDB.medicationTypeList;
				TypeDropDownList.DataTextField = "Name";
				TypeDropDownList.DataValueField = "ID";
				TypeDropDownList.DataBind();
			}
		}

		protected void RegisterButton_Click(object sender, EventArgs e)
		{
			string medicationType = TypeDropDownList.SelectedValue;
			string expireDate = ExpireDateTextBox.Text;
			try
			{
				packageBUS.RegisterPackage(medicationType, expireDate);
				Response.Redirect("IndexMockup.aspx");
			}
			catch (Exception ex)
			{
				Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
			}
		}
	}
}