using System;

namespace ENETCare.Business
{
	/// <summary>
	/// DistributionCentre entity
	/// </summary>
    [Serializable]
	public class DistributionCentre
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
	}

	public enum DistributionCentreRiskLevel
	{
		Low = 0,
		High = 1
	};
}
