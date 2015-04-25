using System;

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
