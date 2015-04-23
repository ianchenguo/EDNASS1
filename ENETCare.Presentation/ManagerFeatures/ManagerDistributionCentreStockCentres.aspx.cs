using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.Presentation.Logic
{
    public partial class ManagerDistributionCenterCenters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void On_Distribution_Centres_Bound(object sender, EventArgs e)
        {
            DistributionCentresView.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }
}