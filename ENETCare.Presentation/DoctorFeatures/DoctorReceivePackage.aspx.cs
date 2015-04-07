using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.Presentation.DoctorFeatures
{
    public partial class DoctorReceivePackage : System.Web.UI.Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL("LoginUserName");
        }

        protected void DoctorReceivePackageButton_Click(object sender, EventArgs e)
        {
            string DoctorReceivebarcode = DoctorReceivePackagesBarcode.Text;
            try
            {
                medicationPackageBLL.ReceivePackage(DoctorReceivebarcode);
                Response.Redirect("DoctorHome.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            }
        }
    }
}