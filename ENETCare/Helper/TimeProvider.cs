using System;

namespace ENETCare.Business
{
	/// <summary>
	/// An abstract TimeProvider
	/// </summary>
	public abstract class TimeProvider
	{
		private static TimeProvider current = DefaultTimeProvider.Instance;

		public static TimeProvider Current
		{
			get	{ return TimeProvider.current; }
			set	{ TimeProvider.current = value; }
		}

		public abstract DateTime Now { get; }
		public abstract DateTime UtcNow { get; }
		
		public static void ResetToDefault()
		{
			TimeProvider.current = DefaultTimeProvider.Instance;
		}
	}
}
