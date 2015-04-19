using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.Presentation.DoctorFeatures
{
    public partial class DoctorViewReport : System.Web.UI.Page
    {
        private MedicationPackageBLL DoctorReportStockTakeData;
        protected void Page_Load(object sender, EventArgs e)
        {
            DoctorReportStockTakeData = new MedicationPackageBLL("LoginUserName");
            if(!IsPostBack)
            {
                this.DoctorReportDataBind();
            }
        }
        private void DoctorReportDataBind()
        {
            DoctorReportGV.DataSource = DoctorReportStockTakeData.Stocktake();
            DoctorReportGV.DataBind();
        }

        protected void DoctorReportGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                DoctorReportStockTakeData.DiscardPackage(e.CommandArgument.ToString());
                this.DoctorReportDataBind();
            }
        }

    }
}