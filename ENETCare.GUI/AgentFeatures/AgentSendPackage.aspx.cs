using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.GUI.AgentFeatures
{
    public partial class AgentSendPackage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AgentSendingDropDownList.Items.Count<=1)
            {
                AgentSendingDropDownList.Items.Add(new ListItem("Liverpool Office", "1"));
                AgentSendingDropDownList.Items.Add(new ListItem("Glebe Office", "2"));
                AgentSendingDropDownList.Items.Add(new ListItem("Ultimo Office", "3"));
            }
        }

        protected void ASsendingBTN_Click(object sender, EventArgs e)
        {
            string agentSelectedDistributionCenter = AgentSendingDropDownList.SelectedValue;
            string barcode = ASbarcode.Text;
            Console.WriteLine(agentSelectedDistributionCenter, barcode);
            //Employee.LoginUser().DistributionCentre.SendPackage(barcode, agentSelectedDistributionCenter);
        }

        protected void AgentSendingDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}