using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.Presentation.AgentDoctorFeatures
{
    public partial class AgentDoctorSendPackage : System.Web.UI.Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL(User.Identity.Name);
            if (!Page.IsPostBack)
            {
                AgentDoctorSendingDropDownList.DataSource = new DistributionCentreBLL().GetDistributionCentreList();
                AgentDoctorSendingDropDownList.DataTextField = "Name";
                AgentDoctorSendingDropDownList.DataValueField = "ID";
                AgentDoctorSendingDropDownList.DataBind();
                //this.GridViewDataBind();
            }
            AgentDoctorSendPackageDateTextBox.Text = DateTime.Now.ToShortDateString();
        }

        //private void GridViewDataBind()
        //{
        //    SmpGV.DataSource = medicationPackageBLL.Stocktake();
        //    SmpGV.DataBind();
        //}

        protected void AgentDoctorSendPackageTypeButton_Click(object sender, EventArgs e)
        {
            string distributionCentre = AgentDoctorSendingDropDownList.SelectedValue;
            string AgentDoctorSendBarcode = AgentDoctorSendPackageTypebarcode.Text;
            try
            {
                medicationPackageBLL.SendPackage(AgentDoctorSendBarcode, Convert.ToInt32(distributionCentre));
                //Response.Redirect("AgentDoctorHome.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            }
        }

        

        //protected void ASsendingBTN_Click(object sender, EventArgs e)
        //{
        //    string AgentDoctorSelectedDistributionCenter = AgentDoctorSendingDropDownList.SelectedValue;
        //    string barcode = ASbarcode.Text;
        //    Console.WriteLine(AgentDoctorSelectedDistributionCenter, barcode);
        //    //Employee.LoginUser().DistributionCentre.SendPackage(barcode, AgentDoctorSelectedDistributionCenter);
        //}

        
    }
}