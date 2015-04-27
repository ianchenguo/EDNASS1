using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;
using System.Configuration;
using System.Collections.Generic;
using Moq;
using System.Data.SqlClient;
using System.Linq;
using ENETCare.Presentation;

namespace ENETCareTest
{
    [TestClass]
    public class DistributionCenterDAOTest
    {

        
        [TestMethod] 
        public void DistributionCentreDAO_FindAllDistributionCentres_Test() 
        {   
            //using (var scope = new TransactionScope())
            //{
            
            //}
            List<DistributionCentre> distributionscentres2 = DAOFactory.GetDistributionCentreDAO().FindAllDistributionCentres();
            List<DistributionCentre> actuallist = new List<DistributionCentre> 
            {
              new DistributionCentre {ID = 1, Name = "Liverpool Office", Address = "Macquarie Street, Liverpool NSW 2170", Phone = "96026633"},
              new DistributionCentre {ID = 2, Name = "Glebe Office", Address = "9-25 Derwent Street, Glebe NSW 2037", Phone = "96604549"},
              new DistributionCentre {ID = 3, Name = "Ultimo Office", Address = "15 Broadway, Ultimo NSW 2007", Phone = "95142000"}
            };

            Assert.AreEqual(3,distributionscentres2.Count);
            for (int i = 0, j = 0; i <= actuallist.Count - 1 && j <= distributionscentres2.Count - 1; i++, j++)
            {   
                Assert.IsNotNull(distributionscentres2[i]);

                Assert.AreEqual(actuallist[i].ID, distributionscentres2[j].ID);
     
            }

                
           
        }

        [TestMethod]
        public void DistributionCentreDAO_GetDistributionCentreById_Test() 
        {
            DistributionCentre result = DAOFactory.GetDistributionCentreDAO().GetDistributionCentreById(1);

            Assert.AreEqual(1,result.ID);
            Assert.AreEqual("Liverpool Office", result.Name);
            Assert.AreEqual("Macquarie Street, Liverpool NSW 2170", result.Address);
            Assert.AreEqual("96026633", result.Phone);

        }
        

    }

    
}
