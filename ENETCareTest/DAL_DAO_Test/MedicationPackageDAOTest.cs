using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ENETCareTest
{
    [TestClass]
    public class MedicationPackageDAOTest
    {
        MedicationPackage package = new MedicationPackage();
        MedicationType medicationtype1 = new MedicationType();
        DistributionCentre dc1 = new DistributionCentre();
        DistributionCentre dc2 = new DistributionCentre();
        DistributionCentre dc3 = new DistributionCentre();
        DistributionCentre dc4 = new DistributionCentre();
        DistributionCentre dc5 = new DistributionCentre();
        DistributionCentre dc6 = new DistributionCentre();
        DateTime data1 = new DateTime(2014, 6, 14, 6, 32, 0);
        DateTime data2 = new DateTime(2014, 8, 14, 6, 32, 0);
        DateTime data3 = new DateTime(2014, 9, 14, 6, 32, 0);
        DateTime data4 = new DateTime(2014, 9, 15, 16, 32, 0);

        private MedicationPackageDAO MedicationPackageDAO;

        public MedicationPackageDAOTest()
        {
           Mock<MedicationPackageDAO> medicationpackageDao = new Mock<MedicationPackageDAO>();
           List<MedicationPackage> medicationpackages = new List<MedicationPackage>
           {
             new MedicationPackage {ID = 1,Barcode = "454898798798",Type = medicationtype1,ExpireDate = data1,Status = PackageStatus.InStock,StockDC = dc1,SourceDC = dc2,DestinationDC = dc3,UpdateTime = data2,Operator = "adam" },
             new MedicationPackage {ID = 2,Barcode = "454564564654",Type = medicationtype1,ExpireDate = data1,Status = PackageStatus.InTransit,StockDC = dc4,SourceDC = dc2,DestinationDC = dc3,UpdateTime = data3,Operator = "jeff" },
             new MedicationPackage {ID = 3,Barcode = "848949846541",Type = medicationtype1,ExpireDate = data1,Status = PackageStatus.InStock,StockDC = dc1,SourceDC = dc2,DestinationDC = dc3,UpdateTime = data4,Operator = "allan" }
           };

           Mock<MedicationPackageDAO> medicationpackagedao = new Mock<MedicationPackageDAO>();

           medicationpackagedao.Setup(x => x.FindAllPackages()).Returns(medicationpackages);

           medicationpackagedao.Setup(x => x.FindPackageByBarcode(It.IsAny<string>())).Returns((string s) => medicationpackages.Where(a => a.Barcode == s).Single());

           this.MedicationPackageDAO = medicationpackagedao.Object;
        }
        

        [TestMethod]
        public void InsertPackage_Test()
        {
            //var insert = new Mock<MedicationPackageDAO>();
            //insert.Setup(x => x.InsertPackage(It.IsAny<MedicationPackage>()));
            //insert.Object.InsertPackage(package);
            //insert.Verify();//check if the method has been called
        }

        [TestMethod]
        public void UpdatePackage_Test()
        {
            //var update = new Mock<MedicationPackageDAO>();
            //update.Setup(x => x.UpdatePackage(It.IsAny<MedicationPackage>()));
            //update.Object.UpdatePackage(package);
            //update.Verify();//check if the method has been called
        }

        [TestMethod]
        public void MedicationPackageDAO_FindAllPackages_Test() 
        {
            //test return value of FindAllPackages
            //var findlist = new Mock<MedicationPackageDAO>();
            //findlist.Setup(x => x.FindAllPackages()).Returns(new List<MedicationPackage>());//problem???
            //findlist.Object.FindAllPackages();
            //Assert.IsNotNull(findlist.Object.FindAllPackages());
            List<MedicationPackage> result = this.MedicationPackageDAO.FindAllPackages();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);

        }

        [TestMethod]
        public void MedicationPackageDAO_FindPackagesInDistributionCentre_Test()
        {
            
            //var findp = new Mock<MedicationPackageDAO>();
            //findp.Setup(x => x.FindPackagesInDistributionCentre(distributionCentreId)).Returns(new List<MedicationPackage>());
            //findp.Object.FindPackagesInDistributionCentre(distributionCentreId);
            //Assert.AreNotSame(new List<MedicationPackage>(), findp.Object.FindPackagesInDistributionCentre(distributionCentreId));
        }

        [TestMethod]
        public void MedicationPackageDAO_FindPackageByBarcode_Test()
        {
            
            //var findpb = new Mock<MedicationPackageDAO>();
            //findpb.Setup(x => x.FindPackageByBarcode(barcode)).Returns(null);
            //findpb.Object.FindPackageByBarcode(barcode);
            //Assert.IsNull(findpb.Object.FindPackageByBarcode(barcode));

            MedicationPackage findmedicationpackage = this.MedicationPackageDAO.FindPackageByBarcode("848949846541");


            Assert.IsNotNull(findmedicationpackage);
            Assert.IsInstanceOfType(findmedicationpackage, typeof(MedicationPackage));
            Assert.AreEqual(3, findmedicationpackage.ID);
        }
  
    }
}
