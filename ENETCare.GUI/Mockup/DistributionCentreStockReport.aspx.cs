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

				try
				{
					reportBLL = new ReportBLL();
					List<MedicationTypeViewData> list2 = reportBLL.GlobalStock();
					string total2 = list2.Sum(type => type.Value).ToString();
					GridView2.DataSource = list2;
					GridView2.DataBind();
					Label2.Text = total2;

					List<DistributionCentreLossViewData> list3 = reportBLL.DistributionCentreLosses();
					GridView3.DataSource = list3;
					GridView3.DataBind();

					List<ValueInTransitViewData> list4 = reportBLL.ValueInTransit();
					string total4 = list4.Sum(type => type.Value).ToString();
					GridView4.DataSource = list4;
					GridView4.DataBind();
					Label4.Text = total4;

					List<MedicationTypeViewData> list5 = reportBLL.DoctorActivity("starcraft");
					string total5 = list5.Sum(type => type.Value).ToString();
					GridView5.DataSource = list5;
					GridView5.DataBind();
					Label5.Text = total5;
				}
				catch (Exception ex)
				{
					Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
				}
			}
			
		}

		protected void QueryButton_Click(object sender, EventArgs e)
		{
			string distributionCentre = DistributionCentreDropDownList.SelectedValue;
			try
			{
				reportBLL = new ReportBLL();
				List<MedicationTypeViewData> list = reportBLL.DistributionCentreStock(Convert.ToInt32(distributionCentre));
				string total = list.Sum(type => type.Value).ToString();
				GridView1.DataSource = list;
				GridView1.DataBind();
				Label1.Text = total;
			}
			catch (Exception ex)
			{
				Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
			}
		}
	}
}