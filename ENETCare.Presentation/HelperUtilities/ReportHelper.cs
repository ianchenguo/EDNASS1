using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ENETCare.Presentation.HelperUtilities
{
    public static class ReportHelper
    {

        public static string CalculateTotalValue(GridViewRowCollection rows, int cellPosition)
        {
            decimal totalValue = 0;
            foreach (GridViewRow row in rows)
            {
                decimal value = decimal.Parse(row.Cells[cellPosition].Text);
                totalValue += value;
            }

            return totalValue.ToString();
        }

        public static void MarkCriticalRow(GridViewRowCollection rows, int cellPosition)
        {
            foreach (GridViewRow row in rows)
            {
                string riskLevel = row.Cells[cellPosition].Text;
                if (riskLevel == "High")
                {
                    row.CssClass = "danger";
                }
            }
        }

        public static void AgentDoctorViewReportColourMark(GridViewRowCollection ReportGridViewRowsCollection)
        {
            for (int i = 0; i < ReportGridViewRowsCollection.Count; i++)
            {
                GridViewRow specificRow = ReportGridViewRowsCollection[i];
                AgentDoctorCssClassAdapterViewReportGVrow(specificRow);
            }
        }

        private static void AgentDoctorCssClassAdapterViewReportGVrow(GridViewRow GvSpecRow)
        {
            string cellFourStr = GvSpecRow.Cells[4].Text;
            //&& cellFourStr == "Expired"
            if (cellFourStr == "Expired")
            {
                GvSpecRow.CssClass = "AgentDoctorGVrowDanger";
            }
            //&& cellFourStr == "AboutToExpired"
            else if (cellFourStr == "AboutToExpired")
            {
                GvSpecRow.CssClass = "AgentDoctorGVrowWarning";
            }
        }
    }

}