using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.Presentation.AgentFeatures
{
    public partial class AgentReceivePackage : System.Web.UI.Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL("LoginUserName");
        }

        //protected void AgentReceiveButton_Click(object sender, EventArgs e)
        //{
        //    string barcode = AgentReceivebarcode.Text;
        //    //Employee.LoginUser().DistributionCentre.ReceivePackage(barcode);
        //}

        protected void AgentReceivePackageButton_Click(object sender, EventArgs e)
        {
            string AgentReceivePackageBarcode = AgentReceivePackagesBarcode.Text;
            try
            {
                medicationPackageBLL.ReceivePackage(AgentReceivePackageBarcode);
                Response.Redirect("AgentHome.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            }
        }
    }
}