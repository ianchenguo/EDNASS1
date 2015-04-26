using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;
using ENETCare.Presentation.Layout;
using ENETCare.Presentation.HelperUtilities;

namespace ENETCare.Presentation.ManagerFeatures
{
    public partial class ManagerDoctorActivityDoctors : System.Web.UI.Page
    {
        private Features baseMasterPage;
        private EmployeeBLL employeeManager = new EmployeeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            baseMasterPage = Page.Master.Master as Features;
        }

        protected void DoctorSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                baseMasterPage.ConfigureAlertBox(
                    true,
                    AlertBoxHelper.AlertType.Error.ToString(),
                    AlertBoxHelper.ALERT_STYLE_DANGER,
                    e.Exception.Message.ToString()
                    );

                e.ExceptionHandled = true;
            }
        }
    }
}