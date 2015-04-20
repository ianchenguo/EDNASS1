using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.Presentation.AgentFeatures
{
    public partial class AgentViewReport : System.Web.UI.Page
    {
        private MedicationPackageBLL AgentReportStockTaking;
        protected void Page_Load(object sender, EventArgs e)
        {
            AgentReportStockTaking = new MedicationPackageBLL(User.Identity.Name);
            if(!IsPostBack)
            {
                this.AgentReportStockTakeDataBind();
            }
        }
        private void AgentReportStockTakeDataBind()
        {
            AgentReportStockTakingGV.DataSource = AgentReportStockTaking.Stocktake();
            AgentReportStockTakingGV.DataBind();
        }

        protected void AgentReportStockTakingGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                AgentReportStockTaking.DiscardPackage(e.CommandArgument.ToString());
                this.AgentReportStockTakeDataBind();
            }
        }
    }
}