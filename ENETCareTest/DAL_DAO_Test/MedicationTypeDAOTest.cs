using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;
using System.Configuration;
using System.Collections.Generic;
using Moq;
using System.Data.SqlClient;
using System.Linq;
using System.Data;

namespace ENETCareTest.DAL_DAO_Test
{
    [TestClass]
    public class MedicationTypeDAOTest
    {


        [TestMethod]
        public void MedicationTypeDAO_FindAllMedicationTypes_Test()
        {
            List<MedicationType> expectlist = DAOFactory.GetMedicationTypeDAO().FindAllMedicationTypes();
            NumberOfRow_MedicationType num = new NumberOfRow_MedicationType();

            Assert.AreEqual(num.CountTableRow(), expectlist.Count);
            Assert.IsNotNull(expectlist);
            Assert.IsInstanceOfType(expectlist, typeof(List<MedicationType>));
            Assert.AreEqual("100 polio vaccinations", expectlist[0].Name); 
        }


        [TestMethod]
        public void MedicationTypeDAO_GetMedicationTypeById_Test()
        {

            MedicationType actual = DAOFactory.GetMedicationTypeDAO().GetMedicationTypeById(2);

            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(MedicationType));
            Assert.AreEqual("box of 500 x 28 pack chloroquine pills", actual.Name);
            Assert.AreEqual(730, actual.ShelfLife);
            Assert.AreEqual(3000, actual.Value);
            Assert.AreEqual(false, actual.IsSensitive);

        }
        
    }

    public class NumberOfRow_MedicationType
    {
        public int CountTableRow()
        {
            int NumberOfRow = 0;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataReaderDAO dr = new DataReaderDAO();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = dr.ConnectionString; 
                conn.Open();
                string query = @"select * from  MedicationType";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(ds, "MedicationType");
                    adapter.Dispose();
                    NumberOfRow = ds.Tables[0].Rows.Count;

                }

            }
            return NumberOfRow;
        }

    }
}
