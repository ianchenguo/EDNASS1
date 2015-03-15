using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare
{
	public class MedicationPackage
	{
		public int id;
		public string barcode;
		public MedicationType type;
		public DateTime expireDate;
		public PackageStatus status;
		public DistributionCentre stockDC;
		public DistributionCentre sourceDC;
		public DistributionCentre destinationDC;
		public DateTime updateTime;
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
