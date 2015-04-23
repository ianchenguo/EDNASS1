using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ENETCare.Business;
using System.Collections.Generic;
using System.Linq;

namespace ENETCareTest
{   
    [TestClass]
    public class EmployeeDAOTest
    {
        

        private EmployeeDAO EmployeeDao;
        
        public EmployeeDAOTest()
        {
         Employee employee = new Employee();
         DistributionCentre dc1 = new DistributionCentre();
         DistributionCentre dc2 = new DistributionCentre();
         DistributionCentre dc3 = new DistributionCentre();
         
         List<Employee> employees = new List<Employee> 
         { 
           new Employee{ID = "1",Username = "1",Fullname = "1a",Email = "1@1.com",Role = Role.Doctor,DistributionCentre = dc1},
           new Employee{ID = "2",Username = "2",Fullname = "2a",Email = "2@1.com",Role = Role.Agent,DistributionCentre = dc2},
           new Employee{ID = "3",Username = "3",Fullname = "3a",Email = "3@1.com",Role = Role.Manager,DistributionCentre = dc1}
         };

         Employee employee1 = new Employee { ID = "4", Username = "4", Fullname = "4a", Email = "4@1.com", Role = Role.Doctor, DistributionCentre = dc1 };

         Mock<EmployeeDAO> employeeDao = new Mock<EmployeeDAO>();
        

         //return list contain all employees
         employeeDao.Setup(x => x.FindAllEmployees()).Returns(employees);
         //return employee with centain username
         employeeDao.Setup(x => x.GetEmployeeByUserName(It.IsAny<string>())).Returns((string s) => employees.Where(i => i.Username == s).Single());

         this.EmployeeDao = employeeDao.Object;
        }


        [TestMethod]
        public void EmployeeDAO_FindEmployeeByUserName_Test()
        {
            var employeeone = new Mock<EmployeeDAO>();
            employeeone.Setup(x => x.GetEmployeeByUserName("jeff")).Returns(new Employee());
            employeeone.Object.GetEmployeeByUserName("jeff");
            Assert.AreNotSame(new Employee(), employeeone.Object.GetEmployeeByUserName("jeff"));
            

        }

        [TestMethod]
        public void EmployeeDAO_FindAllEmployees_Test() 
        {
            List<Employee> result = this.EmployeeDao.FindAllEmployees();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
          
        }

        [TestMethod]
        public void EmployeeDAO_GetEmployeeByUserName_Test()
        {
            Employee findemployee = this.EmployeeDao.GetEmployeeByUserName("2");


            Assert.IsNotNull(findemployee);
            Assert.IsInstanceOfType(findemployee, typeof(Employee));
            Assert.AreEqual("2", findemployee.ID); //verify if it's the right product 

        }
        
    }
}
