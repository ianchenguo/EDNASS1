using System.Collections.Generic;

namespace ENETCare.Business
{
	public interface DistributionCentreDAO
	{
		List<DistributionCentre> FindAllDistributionCentres();
		DistributionCentre GetDistributionCentreById(int id);
	}
}
