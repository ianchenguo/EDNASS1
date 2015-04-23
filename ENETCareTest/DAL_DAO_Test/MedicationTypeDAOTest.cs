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
    public class MedicationTypeDAOTest
    {
        private MedicationTypeDAO MedicationTypeDAO;
        public MedicationTypeDAOTest() 
        {
            MedicationType mt1 = new MedicationType();
            
            List<MedicationType> medicationtypes = new List<MedicationType> 
            { 
               new MedicationType{ID = 1,Name = "1",Description = "follow doctor diagnostics",ShelfLife = 2, Value = 20, IsSensitive = true},// lack DefaultExpireDate property
               new MedicationType{ID = 2,Name = "2",Description = "heal fever",ShelfLife = 2, Value = 30, IsSensitive = false},
               new MedicationType{ID = 3,Name = "3",Description = "for cold",ShelfLife = 1, Value = 10, IsSensitive = true}
            };


            Mock<MedicationTypeDAO> medicationtypeDao = new Mock<MedicationTypeDAO>();


            //return list contain all Dcs
            medicationtypeDao.Setup(x => x.FindAllMedicationTypes()).Returns(medicationtypes);
            //return dc with centain id
            medicationtypeDao.Setup(x => x.GetMedicationTypeById(It.IsAny<int>())).Returns((int s) => medicationtypes.Where(i => i.ID == s).Single());

            this.MedicationTypeDAO = medicationtypeDao.Object;
        }


        [TestMethod]
        public void MedicationTypeDAO_FindAllMedicationTypes_Test()
        {
            List<MedicationType> result = this.MedicationTypeDAO.FindAllMedicationTypes();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }


        [TestMethod]
        public void MedicationTypeDAO_GetMedicationTypeById_Test()
        {
            
            MedicationType findmedicationtype = this.MedicationTypeDAO.GetMedicationTypeById(2);


            Assert.IsNotNull(findmedicationtype);
            Assert.IsInstanceOfType(findmedicationtype, typeof(MedicationPackage));
            Assert.AreEqual("2", findmedicationtype.Name);
        }
        
    }
}
