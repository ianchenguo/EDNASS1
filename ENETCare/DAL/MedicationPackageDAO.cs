using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public interface MedicationPackageDAO
	{
		List<MedicationPackage> FindAllPackages();
		List<StocktakingViewData> FindPackagesInDistributionCentre(int distributionCentreId);
		List<MedicationPackage> FindPackages(int medicationTypeId, int distributionCentreId);
		MedicationPackage FindPackageByBarcode(string barcode);
		void InsertPackage(MedicationPackage package);
		void UpdatePackage(MedicationPackage package);
		List<DistributionCentreStockViewData> DistributionCentreStockReport(int distributionCentreId, params PackageStatus[] statuses);
		List<DistributionCentreStockViewData> GlobalStockReport();
		List<DistributionCentreStockViewData> DoctorActivityReport(int userId);
		List<ValueInTransitViewData> DistributionCentreTransit();
	}
}
