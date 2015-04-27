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
using ENETCare.Presentation.Layout;

namespace ENETCare.Presentation.AgentDoctorFeatures
{
    public partial class AgentDoctorViewReport : System.Web.UI.Page
    {
        private Features baseMasterPage;
        private MedicationPackageBLL AgentDoctorReportStockTaking;
        protected void Page_Load(object sender, EventArgs e)
        {
            AgentDoctorReportStockTaking = new MedicationPackageBLL(User.Identity.Name);
            if (!IsPostBack)
            {
                this.AgentDoctorReportStockTakeDataBind();
            }
            baseMasterPage = Page.Master.Master as Features;
            baseMasterPage.ConfigureAlertBox(false);

        }

        private void AgentDoctorReportStockTakeDataBind()
        {
            try
            {
                AgentDoctorReportStockTakingGV.DataSource = AgentDoctorReportStockTaking.Stocktake();

            }

            catch (ENETCareException ex)
            {
                handleMessage(AlertBoxHelper.AlertType.Error, AlertBoxHelper.ALERT_STYLE_DANGER, ex.Message.ToString());
            }

            AgentDoctorReportStockTakingGV.DataBind();
            this.isDeleteOrNotDeleteVisible();
            this.ExpiredStatusHidden();
        }


        private void handleMessage(AlertBoxHelper.AlertType alertType, string alertStyle, string alertContent)
        {
            baseMasterPage.ConfigureAlertBox(true, alertStyle, alertType.ToString(), alertContent);
        }

        private void ExpiredStatusHidden()
        {
            int GVrowsCount = AgentDoctorReportStockTakingGV.Rows.Count;
            int ColumnIndex = AgentDoctorReportStockTakingGV.HeaderRow.Cells.Count - 1;
            AgentDoctorReportStockTakingGV.HeaderRow.Cells[ColumnIndex].Visible = false;

            for (int i = 0; i < GVrowsCount; i++)
            {
                AgentDoctorReportStockTakingGV.Rows[i].Cells[ColumnIndex].Visible = false;
            }
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
        }

        protected void AgentDoctorReportStockTakingGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AgentDoctorReportStockTakingGV.PageIndex = e.NewPageIndex;
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

        protected void CancleADViewReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgentDoctorHome.aspx");
        }

    }
}