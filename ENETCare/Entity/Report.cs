using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class Report
	{
		
	}

	public class StocktakingViewData
	{
		public string Barcode { get; set; }
		public string Type { get; set; }
		public string ExpireDate { get; set; }
		public ExpireStatus ExpireStatus { get; set; }
	}

	public class DistributionCentreStockViewData
	{
		public string Type { get; set; }
		public int Quantity { get; set; }
		public decimal Value { get; set; }
	}

	public class DistributionCentreLossesViewData
	{
		public string DistributionCentre { get; set; }
		public decimal LossRatio { get; set; }
		public decimal LossValue { get; set; }
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
