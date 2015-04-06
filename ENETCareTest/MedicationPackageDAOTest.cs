using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;
using Moq;
using System.Collections.Generic;

namespace ENETCareTest
{
    [TestClass]
    public class MedicationPackageDAOTest
    {
        MedicationPackage package = new MedicationPackage();
        int distributionCentreId;
        string barcode;

        [TestInitialize]
        public void Setup()
        {
            
        }

        [TestMethod]
        public void InsertPackage_Test()
        {
            var insert = new Mock<MedicationPackageDAO>();
            insert.Setup(x => x.InsertPackage(It.IsAny<MedicationPackage>()));
            insert.Object.InsertPackage(package);
            insert.Verify();//check if the method has been called
        }

        [TestMethod]
        public void UpdatePackage_Test()
        {
            var update = new Mock<MedicationPackageDAO>();
            update.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>()));
            update.Object.UpdatePackage(package);
            update.Verify();//check if the method has been called
        }

        [TestMethod]
        public void FindAllPackages_Test() 
        {
            //test return value of FindAllPackages
            var findlist = new Mock<MedicationPackageDAO>();
            findlist.Setup(x => x.FindAllPackages()).Returns(new List<MedicationPackage>());//problem???
            findlist.Object.FindAllPackages();
            Assert.IsNotNull(findlist.Object.FindAllPackages());
        }

        [TestMethod]
        public void FindPackagesInDistributionCentre_Test()
        {
            
            var findp = new Mock<MedicationPackageDAO>();
            findp.Setup(x => x.FindPackagesInDistributionCentre(distributionCentreId)).Returns(new List<MedicationPackage>());
            findp.Object.FindPackagesInDistributionCentre(distributionCentreId);
            Assert.AreNotSame(new List<MedicationPackage>(), findp.Object.FindPackagesInDistributionCentre(distributionCentreId));
        }

        [TestMethod]
        public void FindPackageByBarcode_Test()
        {
            
            var findpb = new Mock<MedicationPackageDAO>();
            //findpb.Setup(x => x.FindPackageByBarcode(barcode)).Returns(null);
            findpb.Object.FindPackageByBarcode(barcode);
            Assert.IsNull(findpb.Object.FindPackageByBarcode(barcode));
        }
    }
}
