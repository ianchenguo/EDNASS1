using System;
using System.Collections.Generic;
using ENETCare.Presentation.HelperUtilities;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.Presentation.AgentDoctorFeatures
{
    public partial class AgentDoctorReceivePackage : System.Web.UI.Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        private AgentDoctorFeatures masterPageADreceive;
        protected void Page_Load(object sender, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL(User.Identity.Name);
            masterPageADreceive = Page.Master as AgentDoctorFeatures;
            masterPageADreceive.ConfigureAlertBox(false);
        }

        protected void AgentDoctorReceivePackageButton_Click(object sender, EventArgs e)
        {
            string AgentDoctorReceivePackageBarcode = AgentDoctorReceivePackagesBarcode.Text;
            try
            {
                medicationPackageBLL.ReceivePackage(AgentDoctorReceivePackageBarcode);
                this.ADReceivePackageSuccessfulRespond(AgentDoctorReceivePackageBarcode);
                
            }
            catch (Exception ex)
            {
                this.ADreceivePackageErrorRespond(ex);
            }
        }

        private void ADReceivePackageSuccessfulRespond(string ADRPbarcode)
        {
            string successMsg = "Successfully send.";
            this.ADReceivePackageHandleMessage(AlertBoxHelper.AlertType.Success, AlertBoxHelper.ALERT_STYLE_SUCCESS, successMsg);
            this.ClearAgentDoctorReceivePackage_Barcode(ADRPbarcode);
        }

        private void ADreceivePackageErrorRespond(Exception ex)
        {
            AgentDoctorReceivePackagesBarcode.Text = "";
            //Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            this.ADReceivePackageHandleMessage(AlertBoxHelper.AlertType.Error, AlertBoxHelper.ALERT_STYLE_DANGER, ex.Message.ToString());
        }

        private void ADReceivePackageHandleMessage(AlertBoxHelper.AlertType alertType, string alertStyle, string alertContent)
        {
            masterPageADreceive.ConfigureAlertBox(true, alertStyle, alertType.ToString(), alertContent);
        }

        private void ClearAgentDoctorReceivePackage_Barcode(string ADreceivePackageBarcode)
        {
            if (ADreceivePackageBarcode != null && ADreceivePackageBarcode != "")
            {
                AgentDoctorReceivePackagesBarcode.Text = "";
            }
        }
    }
}