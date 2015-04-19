using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using ENETCare.Business;

namespace ENETCare.Presentation.AgentFeatures
{
    public partial class TestAgent : System.Web.UI.Page
    {
        private MedicationPackageBLL AgentTestStockTaking;
        protected void Page_Load(object sender, EventArgs e)
        {
            AgentTestStockTaking = new MedicationPackageBLL("LoginUserName");
            AgentTestGV.DataSource = AgentTestStockTaking.Stocktake();
            AgentTestGV.DataBind();
        }
    }
}