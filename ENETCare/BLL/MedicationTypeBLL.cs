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

		public List<MedicationType> GetMedicationTypeList()
		{
			return MedicationTypeDAO.FindAllMedicationTypes();
		}
	}
}
