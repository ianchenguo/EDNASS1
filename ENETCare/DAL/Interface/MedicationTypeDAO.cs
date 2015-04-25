using System.Collections.Generic;

namespace ENETCare.Business
{
	public interface MedicationTypeDAO
	{
		List<MedicationType> FindAllMedicationTypes();
		MedicationType GetMedicationTypeById(int id);
	}
}
