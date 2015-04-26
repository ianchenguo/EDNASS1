using System.Collections.Generic;

namespace ENETCare.Business
{
	public class DistributionCentreBLL
	{
		DistributionCentreDAO DistributionCentreDAO { get; set; }

		public DistributionCentreBLL()
		{
			DistributionCentreDAO = DAOFactory.GetDistributionCentreDAO();
		}

		public DistributionCentre GetDistributionCentreById(int id)
		{
			return DistributionCentreDAO.GetDistributionCentreById(id);
		}

		public List<DistributionCentre> GetDistributionCentreList()
		{
			return DistributionCentreDAO.FindAllDistributionCentres();
		}
	}
}
