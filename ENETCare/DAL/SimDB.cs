using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENETCare.Business
{
	public class SimDB
	{
		public static List<MedicationPackage> packages = new List<MedicationPackage>();
		public static List<MedicationType> medicationTypeList = new List<MedicationType>();
		public static List<DistributionCentre> distributionCentreList = new List<DistributionCentre>();
		public static MedicationType type1;
		public static MedicationType type2;
		public static MedicationType type3;
		public static MedicationType type4;
		public static DistributionCentre dc1;
		public static DistributionCentre dc2;
		public static DistributionCentre dc3;
		public static Employee employee1;
		public static Employee employee2;
		public static Employee employee3;

		#region Test Data

		public static bool HasInitTestData;

		public static void PrepareTestData()
		{
			PrepareTestMedicationType();
			PrepareTestDistributionCentre();
			PrepareTestEmployee();
			HasInitTestData = true;
		}

		public static void PrepareTestDistributionCentre()
		{
			dc1 = new DistributionCentre();
			dc1.ID = 1;
			dc1.Name = "Liverpool Office";
			dc1.Address = "Macquarie Street, Liverpool NSW 2170";
			dc1.Phone = "(02) 9602 6633";
			dc2 = new DistributionCentre();
			dc2.ID = 2;
			dc2.Name = "Glebe Office";
			dc2.Address = "9-25 Derwent Street, Glebe NSW 2037";
			dc2.Phone = "(02) 9660 4549";
			dc3 = new DistributionCentre();
			dc3.ID = 3;
			dc3.Name = "Ultimo Office";
			dc3.Address = "15 Broadway, Ultimo NSW 2007";
			dc3.Phone = "(02) 9514 2000";
			distributionCentreList.Add(dc1);
			distributionCentreList.Add(dc2);
			distributionCentreList.Add(dc3);
		}

		public static void PrepareTestEmployee()
		{
			employee1 = new Employee();
			employee1.ID = 1;
			employee1.Username = "starcraft";
			employee1.Role = Role.Doctor;
			employee1.Fullname = "StarCraft";
			employee1.Email = "StarCraft@blizzard.com";
			employee1.DistributionCentre = dc1;
		}

		public static void PrepareTestMedicationType()
		{
			type1 = new MedicationType();
			type1.ID = 1;
			type1.Name = "100 polio vaccinations";
			type1.Description = "";
			type1.ShelfLife = 365;
			type1.Value = 500;
			type1.IsSensitive = true;
			type2 = new MedicationType();

			type2.ID = 2;
			type2.Name = "box of 500 x 28 pack chloroquine pills";
			type2.Description = "";
			type2.ShelfLife = 730;
			type2.Value = 3000;
			type2.IsSensitive = false;

			type3 = new MedicationType();
			type3.ID = 3;
			type3.Name = "10L Polyheme";
			type3.Description = "";
			type3.ShelfLife = 90;
			type3.Value = 100;
			type3.IsSensitive = false;

			type4 = new MedicationType();
			type4.ID = 4;
			type4.Name = "water purification kit";
			type4.Description = "";
			type4.ShelfLife = 3650;
			type4.Value = 10;
			type4.IsSensitive = false;

			medicationTypeList.Add(type1);
			medicationTypeList.Add(type2);
			medicationTypeList.Add(type3);
			medicationTypeList.Add(type4);
		}

		#endregion
		
		#region Medication Package

		public class MedicationPackageGridView
		{
			public string Barcode { get; set; }
			public string Type { get; set; }
			public string ExpireDate { get; set; }
			public PackageStatus Status { get; set; }
			public string StockDC { get; set; }
			public string SourceDC { get; set; }
			public string DestinationDC { get; set; }
		}

		public static List<MedicationPackageGridView> FindAllPackagesTest()
		{
			List<MedicationPackageGridView> list = new List<MedicationPackageGridView>();
			foreach (MedicationPackage package in packages)
			{
				MedicationPackageGridView item = new MedicationPackageGridView();
				item.Barcode = package.Barcode;
				item.Type = package.Type.Name;
				item.ExpireDate = package.ExpireDate.ToString("d", new CultureInfo("en-au"));
				item.Status = package.Status;
				item.StockDC = package.StockDC != null ? package.StockDC.Name : "";
				item.SourceDC = package.SourceDC != null ? package.SourceDC.Name : "";
				item.DestinationDC = package.DestinationDC != null ? package.DestinationDC.Name : "";
				list.Add(item);
			}
			return list;
		}

		public static List<MedicationPackage> FindAllPackages()
		{
			return packages;
		}

		public static List<MedicationPackage> FindPackagesInDistributionCentre(DistributionCentre dc)
		{
			return packages;
		}

		public static MedicationPackage FindPackageByBarcode(string barcode)
		{
			foreach (MedicationPackage package in packages)
			{
				if (package.Barcode == barcode)
				{
					return package;
				}
			}
			return null;
		}

		public static void InsertPackage(MedicationPackage package)
		{
			packages.Add(package);
		}

		public static void UpdatePackage(MedicationPackage package)
		{
			
		}

		#endregion

		#region Medication Type

		public static MedicationType GetMedicationTypeByID(string medicationTypeID)
		{
			int id;
			if (Int32.TryParse(medicationTypeID, out id))
			{
				foreach (MedicationType medicationType in medicationTypeList)
				{
					if (medicationType.ID == id)
					{
						return medicationType;
					}
				}
			}
			return null;
		}

		#endregion

		#region Distribution Centre

		public static DistributionCentre GetDistributionCentreByID(string distributionCentreID)
		{
			int id;
			if (Int32.TryParse(distributionCentreID, out id))
			{
				foreach (DistributionCentre distributionCentre in distributionCentreList)
				{
					if (distributionCentre.ID == id)
					{
						return distributionCentre;
					}
				}
			}
			return null;
		}

		#endregion

		#region Employee

		public static Employee FindEmployeeByUserName(String username)
		{
			return new Employee();
		}

		public static void UpdateEmployee(Employee employee)
		{

		}

		#endregion
	}
}
