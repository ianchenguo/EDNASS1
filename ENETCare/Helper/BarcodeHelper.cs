using System;
using System.Drawing;
using Aspose.BarCode;

namespace ENETCare.Business
{
	/// <summary>
	/// Helper class to generate barcode numbers and images
	/// </summary>
	public class BarcodeHelper
	{
		/// <summary>
		/// Generates a unique package barcode number.
		/// </summary>
		/// <returns>barcode number</returns>
		public static string GenerateBarcode()
		{
			return DateTime.Now.Ticks.ToString();
		}

		/// <summary>
		/// Generates a barcode image.
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
