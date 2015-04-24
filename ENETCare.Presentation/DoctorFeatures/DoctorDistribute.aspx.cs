using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.Presentation.DoctorFeatures
{
    public partial class DoctorDistribute : System.Web.UI.Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        protected void Page_Load(object Distributeer, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL(User.Identity.Name);
            if (!Page.IsPostBack)
            {
                DoctorDistributeDropDownList.DataSource = new DistributionCentreBLL().GetDistributionCentreList();
                DoctorDistributeDropDownList.DataTextField = "Name";
                DoctorDistributeDropDownList.DataValueField = "ID";
                DoctorDistributeDropDownList.DataBind();
                //this.GridViewDataBind();
            }
            DoctorDistributePackageDateTextBox.Text = DateTime.Now.ToShortDateString();
        }

        protected void DoctorDistributePackageTypeButton_Click(object Distributeer, EventArgs e)
        {
            string distributionCentre = DoctorDistributeDropDownList.SelectedValue;
            string DoctorDistributeBarcode = DoctorDistributePackageTypebarcode.Text;
            try
            {
                medicationPackageBLL.DistributePackage(DoctorDistributeBarcode, true);
                //Response.Redirect("AgentDoctorHome.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            }
        }
    }
}