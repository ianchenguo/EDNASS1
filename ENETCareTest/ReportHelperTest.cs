using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using ENETCare.Presentation;
using ENETCare.Presentation.App_Code;
using System.Collections;


namespace ENETCareTest
{
    [TestClass]
    public class ReportHelperTest
    {
        [TestMethod]
        public void CalculateTotalValue_TwoRowsWithTheThirdCellUseful_ShouldCalculateTheResult()
        {
            //prepares mock data
            string[,] mockRowValues = new string[,] { { "", "", "99.99" }, { "", "", "299.99" } };
            var mockRows = new ArrayList();
            GridViewRowCollection mockRowCollection;

            for (int i = 0; i < mockRowValues.GetLength(0); i++)
            {
                //instantiates grid view rows
                GridViewRow tempRow = new GridViewRow(i, i,
                    DataControlRowType.DataRow, DataControlRowState.Normal);

                for (int j = 0; j < mockRowValues.GetLength(1); j++)
                {
                    //instantiates cells, populates them and puts them in current row
                    TableCell tempCell = new TableCell();
                    tempCell.Text = mockRowValues[i, j];
                    tempRow.Cells.Add(tempCell);
                }
                //adds current row in a mock row collection
                mockRows.Add(tempRow);
            }
            mockRowCollection = new GridViewRowCollection(mockRows);

            //tests against assertion
            string totalValueLiteral = ReportHelper.CalculateTotalValue(mockRowCollection, 2);
            Assert.AreEqual(totalValueLiteral, "399.98");
        }

        [TestMethod]
        public void CalculateTotalValue_EmptyRow_ShouldReturnZero()
        {
            //prepares mock data
            GridViewRowCollection mockRowCollection;
            var mockRows = new ArrayList();
            mockRowCollection = new GridViewRowCollection(mockRows);
            //tests against assertion
            string totalValueLiteral = ReportHelper.CalculateTotalValue(mockRowCollection, 2);
            Assert.AreEqual(totalValueLiteral, "0");
        }

        [TestMethod]
        public void MarkCriticalRow_TwoRowsWIthTheSecondRowCritical_ShouldMarkTheSecondRowRed()
        {
            //prepares mock data
            string[,] mockRowValues = new string[,] { { "", "", "", "Low" }, { "", "", "", "High" }};
            var mockRows = new ArrayList();
            GridViewRowCollection mockRowCollection;

            for (int i = 0; i < mockRowValues.GetLength(0); i++)
            {
                //instantiates grid view rows
                GridViewRow tempRow = new GridViewRow(i, i,
                    DataControlRowType.DataRow, DataControlRowState.Normal);

                for (int j = 0; j < mockRowValues.GetLength(1); j++)
                {
                    //instantiates cells, populates them and puts them in current row
                    TableCell tempCell = new TableCell();
                    tempCell.Text = mockRowValues[i, j];
                    tempRow.Cells.Add(tempCell);
                }
                //adds current row in a mock row collection
                mockRows.Add(tempRow);
            }
            mockRowCollection = new GridViewRowCollection(mockRows);

            ReportHelper.MarkCriticalRow(mockRowCollection, 3);
            Assert.AreEqual(mockRowCollection[mockRowCollection.Count - 1].CssClass, "danger");
        }

        [TestMethod]
        public void MarkCriticalRow_EmptyRow_ShouldChangeNothing()
        {
            //prepares mock data
            GridViewRowCollection mockRowCollection;
            var mockRows = new ArrayList();
            mockRowCollection = new GridViewRowCollection(mockRows);
            //tests against assertion
            ReportHelper.MarkCriticalRow(mockRowCollection, 3);
            Assert.AreEqual(mockRows.Count, 0);
        }
    }
}
