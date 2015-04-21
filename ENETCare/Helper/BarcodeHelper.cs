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
		/// <summary>
		/// Generate a unique package barcode number
		/// </summary>
		/// <returns>barcode number</returns>
		public static string GenerateBarcode()
		{
			return DateTime.Now.Ticks.ToString();
		}

		/// <summary>
		/// Generate barcode image
		/// </summary>
		/// <param name="barcode">barcode number</param>
		/// <returns>barcode image</returns>
		public static Bitmap GenerateBarcodeImage(string barcode)
		{
			BarCodeBuilder builder = new BarCodeBuilder(barcode, Symbology.Code128);
			return builder.GenerateBarCodeImage();
		}
	}
}
