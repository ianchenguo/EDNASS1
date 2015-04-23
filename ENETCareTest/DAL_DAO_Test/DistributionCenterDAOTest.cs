using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;
using System.Configuration;
using System.Collections.Generic;
using Moq;
using System.Data.SqlClient;
using System.Linq;

namespace ENETCareTest
{
    [TestClass]
    public class DistributionCenterDAOTest
    {
        private DistributionCentreDAO DistributionCenterDAO;

        
        public DistributionCenterDAOTest()
        {
            
            

         List<DistributionCentre> distributioncentres = new List<DistributionCentre> 
         { 
           new DistributionCentre{ID = 1,Name = "1",Address = "203 George St,Syd",Phone = "0456816998"},
           new DistributionCentre{ID = 2,Name = "1",Address = "103 George St,Syd",Phone = "0456816458"},
           new DistributionCentre{ID = 3,Name = "1",Address = "03 George St,Syd",Phone = "0456886998"}
         };


            Mock<DistributionCentreDAO> distributionDao = new Mock<DistributionCentreDAO>();


            //return list contain all Dcs
            distributionDao.Setup(x => x.FindAllDistributionCentres()).Returns(distributioncentres);
            //return dc with centain id
            distributionDao.Setup(x => x.GetDistributionCentreById(It.IsAny<int>())).Returns((int s) => distributioncentres.Where(i => i.ID == s).Single());

            this.DistributionCenterDAO = distributionDao.Object;
        }


        //[TestMethod]
        //public void ConString_CanBeReach()
        //{

        //    string actualstring = DBSchema.ConnectionString;
        //    string expectedstring = ConfigurationManager.ConnectionStrings["MockupConnection"].ConnectionString;
        //    Assert.AreEqual(expectedstring, actualstring);
        //}
        
        [TestMethod]
        public void DistributionCentreDAO_FindAllDistributionCentres_Test() 
        {
            //test return value of FindAllDistributionCentres
            //var list = new Mock<DistributionCentreDAO>();
            //list.Setup(x => x.FindAllDistributionCentres()).Returns(new List<DistributionCentre>());//problem???
            //list.Object.FindAllDistributionCentres();
            //Assert.IsNotNull(list.Object.FindAllDistributionCentres());
            List<DistributionCentre> result = this.DistributionCenterDAO.FindAllDistributionCentres();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);

        }

        [TestMethod]
        public void DistributionCentreDAO_GetDistributionCentreById_Test() 
        {
            //test if return value of the GetDistributionCentreByID method
            //var DcDAOmock1 = new Mock<DistributionCentreDAO>();
            //DcDAOmock1.Setup(p => p.GetDistributionCentreByID(1)).Returns(new DistributionCentre());

            //DcDAOmock1.Object.GetDistributionCentreByID(1);
            //Assert.AreNotSame(new DistributionCentre(), DcDAOmock1.Object.GetDistributionCentreByID(1));

            DistributionCentre finddistributioncentre = this.DistributionCenterDAO.GetDistributionCentreById(1);


            Assert.IsNotNull(finddistributioncentre);
            Assert.IsInstanceOfType(finddistributioncentre, typeof(DistributionCentre));
            Assert.AreEqual("203 George St,Syd", finddistributioncentre.Address); //verify if it's the right product 
        }
        

    }
}
