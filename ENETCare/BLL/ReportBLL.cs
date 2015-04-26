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

		/// <summary>
		/// Retrieves the quantity and total value for each product type in stock at a given distribution centre.
		/// </summary>
		/// <param name="distributionCentreId">distribution centre id</param>
		/// <returns>a list of quantity, package type and value of packages</returns>
		public List<MedicationTypeViewData> DistributionCentreStock(int distributionCentreId)
		{
			return ReportDAO.FindDistributionCentreStockByStatus(distributionCentreId, PackageStatus.InStock);
		}

		/// <summary>
		/// Retrieves the quantity and total value for each product type in stock across all distribution centres.
		/// </summary>
		/// <returns>a list of quantity, package type and value of packages</returns>
		public List<MedicationTypeViewData> GlobalStock()
		{
			return ReportDAO.FindGlobalStock();
		}

		/// <summary>
		/// Retrieves the loss ratio and total value of lost/discarded packages for each distribution centre.
		/// </summary>
		/// <returns>a list of distribution centre, loss value, loss ratio and risk level</returns>
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

		/// <summary>
		/// Retrieves total value and number of packages in transit between distribution centres.
		/// </summary>
		/// <returns>a list of source distribution centre, destination distribution centre, number of packages, and total value of packages</returns>
		public List<ValueInTransitViewData> ValueInTransit()
		{
			return ReportDAO.FindAllValueInTransit();
		}

		/// <summary>
		/// Retrieves the quantity and total value for each product type distributed by a given doctor.
		/// </summary>
		/// <param name="username">doctor username</param>
		/// <returns>a list of quantity, package type and value of packages</returns>
		public List<MedicationTypeViewData> DoctorActivity(string username)
		{
			return ReportDAO.FindDoctorActivityByUserName(username);
		}
	}
}
