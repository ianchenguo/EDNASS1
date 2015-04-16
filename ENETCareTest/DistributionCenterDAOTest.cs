using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;
using System.Configuration;
using System.Collections.Generic;
using Moq;
using System.Data.SqlClient;

namespace ENETCareTest
{
    [TestClass]
    public class DistributionCenterDAOTest
    {
        DistributionCentreDataReaderDAO discenterdao;
        DistributionCentre discenter;

        [TestInitialize]
        public void Setup()
        {
            discenterdao = new DistributionCentreDataReaderDAO();
            discenter = new DistributionCentre();
            List<DistributionCentre> distributionCentreList = new List<DistributionCentre>();
        }


        //[TestMethod]
        //public void ConString_CanBeReach()
        //{

        //    string actualstring = DBSchema.ConnectionString;
        //    string expectedstring = ConfigurationManager.ConnectionStrings["MockupConnection"].ConnectionString;
        //    Assert.AreEqual(expectedstring, actualstring);
        //}

        [TestMethod]
        public void FindAllDistributionCentres_TestMethod() 
        {
            //test return value of FindAllDistributionCentres
            var list = new Mock<DistributionCentreDAO>();
            list.Setup(x => x.FindAllDistributionCentres()).Returns(new List<DistributionCentre>());//problem???
            list.Object.FindAllDistributionCentres();
            Assert.IsNotNull(list.Object.FindAllDistributionCentres());
        }

        [TestMethod]
        public void GetDistributionCentreByID_TestMethod() 
        {
            //test if return value of the GetDistributionCentreByID method
            var DcDAOmock1 = new Mock<DistributionCentreDAO>();
            //DcDAOmock1.Setup(p => p.GetDistributionCentreByID(1)).Returns(new DistributionCentre());

            //DcDAOmock1.Object.GetDistributionCentreByID(1);
            //Assert.AreNotSame(new DistributionCentre(), DcDAOmock1.Object.GetDistributionCentreByID(1));
        }
        

    }
}
