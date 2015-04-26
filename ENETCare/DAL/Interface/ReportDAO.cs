using System.Collections.Generic;

namespace ENETCare.Business
{
	public interface ReportDAO
	{
		List<MedicationTypeViewData> FindDistributionCentreStockByStatus(int distributionCentreId, params PackageStatus[] statuses);
		List<MedicationTypeViewData> FindGlobalStock();
		List<MedicationTypeViewData> FindDoctorActivityByUserName(string username);
		List<ValueInTransitViewData> FindAllValueInTransit();
	}
}
