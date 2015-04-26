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
    public partial class ManagerDoctorActivity : System.Web.UI.Page
    {
        private Features baseMasterPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            HeadingLiteral.Text = Request.QueryString["fullname"];
            baseMasterPage = Page.Master.Master as Features;

        }

        protected void DoctorActivityView_DataBound(object sender, EventArgs e)
        {
            int lastColumn = DoctorActivityView.Columns.Count - 1;
            TotalValueLiteral.Text = ReportHelper.CalculateTotalValue(DoctorActivityView.Rows, lastColumn);
        }

        protected void CentreStockSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
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