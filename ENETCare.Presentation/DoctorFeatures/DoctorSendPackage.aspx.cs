using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.Presentation.DoctorFeatures
{
    public partial class DoctorSendPackage : System.Web.UI.Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL("LoginUserName");
            if (!Page.IsPostBack)
            {
                DoctorPackageSendingDestination.DataSource = new DistributionCentreBLL().GetDistributionCentreList();
                DoctorPackageSendingDestination.DataTextField = "Name";
                DoctorPackageSendingDestination.DataValueField = "ID";
                DoctorPackageSendingDestination.DataBind();
            }
            DoctorSendPackageDateTextBox.Text = DateTime.Now.ToShortDateString();
        }

        protected void DoctorSendButton_Click(object sender, EventArgs e)
        {
            string distributionCentre = DoctorPackageSendingDestination.SelectedValue;
            string DoctorSendingPackageBarcode = DoctorSendBarcodeTextBox.Text;
            try
            {
                medicationPackageBLL.SendPackage(DoctorSendingPackageBarcode, Convert.ToInt32(distributionCentre));
                //Response.Redirect("DoctorHome.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            }
        }

    }
}