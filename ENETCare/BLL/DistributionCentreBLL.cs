using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class DistributionCentreBLL
	{
		DistributionCentreDAO DistributionCentreDAO
		{
			get { return DAOFactory.GetDistributionCentreDAO(); }
		}

		public List<DistributionCentre> GetDistributionCentreList()
		{
			return DistributionCentreDAO.FindAllDistributionCentres();
		}
	}
}
