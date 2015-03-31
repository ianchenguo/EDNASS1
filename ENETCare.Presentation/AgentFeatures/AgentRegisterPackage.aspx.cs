using ENETCare.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.Presentation.AgentFeatures
{
    public partial class AgentRegisterPackage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SimDB.HasInitTestData)
            {
                SimDB.PrepareTestData();
            }
        }
        protected void Submit(object sender, EventArgs e)
        {
            //what's this for?
            if (IsValid)
            {
                var test = NedPackageRegisterFormPackageType.Text;
                PackageBUS packageBUS = new PackageBUS();
                packageBUS.RegisterPackage(NedPackageRegisterFormPackageType.Text, NedPackageRegisterFormExpireDate.Text);
            }
        }
    }
}