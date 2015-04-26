using System;

namespace ENETCare.Business
{
	/// <summary>
	/// Structure for stocktaking
	/// </summary>
	public class StocktakingViewData
	{
		public string Barcode { get; set; }
		public string Type { get; set; }
		public string ExpireDate { get; set; }
		public ExpireStatus ExpireStatus { get; set; }
	}

	/// <summary>
	/// Structure for distribution centre stock, global stock, and doctor activity reports
	/// </summary>
	public class MedicationTypeViewData
	{
		public string Type { get; set; }
		public int Quantity { get; set; }
		public decimal Value { get; set; }
	}

	/// <summary>
	/// Structure for distribution centre loss report
	/// </summary>
	public class DistributionCentreLossViewData
	{
		public string DistributionCentre { get; set; }
		public decimal LossValue { get; set; }
		public double LossRatio { get; set; }
		public DistributionCentreRiskLevel RiskLevel { get; set; }
	}

	/// <summary>
	/// Structure for value in transit report
	/// </summary>
	public class ValueInTransitViewData
	{
		public string FromDistributionCentre { get; set; }
		public string ToDistributionCentre { get; set; }
		public int Packages { get; set; }
		public decimal Value { get; set; }
	}
}
