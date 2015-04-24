using ENETCare.Presentation.HelperUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.Presentation.ManagerFeatures
{
    public partial class ManagerDistributionCentreLosses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DistributionCenterLossesView_DataBound(object sender, EventArgs e)
        {
            int lastColumn = DistributionCenterLossesView.Columns.Count - 1;
            ReportHelper.MarkCriticalRow(DistributionCenterLossesView.Rows, lastColumn);
        }
    }
}