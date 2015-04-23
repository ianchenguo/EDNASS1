using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.Presentation.ManagerFeatures
{
    public partial class ManagerDoctorActivityDoctors : System.Web.UI.Page
    {
        private EmployeeBLL employeeManager = new EmployeeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //retrives all employees from data source
            List<Employee> employees = employeeManager.GetEmployeeList();
            //filters out doctors
            IEnumerable<Employee> doctors =
                from d in employees
                where d.Role == Role.Doctor
                select d;

            if (!IsPostBack)
            {
                this.BindDoctorsViewData(doctors);
            }
        }

        private void BindDoctorsViewData(IEnumerable<Employee> doctors)
        {
            DoctorsView.DataSource = doctors;
            DoctorsView.DataBind();
        }
    }
}