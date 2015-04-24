using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;
using ENETCare.Presentation.HelperUtilities;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ENETCare.Presentation.AgentDoctorFeatures
{
    public partial class AgentDoctorViewReport : System.Web.UI.Page
    {
        private MedicationPackageBLL AgentDoctorReportStockTaking;
        protected void Page_Load(object sender, EventArgs e)
        {
            AgentDoctorReportStockTaking = new MedicationPackageBLL(User.Identity.Name);
            if(!IsPostBack)
            {
                this.AgentDoctorReportStockTakeDataBind();
            }
        }
        private void AgentDoctorReportStockTakeDataBind()
        {
            AgentDoctorReportStockTakingGV.DataSource = AgentDoctorReportStockTaking.Stocktake();
            AgentDoctorReportStockTakingGV.DataBind();
        }

        protected void AgentDoctorReportStockTakingGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                AgentDoctorReportStockTaking.DiscardPackage(e.CommandArgument.ToString());
                this.AgentDoctorReportStockTakeDataBind();
            }
        }

        protected void AgentDoctorReportStockTakingGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AgentDoctorReportStockTakingGV.PageIndex = e.NewPageIndex;
            this.AgentDoctorReportStockTakeDataBind();
        }

        protected void AgentDoctorReportStockTakingGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string expiredStatus1 = AgentDoctorReportStockTakingGV.SelectedRow.Cells[0].Text;
            string expiredStatus2 = AgentDoctorReportStockTakingGV.SelectedRow.Cells[1].Text;

            Response.Write(expiredStatus1);
            Response.Write(expiredStatus2);
        }
    }
}