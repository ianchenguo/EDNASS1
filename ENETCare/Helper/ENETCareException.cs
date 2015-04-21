using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class ENETCareException : Exception
	{
		public ENETCareException()
		{
		}

		public ENETCareException(string message)
			: base(message)
		{
		}

		public ENETCareException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
