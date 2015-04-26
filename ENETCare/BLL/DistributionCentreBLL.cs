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

		/// <summary>
		/// Retrieves all distribution centres in the database.
		/// </summary>
		/// <returns>a list of all the distribution centres</returns>
		public List<DistributionCentre> GetDistributionCentreList()
		{
			return DistributionCentreDAO.FindAllDistributionCentres();
		}

		/// <summary>
		/// Retrieves a distribution centre by looking up its id.
		/// </summary>
		/// <param name="id">distribution centre id</param>
		/// <returns>a distribution centre corresponding to the id, or null if no matching distribution centre was found</returns>
		public DistributionCentre GetDistributionCentreById(int id)
		{
			return DistributionCentreDAO.GetDistributionCentreById(id);
		}
	}
}
