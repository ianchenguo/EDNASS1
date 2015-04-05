using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.Presentation.AgentFeatures
{
    public partial class AgentRegisterPackage : System.Web.UI.Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL("LoginUserName");
			if (!Page.IsPostBack)
			{
				AgentPackageRegisterPackageTypeDropDwonList.DataSource = new MedicationTypeBLL().GetMedicationTypeList();
				AgentPackageRegisterPackageTypeDropDwonList.DataTextField = "Name";
				AgentPackageRegisterPackageTypeDropDwonList.DataValueField = "ID";
				AgentPackageRegisterPackageTypeDropDwonList.DataBind();
			}
        }
        //protected void Submit(object sender, EventArgs e)
        //{
        //    //what's this for?
        //    if (IsValid)
        //    {
        //        var test = AgentRegisterButton.Text;
        //        //MedicationPackageBLL packageBUS = new MedicationPackageBLL();
        //        //packageBUS.RegisterPackage(NedPackageRegisterFormPackageType.Text, NedPackageRegisterFormExpireDate.Text);
        //    }
        //}

        protected void AgentRegisterButton_Click(object sender, EventArgs e)
        {
            string medicationType = AgentPackageRegisterPackageTypeDropDwonList.SelectedValue;
            string expireDate = NedPackageRegisterFormExpireDate.Text;
            try
            {
                medicationPackageBLL.RegisterPackage(Convert.ToInt32(medicationType), expireDate);
                Response.Redirect("AgentHome.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            }
        }
    }
}