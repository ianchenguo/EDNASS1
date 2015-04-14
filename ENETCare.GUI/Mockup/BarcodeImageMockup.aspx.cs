using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.GUI.Mockup
{
	public partial class BarcodeImageMockup : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string barcode = Request.QueryString["barcode"];
			if (!string.IsNullOrWhiteSpace(barcode))
			{
				Bitmap image = BarcodeHelper.GenerateBarcodeImage(barcode);
				image.Save(Response.OutputStream, ImageFormat.Jpeg);
				Response.ContentType = "image/jpeg";
			}
		}
	}
}