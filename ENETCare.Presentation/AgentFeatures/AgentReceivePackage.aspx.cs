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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AgentReceiveButton_Click(object sender, EventArgs e)
        {
            string barcode = AgentReceivebarcode.Text;
            //Employee.LoginUser().DistributionCentre.ReceivePackage(barcode);
        }
    }
}