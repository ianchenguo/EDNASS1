using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;
using ENETCare.Presentation.HelperUtilities;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection;

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

            List<string> expiredStrCollection = new List<string>();

            foreach (object o in AgentDoctorReportStockTaking.Stocktake())
            {
                Type t = o.GetType();
                PropertyInfo p = t.GetProperty("ExpireStatus");
                object v = p.GetValue(o, null);
                string ExpiredStatueStr = v.ToString();
                //Response.Write(ExpiredStatueStr);
                expiredStrCollection.Add(ExpiredStatueStr);
                this.ColorMarkHelper(expiredStrCollection, AgentDoctorReportStockTakingGV);
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

        private void ColorMarkHelper(List<string> whetherExpired, GridView ReportGV)
        {
            ReportHelper.AgentDoctorViewReportColourMark(whetherExpired, ReportGV.Rows);
        }
        
    }
}