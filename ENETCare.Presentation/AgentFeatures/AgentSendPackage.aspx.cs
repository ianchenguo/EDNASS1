using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.Presentation.AgentFeatures
{
    public partial class AgentSendPackage : System.Web.UI.Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (AgentSendingDropDownList.Items.Count <= 1)
            //{
            //    AgentSendingDropDownList.Items.Add(new ListItem("Liverpool Office", "1"));
            //    AgentSendingDropDownList.Items.Add(new ListItem("Glebe Office", "2"));
            //    AgentSendingDropDownList.Items.Add(new ListItem("Ultimo Office", "3"));
            //}
            medicationPackageBLL = new MedicationPackageBLL("LoginUserName");
            if (!Page.IsPostBack)
            {
                AgentSendingDropDownList.DataSource = new DistributionCentreBLL().GetDistributionCentreList();
                AgentSendingDropDownList.DataTextField = "Name";
                AgentSendingDropDownList.DataValueField = "ID";
                AgentSendingDropDownList.DataBind();
            }
        }

        protected void AgentSendPackageTypeButton_Click(object sender, EventArgs e)
        {
            string distributionCentre = AgentSendingDropDownList.SelectedValue;
            string barcode = AgentSendPackageTypebarcode.Text;
            try
            {
                medicationPackageBLL.SendPackage(barcode, Convert.ToInt32(distributionCentre));
                Response.Redirect("IndexMockup.aspx");
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            }
        }

        //protected void ASsendingBTN_Click(object sender, EventArgs e)
        //{
        //    string agentSelectedDistributionCenter = AgentSendingDropDownList.SelectedValue;
        //    string barcode = ASbarcode.Text;
        //    Console.WriteLine(agentSelectedDistributionCenter, barcode);
        //    //Employee.LoginUser().DistributionCentre.SendPackage(barcode, agentSelectedDistributionCenter);
        //}

        
    }
}