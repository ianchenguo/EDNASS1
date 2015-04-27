using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace ENETCareTest
{
    [TestClass]
    public class MedicationPackageDAOTest
    {


        [TestMethod]
        public void MedicationPackageDAO_InsertPackage_Test()
        {
            DateTime dt = new DateTime(2015,6,20);
            MedicationType type = new MedicationType();
            type.ID = 1;

            DistributionCentre dc1 = new DistributionCentre();
            dc1.ID = 2;
            MedicationPackage actualpackage = new MedicationPackage();

            actualpackage.Barcode = "4564561323";
            actualpackage.Type = type;
            actualpackage.Type.ID = type.ID;
            actualpackage.ExpireDate = dt;
            actualpackage.Status = PackageStatus.InStock;

            actualpackage.StockDC = dc1;
            actualpackage.StockDC.ID = dc1.ID;
            actualpackage.Operator = "dabeige@gmail.com";
            
            
            
                DAOFactory.GetMedicationPackageDAO().InsertPackage(actualpackage);


                MedicationPackage actual = DAOFactory.GetMedicationPackageDAO().FindPackageByBarcode("4564561323");


                Assert.IsNotNull(actual);
                Assert.IsInstanceOfType(actual, typeof(MedicationPackage));
                Assert.AreEqual("dabeige@gmail.com", actual.Operator);
            
           
            
        }

        [TestMethod]
        public void MedicationPackageDAO_UpdatePackage_Test()
        {
            NumberOfRow_Medicationpackagetype num = new NumberOfRow_Medicationpackagetype();
            MedicationPackage pk2 = new MedicationPackage();
            DistributionCentre dc2 = new DistributionCentre();
            dc2.ID =2;
            DistributionCentre dc3 = new DistributionCentre();
            dc3.ID =3;
            DistributionCentre dc1 = new DistributionCentre();
            dc1.ID =1;

            pk2.ID = num.CountTableRow();//only update the last row which is latest inserted.
            pk2.Status = PackageStatus.InTransit;
            pk2.StockDC = dc2;
            pk2.StockDC.ID = dc2.ID;
            pk2.SourceDC = dc3;
            pk2.SourceDC.ID = dc3.ID;
            pk2.DestinationDC = dc1;
            pk2.DestinationDC.ID = dc1.ID;
            pk2.Operator = "xiaobeige@gmail.com";

            DAOFactory.GetMedicationPackageDAO().UpdatePackage(pk2);

            MedicationPackage actual = DAOFactory.GetMedicationPackageDAO().FindPackageByBarcode("4564561323");// cater to each one's datase.


            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(MedicationPackage));
            Assert.AreEqual("xiaobeige@gmail.com", actual.Operator);
           
        }

        [TestMethod]
        public void MedicationPackageDAO_FindAllPackages_Test() 
        {

            List<MedicationPackage> actuallist = DAOFactory.GetMedicationPackageDAO().FindAllPackages();
            NumberOfRow_Medicationpackagetype num = new NumberOfRow_Medicationpackagetype();

            Assert.IsNotNull(actuallist);
            Assert.IsInstanceOfType(actuallist, typeof(List<MedicationPackage>));
            Assert.AreEqual(num.CountTableRow(), actuallist.Count); 

        }

        [TestMethod]
        public void MedicationPackageDAO_FindPackagesInDistributionCentre_Test()
        {
            List<MedicationPackage> expectlist = DAOFactory.GetMedicationPackageDAO().FindInStockPackagesInDistributionCentre(1,2);
            
            Assert.IsNotNull(expectlist);
            Assert.IsInstanceOfType(expectlist, typeof(List<MedicationPackage>));
            Assert.AreEqual("635653153630457788", expectlist[0].Barcode); 


        }

        [TestMethod]
        public void MedicationPackageDAO_FindPackageByBarcode_Test()
        {


            MedicationPackage expect = DAOFactory.GetMedicationPackageDAO().FindPackageByBarcode("635651520075378996");


            Assert.IsNotNull(expect);
            Assert.IsInstanceOfType(expect, typeof(MedicationPackage));
            Assert.AreEqual("doctor@dkk.com", expect.Operator);
        }
  
    }

    public class NumberOfRow_Medicationpackagetype
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
                string query = @"select * from  MedicationPackage";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(ds, "MedicationPackage");
                    adapter.Dispose();
                    NumberOfRow = ds.Tables[0].Rows.Count;

                }

            }
            return NumberOfRow;
        }

    }
}
