using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public static string GenerateBarcode()
		{
			return Guid.NewGuid().ToString();
		}
	}

	public enum PackageStatus
	{
		InStock,
		Discarded,
		Lost,
		Distributed,
		InTransit
	};
}
