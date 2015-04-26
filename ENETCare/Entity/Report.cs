using System;

namespace ENETCare.Business
{
	public class StocktakingViewData
	{
		public string Barcode { get; set; }
		public string Type { get; set; }
		public string ExpireDate { get; set; }
		public ExpireStatus ExpireStatus { get; set; }
	}

	public class MedicationTypeViewData
	{
		public string Type { get; set; }
		public int Quantity { get; set; }
		public decimal Value { get; set; }
	}

	public class DistributionCentreLossViewData
	{
		public string DistributionCentre { get; set; }
		public decimal LossValue { get; set; }
		public double LossRatio { get; set; }
		public DistributionCentreRiskLevel RiskLevel { get; set; }
	}

	public class ValueInTransitViewData
	{
		public string FromDistributionCentre { get; set; }
		public string ToDistributionCentre { get; set; }
		public int Packages { get; set; }
		public decimal Value { get; set; }
	}
}
