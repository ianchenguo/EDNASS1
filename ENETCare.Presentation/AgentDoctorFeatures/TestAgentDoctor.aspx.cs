using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using ENETCare.Business;

namespace ENETCare.Presentation.AgentDoctorFeatures
{
    public partial class TestAgentDoctor : System.Web.UI.Page
    {
        private MedicationPackageBLL AgentDoctorTestStockTaking;
        protected void Page_Load(object sender, EventArgs e)
        {
            AgentDoctorTestStockTaking = new MedicationPackageBLL("LoginUserName");
            this.BindStockTakingDataSource();
        }

        protected void AgentDoctorTestGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                AgentDoctorTestStockTaking.DiscardPackage(e.CommandArgument.ToString());
                this.BindStockTakingDataSource();
            }
        }

        private void BindStockTakingDataSource()
        {
            AgentDoctorTestGV.DataSource = AgentDoctorTestStockTaking.Stocktake();
            AgentDoctorTestGV.DataBind();
        }
    }
}