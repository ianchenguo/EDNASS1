using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.BarCode;

namespace ENETCare.Business
{
	public class BarcodeHelper
	{
		public static string GenerateBarcode()
		{
			return DateTime.Now.Ticks.ToString();
		}

		public static Bitmap GenerateBarcodeImage(string barcode)
		{
			BarCodeBuilder builder = new BarCodeBuilder(barcode, Symbology.Code128);
			return builder.GenerateBarCodeImage();
		}
	}
}
