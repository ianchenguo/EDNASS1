using System;

namespace ENETCare.Business
{
	/// <summary>
	/// ENETCare custom exception
	/// </summary>
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
