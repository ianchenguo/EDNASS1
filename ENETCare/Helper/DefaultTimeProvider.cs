using System;

namespace ENETCare.Business
{
	/// <summary>
	/// The default implementation of TimeProvider
	/// </summary>
	public class DefaultTimeProvider : TimeProvider
	{
		private readonly static DefaultTimeProvider instance = new DefaultTimeProvider();

		private DefaultTimeProvider() { }

		public override DateTime Now
		{
			get { return DateTime.Now; } 
		}

		public override DateTime UtcNow
		{
			get { return DateTime.UtcNow; }
		}

		public static DefaultTimeProvider Instance
		{
			get { return DefaultTimeProvider.instance; }
		}
	}
}
