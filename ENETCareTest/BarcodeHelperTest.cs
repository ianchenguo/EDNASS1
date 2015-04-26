using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Business;

namespace ENETCareTest
{
	[TestClass]
	public class BarcodeHelperTest
	{
		[TestMethod]
		public void BarcodeContainsOnlyDigits()
		{
			string barcode = BarcodeHelper.GenerateBarcode();
			Assert.AreEqual(true, IsAllDigits(barcode));
		}

		bool IsAllDigits(string s)
		{
			return s.All(Char.IsDigit);
		}
	}
}
