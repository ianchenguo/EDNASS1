using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ENETCare.Business;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace ENETCareTest
{
    [TestClass]
    public class EmployeeDAOTest
    {


        [TestMethod]
        //not right
        public void EmployeeDAO_FindEmployeesByRole_Test()
        {
            //var employeeone = new Mock<EmployeeDAO>();
            //employeeone.Setup(x => x.GetEmployeeByUserName("jeff")).Returns(new Employee());
            //employeeone.Object.GetEmployeeByUserName("jeff");
            //Assert.AreNotSame(new Employee(), employeeone.Object.GetEmployeeByUserName("jeff"));

            List<Employee> expectlist = DAOFactory.GetEmployeeDAO().FindEmployeesByRole(Role.Agent);

            Assert.IsNotNull(expectlist);
            Assert.IsInstanceOfType(expectlist, typeof(List<Employee>));


        }

        [TestMethod]
        public void EmployeeDAO_FindAllEmployees_Test()
        {
            List<Employee> actuallist = DAOFactory.GetEmployeeDAO().FindAllEmployees();
            NumberOfRow num = new NumberOfRow();

            Assert.IsNotNull(actuallist);
            Assert.AreEqual(num.CountTableRow()-1, actuallist.Count);//num.CountTableRow() 16? 15? 

        }

        [TestMethod]
        public void EmployeeDAO_GetEmployeeByUserName_Test()
        {
            Employee actualuser = DAOFactory.GetEmployeeDAO().GetEmployeeByUserName("gcdoc12@a.com");


            Assert.IsNotNull(actualuser);
            Assert.IsInstanceOfType(actualuser, typeof(Employee));
            Assert.AreEqual("gcdoc12", actualuser.Fullname);

        }

        public class NumberOfRow
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
                    string query = @"select * from  AspNetUsers";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        adapter.SelectCommand = command;
                        adapter.Fill(ds, "AspNetUsers");
                        adapter.Dispose();
                        NumberOfRow = ds.Tables[0].Rows.Count;
                        
                    }
                    
                }
                return NumberOfRow;
            }

        }
    }
}
