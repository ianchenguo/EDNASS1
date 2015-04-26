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

            //GridViewRowCollection rowsCollection = AgentDoctorReportStockTakingGV.Rows;
            //GridViewRow row = rowsCollection[1];
            //string rowContent1 = row.Cells[0].Text;
            //string rowContent4 = row.Cells[4].Text;
            //int RowCount = AgentDoctorReportStockTakingGV.Rows.Count;
            //int ColumnsCount = AgentDoctorReportStockTakingGV.Columns.Count;
            //string ContentStr0 = AgentDoctorReportStockTakingGV.Columns[0].AccessibleHeaderText;
            //string ContentStr1 = AgentDoctorReportStockTakingGV.Columns[0].HeaderText;
            //string ContentStr2 = AgentDoctorReportStockTakingGV.Columns[0].FooterText;
            //string cao0 = rowsCollection.Count.ToString();
            //string rowWord = row.Cells[0].Attributes["Text"];
            //"lbDelete"
            //AgentDoctorReportStockTakingGV.Rows[0].Cells[0].Visible.Equals(false);

            //string cao = AgentDoctorReportStockTakingGV.Rows[0].TemplateControl.ToString();

            //Debug.WriteLine("\nColumnsCount is -- " + ColumnsCount + " RowCount " + RowCount);
            //Debug.WriteLine("\nRow 1 Cell 0 is -- " + rowContent1);
            //Debug.WriteLine("\nRow 1 Cell 4 is -- " + rowContent4);

            //Debug.WriteLine("\nAccessibleHeaderText is " + ContentStr0 + " HeaderText: " + ContentStr1 + " FooterText " + ContentStr2);
            //Debug.WriteLine(" 0  0 is -- "+cao);
            //Debug.WriteLine("\n attribute: "+rowWord);
            
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
            //Debug.WriteLine("\nLocalRow ExpiredStatus is: --\n" + ExpiredStatusStrLocalRow);
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
        
    }
}