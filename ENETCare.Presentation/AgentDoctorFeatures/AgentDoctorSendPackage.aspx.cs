using System;
using System.Collections.Generic;
using ENETCare.Presentation.HelperUtilities;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;
using ENETCare.Presentation.Layout;

namespace ENETCare.Presentation.AgentDoctorFeatures
{
    public partial class AgentDoctorSendPackage : System.Web.UI.Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        private Features masterPageClass;
        protected void Page_Load(object sender, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL(User.Identity.Name);
            if (!Page.IsPostBack)
            {
                AgentDoctorSendingDropDownList.DataSource = new DistributionCentreBLL().GetDistributionCentreList();
                AgentDoctorSendingDropDownList.DataTextField = "Name";
                AgentDoctorSendingDropDownList.DataValueField = "ID";
                AgentDoctorSendingDropDownList.DataBind();
            }
            //AgentDoctorSendPackageDateTextBox.Text = DateTime.Now.ToShortDateString();
            masterPageClass = Page.Master.Master as Features;
            masterPageClass.ConfigureAlertBox(false);

        }

        protected void AgentDoctorSendPackageTypeButton_Click(object sender, EventArgs e)
        {
            string distributionCentre = AgentDoctorSendingDropDownList.SelectedValue;
            string AgentDoctorSendBarcode = AgentDoctorSendPackageTypebarcode.Text;
            try
            {
                medicationPackageBLL.SendPackage(AgentDoctorSendBarcode, Convert.ToInt32(distributionCentre));
                //Response.Write("Successfully send.");
                this.ADsendPackageSuccessfulRespond(AgentDoctorSendBarcode);
            }
            catch (Exception ex)
            {
                this.ADsendPackageErrorRespond(ex);
            }
        }

        private void ADsendPackageSuccessfulRespond(string ADSPbarcode)
        {
            string successMsg = "Successfully send.";
            this.ADsendPackageHandleMessage(AlertBoxHelper.AlertType.Success, AlertBoxHelper.ALERT_STYLE_SUCCESS, successMsg);
            this.ClearAgentDoctorSendPackageAfterClick(ADSPbarcode);
        }

        private void ADsendPackageErrorRespond(Exception ex)
        {
            AgentDoctorSendPackageTypebarcode.Text = "";
            //Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            this.ADsendPackageHandleMessage(AlertBoxHelper.AlertType.Error, AlertBoxHelper.ALERT_STYLE_DANGER, ex.Message.ToString());
        }

        private void ADsendPackageHandleMessage(AlertBoxHelper.AlertType alertType, string alertStyle, string alertContent)
        {
            masterPageClass.ConfigureAlertBox(true, alertStyle, alertType.ToString(), alertContent);
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