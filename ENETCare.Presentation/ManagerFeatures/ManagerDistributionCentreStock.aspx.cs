using ENETCare.Business;
using ENETCare.Presentation.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ENETCare.Presentation.Logic
{
    public partial class ManagerDistributionCentreStock : System.Web.UI.Page
    {
        /// <summary>
        /// On page load, retrive current centre name from query string,
        /// and populates it to the heading text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            HeadingLiteral.Text = Request.QueryString["centrename"];
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
    }
}