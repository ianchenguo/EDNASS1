using System;

namespace ENETCare.Business
{
	public class MedicationPackage
	{
		public int ID { get; set; }
		public string Barcode { get; set; }
		public MedicationType Type { get; set; }
		public DateTime ExpireDate { get; set; }
		public PackageStatus Status { get; set; }
		public DistributionCentre StockDC { get; set; }
		public DistributionCentre SourceDC { get; set; }
		public DistributionCentre DestinationDC { get; set; }
		public DateTime UpdateTime { get; set; }
		public string Operator { get; set; }
	}

	public enum PackageStatus
	{
		InStock = 0,
		InTransit = 1,
		Distributed = 2,
		Discarded = 3,
		Lost = 4
	};

	public enum ExpireStatus
	{
		Expired = 0,
		NotExpired = 1,
		AboutToExpired = 2
	};
}
