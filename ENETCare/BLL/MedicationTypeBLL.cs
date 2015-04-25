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

		public MedicationType GetMedicationTypeById(int id)
		{
			return MedicationTypeDAO.GetMedicationTypeById(id);
		}

		public List<MedicationType> GetMedicationTypeList()
		{
			return MedicationTypeDAO.FindAllMedicationTypes();
		}
	}
}
