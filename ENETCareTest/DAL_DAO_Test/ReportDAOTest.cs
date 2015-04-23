using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;
using System.Configuration;
using System.Collections.Generic;
using Moq;
using System.Data.SqlClient;
using System.Linq;

namespace ENETCareTest.DAL_DAO_Test
{
    [TestClass]
    public class ReportDAOTest
    {
        private ReportDAO ReportRep1;
        private ReportDAO ReportRep2;
        public ReportDAOTest() 
        {

            List<MedicationTypeViewData> medicationtypeviewdata_list = new List<MedicationTypeViewData>
            {
                new MedicationTypeViewData {Type = "collumn", Quantity = 3, Value = 10},
                new MedicationTypeViewData {Type = "collumn2", Quantity = 3, Value = 10}
            };

            List<ValueInTransitViewData> valueintransitviewdata_list = new List<ValueInTransitViewData>
            {
                new ValueInTransitViewData {FromDistributionCentre = "Ultimo office", ToDistributionCentre = "la trobe office", Packages = 3, Value = 5},
                new ValueInTransitViewData {FromDistributionCentre = "la trobe office", ToDistributionCentre = "Ultimo office", Packages = 1, Value = 6}
            };

            Mock<ReportDAO> reportDao1 = new Mock<ReportDAO>();
            Mock<ReportDAO> reportDao2 = new Mock<ReportDAO>();

            reportDao1.Setup(x => x.FindGlobalStock()).Returns(medicationtypeviewdata_list);

            reportDao2.Setup(x => x.FindAllValueInTransit()).Returns(valueintransitviewdata_list);
           
            this.ReportRep1 = reportDao1.Object;
            this.ReportRep2 = reportDao2.Object;
        }



        [TestMethod]
        public void ReportDAO_FindDistributionCentreStockByStatus_Test()
        {
        }
        [TestMethod]
        public void ReportDAO_FindGlobalStock_Test()
        {
            List<MedicationTypeViewData> result = this.ReportRep1.FindGlobalStock();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }
        [TestMethod]
        public void ReportDAO_FindDoctorActivityByUserName_Test()
        {
        }
        [TestMethod]
        public void ReportDAO_FindAllValueInTransit()
        {
            List<ValueInTransitViewData> result = this.ReportRep2.FindAllValueInTransit();
            Assert.IsNotNull(result);
            Assert.AreNotEqual(1, result.Count);
            Assert.AreEqual(2, result.Count);
        }
    }
}
