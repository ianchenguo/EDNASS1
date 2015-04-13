using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public interface MedicationTypeDAO
	{
		List<MedicationType> FindAllMedicationTypes();
		MedicationType GetMedicationTypeById(int id);
	}
}
