using ENETCare.Business;
using ENETCare.Presentation.HelperUtilities;
using ENETCare.Presentation.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.Presentation.AgentDoctorFeatures
{
    public partial class AgentDoctoDiscardPackage : System.Web.UI.Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        private Features masterPageADDiscard;
        protected void Page_Load(object sender, EventArgs e)
        {

            medicationPackageBLL = new MedicationPackageBLL(User.Identity.Name);
            masterPageADDiscard = Page.Master.Master as Features;
            masterPageADDiscard.ConfigureAlertBox(false);
        }

        protected void AgentDoctorDiscardPackageButton_Click(object sender, EventArgs e)
        {
            string AgentDoctorDiscardPackageBarcode = AgentDoctorDiscardPackagesBarcode.Text;
            try
            {
                medicationPackageBLL.DiscardPackage(AgentDoctorDiscardPackageBarcode);
                this.ADDiscardPackageSuccessfulRespond(AgentDoctorDiscardPackageBarcode);

            }
            catch (Exception ex)
            {
                this.ADDiscardPackageErrorRespond(ex);
            }
        }

        private void ADDiscardPackageSuccessfulRespond(string ADRPbarcode)
        {
            string successMsg = "Successfully Discarded.";
            this.ADDiscardPackageHandleMessage(AlertBoxHelper.AlertType.Success, AlertBoxHelper.ALERT_STYLE_SUCCESS, successMsg);
            this.ClearAgentDoctorDiscardPackage_Barcode(ADRPbarcode);
        }

        private void ADDiscardPackageErrorRespond(Exception ex)
        {
            AgentDoctorDiscardPackagesBarcode.Text = "";
            //Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            this.ADDiscardPackageHandleMessage(AlertBoxHelper.AlertType.Error, AlertBoxHelper.ALERT_STYLE_DANGER, ex.Message.ToString());
        }

        private void ADDiscardPackageHandleMessage(AlertBoxHelper.AlertType alertType, string alertStyle, string alertContent)
        {
            masterPageADDiscard.ConfigureAlertBox(true, alertStyle, alertType.ToString(), alertContent);
        }

        private void ClearAgentDoctorDiscardPackage_Barcode(string ADDiscardPackageBarcode)
        {
            if (ADDiscardPackageBarcode != null && ADDiscardPackageBarcode != "")
            {
                AgentDoctorDiscardPackagesBarcode.Text = "";
            }
        }
    }
}