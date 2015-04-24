using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.Presentation.AgentFeatures
{
    public partial class AuditPackage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AuditPackageButton_Click(object sender, EventArgs e)
        {
            var scannedPackages = Session["scannedpackages"] as List<int>;

            if (scannedPackages == null)
            {
                List<int> storedList = new List<int>();
                Session.Add("scannedpackages", storedList);
            }
            else
            {
                MedicationPackageBLL.
            }

        }
    }
}