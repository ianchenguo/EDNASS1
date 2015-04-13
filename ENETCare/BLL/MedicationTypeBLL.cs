using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class MedicationTypeBLL
	{
		MedicationTypeDAO MedicationTypeDAO
		{
			get { return DAOFactory.GetMedicationTypeDAO(); }
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
