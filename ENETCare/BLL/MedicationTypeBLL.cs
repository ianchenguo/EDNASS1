using System.Collections.Generic;

namespace ENETCare.Business
{
	public class MedicationTypeBLL
	{
		MedicationTypeDAO MedicationTypeDAO { get; set; }

		public MedicationTypeBLL()
		{
			MedicationTypeDAO = DAOFactory.GetMedicationTypeDAO();
		}

		/// <summary>
		/// Retrieves all medication types in the database.
		/// </summary>
		/// <returns>a list of all the medication types</returns>
		public List<MedicationType> GetMedicationTypeList()
		{
			return MedicationTypeDAO.FindAllMedicationTypes();
		}

		/// <summary>
		/// Retrieves a medication type by looking up its id.
		/// </summary>
		/// <param name="id">medication type id</param>
		/// <returns>a medication type corresponding to the id, or null if no matching medication type was found</returns>
		public MedicationType GetMedicationTypeById(int id)
		{
			return MedicationTypeDAO.GetMedicationTypeById(id);
		}
	}
}
