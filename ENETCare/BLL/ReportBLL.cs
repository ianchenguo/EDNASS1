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

		public List<DistributionCentreStockViewData> DistributionCentreStock(int distributionCentreId)
		{
			return MedicationPackageDAO.DistributionCentreStockReport(distributionCentreId, PackageStatus.InStock);
		}

		public List<DistributionCentreStockViewData> GlobalStock()
		{
			return MedicationPackageDAO.GlobalStockReport();
		}

		public List<DistributionCentreStockViewData> DoctorActivity(int userId)
		{
			return MedicationPackageDAO.DoctorActivityReport(userId);
		}

		public List<DistributionCentreLossesViewData> DistributionCentreLosses()
		{
			List<DistributionCentreLossesViewData> report = new List<DistributionCentreLossesViewData>();
			List<DistributionCentre> distributionCentres = DistributionCentreDAO.FindAllDistributionCentres();
			const decimal riskThreshold = 0.09m;
			foreach (DistributionCentre distributionCentre in distributionCentres)
			{
				List<DistributionCentreStockViewData> listLoss = MedicationPackageDAO.DistributionCentreStockReport(distributionCentre.ID, PackageStatus.Discarded, PackageStatus.Lost);
				decimal totalLoss = listLoss.Sum(type => type.Value);
				List<DistributionCentreStockViewData> listTotal = MedicationPackageDAO.DistributionCentreStockReport(distributionCentre.ID, PackageStatus.Distributed, PackageStatus.Discarded, PackageStatus.Lost);
				decimal totalTotal = listTotal.Sum(type => type.Value);
				decimal lossRatio;
				if (totalTotal != 0)
				{
					lossRatio = totalLoss / totalTotal;
				}
				else
				{
					lossRatio = 0;
				}
				DistributionCentreRiskLevel riskLevel = DistributionCentreRiskLevel.Low;
				if (lossRatio > riskThreshold)
				{
					riskLevel = DistributionCentreRiskLevel.High;
				}
				report.Add(new DistributionCentreLossesViewData { DistributionCentre = distributionCentre.Name, LossRatio = lossRatio, LossValue = totalLoss, RiskLevel = riskLevel });
			}
			return report;
		}

		public List<ValueInTransitViewData> ValueInTransit()
		{
			return MedicationPackageDAO.DistributionCentreTransit();
		}

		#endregion
	}
}
