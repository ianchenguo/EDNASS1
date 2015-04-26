using System;

namespace ENETCare.Business
{
	/// <summary>
	/// MedicationType entity
	/// </summary>
    [Serializable]
	public class MedicationType
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int ShelfLife { get; set; }
		public decimal Value { get; set; }
		public bool IsSensitive { get; set; }

		public DateTime DefaultExpireDate
		{
			get
			{
				return DateTime.Today.AddDays(ShelfLife);
			}
		}
	}
}
