using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.GUI.Mockup
{
	public partial class ReportMockup : System.Web.UI.Page
	{
		private ReportBLL reportBLL;
		private DistributionCentreBLL distributionCentreBLL;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				distributionCentreBLL = new DistributionCentreBLL();
				DistributionCentreDropDownList.DataSource = distributionCentreBLL.GetDistributionCentreList();
				DistributionCentreDropDownList.DataTextField = "Name";
				DistributionCentreDropDownList.DataValueField = "ID";
				DistributionCentreDropDownList.DataBind();
			}
			
		}

		protected void QueryButton_Click(object sender, EventArgs e)
		{
			string distributionCentre = DistributionCentreDropDownList.SelectedValue;
			try
			{
				reportBLL = new ReportBLL();
				GridView1.DataSource = reportBLL.DistributionCentreStock(Convert.ToInt32(distributionCentre));
				GridView1.DataBind();
			}
			catch (Exception ex)
			{
				Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
			}
		}
	}
}