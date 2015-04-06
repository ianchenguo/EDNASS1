using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class BarcodeHelper
	{
		public static string GenerateBarcode()
		{
			return DateTime.Now.Ticks.ToString();
		}
	}
}
