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
using System.Diagnostics;

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
            //this.isDeleteOrNotDeleteVisible();
        }

        private void AgentDoctorReportStockTakeDataBind()
        {
            AgentDoctorReportStockTakingGV.DataSource = AgentDoctorReportStockTaking.Stocktake();
            AgentDoctorReportStockTakingGV.DataBind();
            this.isDeleteOrNotDeleteVisible();
        }

        private void isDeleteOrNotDeleteVisible()
        {
            GridViewRowCollection rowsCollection = AgentDoctorReportStockTakingGV.Rows;

            for (int i = 0; i < rowsCollection.Count; i++)
            {
                GridViewRow rowHere = rowsCollection[i];
                string rowFourExpiredStatus = rowHere.Cells[4].Text;
                if (rowFourExpiredStatus == "Expired")
                {
                    rowHere.Cells[0].Visible = true;
                }
                else
                {
                    rowHere.Cells[0].Text = "";
                }
            }
        }

        protected void AgentDoctorReportStockTakingGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                AgentDoctorReportStockTaking.DiscardPackage(e.CommandArgument.ToString());
                this.AgentDoctorReportStockTakeDataBind();
            }
            //Debug.WriteLine("\nLocalRow ExpiredStatus is: --\n" + ExpiredStatusStrLocalRow);
        }

        protected void AgentDoctorReportStockTakingGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AgentDoctorReportStockTakingGV.PageIndex = e.NewPageIndex;
            //this.isDeleteOrNotDeleteVisible();
            this.AgentDoctorReportStockTakeDataBind();
        }

        protected void AgentDoctorReportStockTakingGV_DataBound(object sender, EventArgs e)
        {
            this.ColorMarkHelper(AgentDoctorReportStockTakingGV);

        }

        private void ColorMarkHelper(GridView ReportGV)
        {
            ReportHelper.AgentDoctorViewReportColourMark(ReportGV.Rows);
        }
        
    }
}