using System.Collections.Generic;

namespace ENETCare.Business
{
	public interface MedicationPackageDAO
	{
		List<MedicationPackage> FindAllPackages();
		List<MedicationPackage> FindInStockPackagesInDistributionCentre(int distributionCentreId, int? medicationTypeId = null);
		MedicationPackage FindPackageByBarcode(string barcode);
		void InsertPackage(MedicationPackage package);
		void UpdatePackage(MedicationPackage package);
	}
}
