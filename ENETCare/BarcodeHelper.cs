using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare
{
	public class BarcodeHelper
	{
		public static string GenerateBarcode()
		{
			return Guid.NewGuid().ToString();
		}
	}
}
