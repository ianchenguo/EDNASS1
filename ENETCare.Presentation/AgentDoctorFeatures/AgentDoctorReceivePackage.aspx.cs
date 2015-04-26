using System;
using System.Collections.Generic;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL(User.Identity.Name);
        }

        protected void AgentDoctorReceivePackageButton_Click(object sender, EventArgs e)
        {
            string AgentDoctorReceivePackageBarcode = AgentDoctorReceivePackagesBarcode.Text;
            try
            {
                medicationPackageBLL.ReceivePackage(AgentDoctorReceivePackageBarcode);
                //Response.Redirect("AgentDoctorHome.aspx");
                Response.Write("Successfully receive.");
                this.ClearAgentDoctorReceivePackage_Barcode(AgentDoctorReceivePackageBarcode);
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            }
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