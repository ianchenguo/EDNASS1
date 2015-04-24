using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.Presentation.DoctorFeatures
{
    public partial class DoctorFeatures : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterPackageLinkButton_Click(object sender, EventArgs e)
        {
            string RegisterPackageUrl = "~/AgentDoctorFeatures/AgentDoctorRegisterPackage.aspx";
            Response.Redirect(RegisterPackageUrl);
        }

        protected void SendPackageLinkButton_Click(object sender, EventArgs e)
        {
            string SendPackageUrl = "~/AgentDoctorFeatures/AgentDoctorSendPackage.aspx";
            Response.Redirect(SendPackageUrl);
        }

        protected void ReceivePackageLinkButton_Click(object sender, EventArgs e)
        {
            string ReceivePackageUrl = "~/AgentDoctorFeatures/AgentDoctorReceivePackage.aspx";
            Response.Redirect(ReceivePackageUrl);
        }

        protected void ViewPackageLinkButton_Click(object sender, EventArgs e)
        {
            string ViewPackageUrl = "~/AgentDoctorFeatures/AgentDoctorViewReport.aspx";
            Response.Redirect(ViewPackageUrl);
        }
    }
}