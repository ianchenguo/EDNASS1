using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;

namespace ENETCare.GUI.Mockup
{
	public partial class RegistrationMockup : System.Web.UI.Page
	{
		MedicationPackageBLL medicationPackageBLL;

		public List<MedicationType> MedicationTypeList
		{
			get
			{
				if (ViewState["MedicationTypeList"] != null)
				{
					return (List<MedicationType>)ViewState["MedicationTypeList"];
				}
				return null;
			}
			set { ViewState["MedicationTypeList"] = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			medicationPackageBLL = new MedicationPackageBLL("LoginUserName");
			if (!Page.IsPostBack)
			{
				MedicationTypeList = new MedicationTypeBLL().GetMedicationTypeList();
				TypeDropDownList.DataSource = MedicationTypeList;
				TypeDropDownList.DataTextField = "Name";
				TypeDropDownList.DataValueField = "ID";
				TypeDropDownList.DataBind();
				SetDefaultExpireDate();
			}
		}

		protected void TypeDropDownListSelection_Change(object sender, EventArgs e)
		{
			SetDefaultExpireDate();
		}

		void SetDefaultExpireDate()
		{
			foreach (MedicationType type in MedicationTypeList)
			{
				if (Convert.ToInt32(TypeDropDownList.SelectedItem.Value) == type.ID)
				{
					ExpireDateTextBox.Text = type.DefaultExpireDate.ToString("yyyy-MM-dd");
					break;
				}
			}
		}

		protected void RegisterButton_Click(object sender, EventArgs e)
		{
			string medicationType = TypeDropDownList.SelectedValue;
			string expireDate = ExpireDateTextBox.Text;
			try
			{
				string barcode = medicationPackageBLL.RegisterPackage(Convert.ToInt32(medicationType), expireDate);
				BarcodeImage.ImageUrl = string.Format("BarcodeImageMockup.aspx?barcode={0}", barcode);
				//Response.Redirect("IndexMockup.aspx");
			}
			catch (ENETCareException ex)
			{
				Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
			}
		}
	}
}