using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.Presentation.DoctorFeatures
{
    public partial class DoctorRegisterPackage : System.Web.UI.Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL("LoginUserName");
            if (!Page.IsPostBack)
            {
                DoctorRegisterPackageTypeDropDownList.DataSource = new MedicationTypeBLL().GetMedicationTypeList();
                DoctorRegisterPackageTypeDropDownList.DataTextField = "Name";
                DoctorRegisterPackageTypeDropDownList.DataValueField = "ID";
                DoctorRegisterPackageTypeDropDownList.DataBind();
            }
        }

        protected void DoctorRegisterButton_Click(object sender, EventArgs e)
        {
            string medicationType = DoctorRegisterPackageTypeDropDownList.SelectedValue;
            string expireDate = DoctorRegisterPackageFormExpireDateTextBox.Text;
            try
            {
                medicationPackageBLL.RegisterPackage(Convert.ToInt32(medicationType), expireDate);
                Response.Redirect("IndexMockup.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            }
        }
    }
}