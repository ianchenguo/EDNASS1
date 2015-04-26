using ENETCare.Presentation.HelperUtilities;
using ENETCare.Presentation.Layout;
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
        private Features baseMasterPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            baseMasterPage = Page.Master.Master as Features;

        }

        protected void ValueInTransitView_DataBound(object sender, EventArgs e)
        {
            int lastColumn = ValueInTransitView.Columns.Count - 1;
            TotalValueLiteral.Text = ReportHelper.CalculateTotalValue(ValueInTransitView.Rows, lastColumn);
        }

        protected void ValueInTransitSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
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