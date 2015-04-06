using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ENETCare.Business;

namespace ENETCareTest
{
    [TestClass]
    public class EmployeeDAOTest
    {
        [TestInitialize]
        public void Setup()
        {
         Employee employee = new Employee();
        }


        [TestMethod]
        public void FindEmployeeByUserName_Test()
        {
            var employeeone = new Mock<EmployeeDAO>();
            employeeone.Setup(x => x.FindEmployeeByUserName("jeff")).Returns(new Employee());
            employeeone.Object.FindEmployeeByUserName("jeff");
            Assert.AreNotSame(new Employee(), employeeone.Object.FindEmployeeByUserName("jeff"));
        }
    }
}
