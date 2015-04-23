using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace ENETCare.Presentation.App_Code
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
    }

}
