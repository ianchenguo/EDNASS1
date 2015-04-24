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

        public static void AgentDoctorViewReportColourMark(List<string> expiredCondition, GridViewRowCollection ReportGridViewRowsCollection)
        {
            for(int i = 0; i<expiredCondition.Count; i++)
            {
                if (expiredCondition[i] == "Expired")
                {
                    ChooseDangerForAgentDoctorReport(i, ReportGridViewRowsCollection);
                }
                else if (expiredCondition[i] == "AboutToExpired")
                {
                    ChooseWarningForAgentDoctorReport(i, ReportGridViewRowsCollection);
                }
            }
        }

        private static void ChooseWarningForAgentDoctorReport(int i, GridViewRowCollection gvRowCollection)
        {
            gvRowCollection[i].CssClass = "orange";
        }

        private static void ChooseDangerForAgentDoctorReport(int i, GridViewRowCollection gvRowCollection)
        {
            gvRowCollection[i].CssClass = "danger";
        }
    }

}