using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
