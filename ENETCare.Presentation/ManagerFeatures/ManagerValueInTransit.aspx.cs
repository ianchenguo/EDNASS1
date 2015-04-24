using ENETCare.Presentation.HelperUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.Presentation.ManagerFeatures
{
    public partial class ManagerValueInTransit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ValueInTransitView_DataBound(object sender, EventArgs e)
        {
            int lastColumn = ValueInTransitView.Columns.Count - 1;
            TotalValueLiteral.Text = ReportHelper.CalculateTotalValue(ValueInTransitView.Rows, lastColumn);
        }
    }
}