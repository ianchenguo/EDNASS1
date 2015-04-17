using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class ReportBLL
	{
		#region Constructor

		// This part should be changed according to Identity Framework
		// Presentation should pass in a parameter standing for the current user
		// So that the business layer could know who is the current user

		Employee User { get; set; }

		public ReportBLL()
		{

		}

		public ReportBLL(int userid)
		{
			User = new EmployeeDataReaderDAO().FindEmployeeByUserId(userid);
			if (User == null)
			{
				throw new Exception("Invalid current user");
			}
		}

		public ReportBLL(string username)
		{
			User = new EmployeeDataReaderDAO().FindEmployeeByUserName(username);
			if (User == null)
			{
				throw new Exception("Invalid current user");
			}
		}

		#endregion

		#region Properties

		MedicationPackageDAO MedicationPackageDAO
		{
			get { return DAOFactory.GetMedicationPackageDAO(); }
		}

		MedicationTypeDAO MedicationTypeDAO
		{
			get { return DAOFactory.GetMedicationTypeDAO(); }
		}

		DistributionCentreDAO DistributionCentreDAO
		{
			get { return DAOFactory.GetDistributionCentreDAO(); }
		}

		#endregion

		#region Report

		public List<object> DistributionCentreStock(int distributionCentreId)
		{
			return MedicationPackageDAO.DistributionCentreStockReport(distributionCentreId);
		}

		#endregion
	}
}
