using System;
using System.Collections.Generic;
using ENETCare.Presentation.HelperUtilities;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;
using ENETCare.Presentation.Layout;

namespace ENETCare.Presentation.DoctorFeatures
{
    public partial class DoctorDistribute : System.Web.UI.Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        private Features masterPageClass;

        protected void Page_Load(object Distributeer, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL(User.Identity.Name);

            masterPageClass = Page.Master.Master as Features;
            masterPageClass.ConfigureAlertBox(false);
        }

        protected void DoctorDistributePackageTypeButton_Click(object Distributeer, EventArgs e)
        {
            //string distributionCentre = DoctorDistributeDropDownList.SelectedValue;
            string DoctorDistributeBarcode = DoctorDistributePackageTypebarcode.Text;
            try
            {
                medicationPackageBLL.DistributePackage(DoctorDistributeBarcode, true);
                this.ADDistributePackageSuccessfulRespond();
            }
            catch (Exception ex)
            {
                this.ADDistributePackageErrorRespond(ex);
            }
        }

        private void ADDistributePackageSuccessfulRespond()
        {
            string successMsg = "Successfully Distributed.";
            this.ADDistributePackageHandleMessage(AlertBoxHelper.AlertType.Success, AlertBoxHelper.ALERT_STYLE_SUCCESS, successMsg);
            DoctorDistributePackageTypebarcode.Text = "";
        }

        private void ADDistributePackageErrorRespond(Exception ex)
        {
            this.ADDistributePackageHandleMessage(AlertBoxHelper.AlertType.Error, AlertBoxHelper.ALERT_STYLE_DANGER, ex.Message.ToString());
            DoctorDistributePackageTypebarcode.Text = "";
        }

        private void ClearDoctorDistributePackage_Barcode(string DoctorDistributeBCode)
        {
            if (DoctorDistributeBCode != null && DoctorDistributeBCode != "")
            {
                DoctorDistributePackageTypebarcode.Text = "";
            }
        }

        private void ADDistributePackageHandleMessage(AlertBoxHelper.AlertType alertType, string alertStyle, string alertContent)
        {
            masterPageClass.ConfigureAlertBox(true, alertStyle, alertType.ToString(), alertContent);
        }

        protected void DoctorDistributeLinkButton_Click(object sender, EventArgs e)
        {
            string CanclePackageUrl = "~/AgentDoctorFeatures/AgentDoctorHome.aspx";
            Response.Redirect(CanclePackageUrl);
        }
    }
}