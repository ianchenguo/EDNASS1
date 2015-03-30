using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.GUI.Mockup
{
	public partial class SendingMockup : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (DistributionCentreDropDownList.Items.Count <= 1)
			{
				DistributionCentreDropDownList.Items.Add(new ListItem("Liverpool Office", "1"));
				DistributionCentreDropDownList.Items.Add(new ListItem("Glebe Office", "2"));
				DistributionCentreDropDownList.Items.Add(new ListItem("Ultimo Office", "3"));
			}
		}

		protected void SendButton_Click(object sender, EventArgs e)
		{
			string distributionCentre = DistributionCentreDropDownList.SelectedValue;
			string barcode = BarcodeTextBox.Text;
            
			Employee.LoginUser().DistributionCentre.SendPackage(barcode, distributionCentre);
		}

        protected void DistributionCentreDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}