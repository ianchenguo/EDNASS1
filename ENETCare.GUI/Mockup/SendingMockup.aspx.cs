using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.GUI.Mockup
{
	public partial class SendingMockup : System.Web.UI.Page
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
				DistributionCentreDropDownList.DataSource = SimDB.distributionCentreList;
				DistributionCentreDropDownList.DataTextField = "Name";
				DistributionCentreDropDownList.DataValueField = "ID";
				DistributionCentreDropDownList.DataBind();
			}
		}

		protected void SendButton_Click(object sender, EventArgs e)
		{
			string distributionCentre = DistributionCentreDropDownList.SelectedValue;
			string barcode = BarcodeTextBox.Text;
			try
			{
				packageBUS.SendPackage(barcode, distributionCentre);
				Response.Redirect("IndexMockup.aspx");
			}
			catch (Exception ex)
			{
				Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
			}
		}
	}
}