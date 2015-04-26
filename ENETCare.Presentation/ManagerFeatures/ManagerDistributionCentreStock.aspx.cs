using ENETCare.Business;
using ENETCare.Presentation.HelperUtilities;
using ENETCare.Presentation.Layout;
using ENETCare.Presentation.ManagerFeatures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ENETCare.Presentation.ManagerFeatures
{
    public partial class ManagerDistributionCentreStock : System.Web.UI.Page
    {
        private Features baseMasterPage;
        /// <summary>
        /// On page load, retrive current centre name from query string,
        /// and populates it to the heading text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            HeadingLiteral.Text = Request.QueryString["centrename"];
            baseMasterPage = Page.Master.Master as Features;
        }

        /// <summary>
        /// On data bound event of the distribution centre stock view, 
        /// calculates total of each entry's value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DistributionCentreStockView_DataBound(object sender, EventArgs e)
        {
            int lastColumn = DistributionCentreStockView.Columns.Count - 1;
            TotalValueLiteral.Text = ReportHelper.CalculateTotalValue(DistributionCentreStockView.Rows, lastColumn);
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