using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class DAOFactory
	{
		public static DistributionCentreDAO GetDistributionCentreDAO()
		{
			return new DistributionCentreDataReaderDAO();
		}

		public static EmployeeDAO GetEmployeeDAO()
		{
			return new EmployeeDataReaderDAO();
		}

		public static MedicationTypeDAO GetMedicationTypeDAO()
		{
			return new MedicationTypeDataReaderDAO();
		}

		public static MedicationPackageDAO GetMedicationPackageDAO()
		{
			return new MedicationPackageDataReaderDAO();
		}

		public static ReportDAO GetReportDAO()
		{
			return new ReportDataReaderDAO();
		}
	}
}
