using System;
using System.Collections.Generic;
using System.Linq;

namespace ENETCare.Business
{
	public class ReportBLL
	{
		ReportDAO ReportDAO { get; set; }
		MedicationTypeDAO MedicationTypeDAO { get; set; }
		DistributionCentreDAO DistributionCentreDAO { get; set; }

		public ReportBLL()
		{
			ReportDAO = DAOFactory.GetReportDAO();
			MedicationTypeDAO = DAOFactory.GetMedicationTypeDAO();
			DistributionCentreDAO = DAOFactory.GetDistributionCentreDAO();
		}

		public List<MedicationTypeViewData> DistributionCentreStock(int distributionCentreId)
		{
			return ReportDAO.FindDistributionCentreStockByStatus(distributionCentreId, PackageStatus.InStock);
		}

		public List<MedicationTypeViewData> GlobalStock()
		{
			return ReportDAO.FindGlobalStock();
		}

		public List<DistributionCentreLossViewData> DistributionCentreLosses()
		{
			const double riskThreshold = 0.09;
			List<DistributionCentreLossViewData> report = new List<DistributionCentreLossViewData>();
			List<DistributionCentre> distributionCentres = DistributionCentreDAO.FindAllDistributionCentres();
			
			foreach (DistributionCentre distributionCentre in distributionCentres)
			{
				List<MedicationTypeViewData> lostList = ReportDAO.FindDistributionCentreStockByStatus(distributionCentre.ID, PackageStatus.Discarded, PackageStatus.Lost);
				decimal lostTotal = lostList.Sum(type => type.Value);
				List<MedicationTypeViewData> handledList = ReportDAO.FindDistributionCentreStockByStatus(distributionCentre.ID, PackageStatus.Distributed, PackageStatus.Discarded, PackageStatus.Lost);
				decimal handledTotal = handledList.Sum(type => type.Value);
				double lossRatio;
				if (handledTotal == 0)
				{
					lossRatio = 0;
				}
				else
				{
					lossRatio = Convert.ToDouble(lostTotal / handledTotal);
				}
				DistributionCentreRiskLevel riskLevel = DistributionCentreRiskLevel.Low;
				if (Convert.ToDouble(lossRatio) > riskThreshold)
				{
					riskLevel = DistributionCentreRiskLevel.High;
				}
				report.Add(new DistributionCentreLossViewData { DistributionCentre = distributionCentre.Name, LossRatio = lossRatio, LossValue = lostTotal, RiskLevel = riskLevel });
			}

			return report;
		}

		public List<ValueInTransitViewData> ValueInTransit()
		{
			return ReportDAO.FindAllValueInTransit();
		}

		public List<MedicationTypeViewData> DoctorActivity(string username)
		{
			return ReportDAO.FindDoctorActivityByUserName(username);
		}
	}
}
