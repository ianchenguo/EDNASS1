using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.Presentation.AgentDoctorFeatures
{
    public partial class AgentDoctorSendPackage : System.Web.UI.Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL(User.Identity.Name);
            if (!Page.IsPostBack)
            {
                AgentDoctorSendingDropDownList.DataSource = new DistributionCentreBLL().GetDistributionCentreList();
                AgentDoctorSendingDropDownList.DataTextField = "Name";
                AgentDoctorSendingDropDownList.DataValueField = "ID";
                AgentDoctorSendingDropDownList.DataBind();
                //this.GridViewDataBind();
            }
            //AgentDoctorSendPackageDateTextBox.Text = DateTime.Now.ToShortDateString();
        }

        protected void AgentDoctorSendPackageTypeButton_Click(object sender, EventArgs e)
        {
            string distributionCentre = AgentDoctorSendingDropDownList.SelectedValue;
            string AgentDoctorSendBarcode = AgentDoctorSendPackageTypebarcode.Text;
            try
            {
                medicationPackageBLL.SendPackage(AgentDoctorSendBarcode, Convert.ToInt32(distributionCentre));
                Response.Write("Successfully send.");
                //Response.Redirect("AgentDoctorHome.aspx");
                this.ClearAgentDoctorSendPackageAfterClick(AgentDoctorSendBarcode);
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            }
        }

        private void ClearAgentDoctorSendPackageAfterClick(string AgentDoctorSendBarcode)
        {
            if (AgentDoctorSendBarcode != null && AgentDoctorSendBarcode != "")
            {
                AgentDoctorSendPackageTypebarcode.Text = "";
            }
        }
    }
}