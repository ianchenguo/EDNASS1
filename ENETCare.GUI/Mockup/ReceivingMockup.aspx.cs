﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.GUI.Mockup
{
	public partial class ReceivingMockup : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void ReceiveButton_Click(object sender, EventArgs e)
		{
			string barcode = BarcodeTextBox.Text;
			Employee.LoginUser().DistributionCentre.ReceivePackage(barcode);
		}
	}
}