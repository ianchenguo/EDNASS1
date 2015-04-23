using ENETCare.Presentation.App_Code;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            HeadingLiteral.Text = Request.QueryString["fullname"];
        }

        protected void DoctorActivityView_DataBound(object sender, EventArgs e)
        {
            int lastColumn = DoctorActivityView.Columns.Count - 1;
            TotalValueLiteral.Text = ReportHelper.CalculateTotalValue(DoctorActivityView.Rows, lastColumn);
        }
    }
}