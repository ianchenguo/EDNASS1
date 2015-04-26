using ENETCare.Presentation.HelperUtilities;
using ENETCare.Presentation.Layout;
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
        private Features baseMasterPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            baseMasterPage = Page.Master.Master as Features;
        }

        protected void GlobalStockView_DataBound(object sender, EventArgs e)
        {
            int lastColumn = GlobalStockView.Columns.Count - 1;
            TotalValueLiteral.Text = ReportHelper.CalculateTotalValue(GlobalStockView.Rows, lastColumn);
        }

        protected void GlobalStockSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                baseMasterPage.ConfigureAlertBox(
                    true,
                    AlertBoxHelper.AlertType.Error.ToString(),
                    AlertBoxHelper.ALERT_STYLE_DANGER,
                    e.Exception.Message.ToString()
                    );

                e.ExceptionHandled = true;
            }

            else
            {
                baseMasterPage.ConfigureAlertBox(
                    true,
                    AlertBoxHelper.ALERT_STYLE_SUCCESS,
                    AlertBoxHelper.AlertType.Success.ToString(),
                    "Report is fetched"
                    );
            }
        }
    }
}