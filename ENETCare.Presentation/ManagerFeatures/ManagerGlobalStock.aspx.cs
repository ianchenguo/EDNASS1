using ENETCare.Presentation.HelperUtilities;
using ENETCare.Presentation.ManagerFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.Presentation.ManagerFeatures
{
    public partial class ManagerGlobalStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GlobalStockView_DataBound(object sender, EventArgs e)
        {
            int lastColumn = GlobalStockView.Columns.Count - 1;
            TotalValueLiteral.Text = ReportHelper.CalculateTotalValue(GlobalStockView.Rows, lastColumn);
        }
    }
}