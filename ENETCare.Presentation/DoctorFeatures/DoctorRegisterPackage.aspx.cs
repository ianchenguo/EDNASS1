using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENETCare.Business;
using System.Globalization;

namespace ENETCare.Presentation.DoctorFeatures
{
    public partial class DoctorRegisterPackage : Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL("LoginUserName");
            if (!Page.IsPostBack)
            {
                DoctorRegisterPackageTypeDropDownList.DataSource = new MedicationTypeBLL().GetMedicationTypeList();
                DoctorRegisterPackageTypeDropDownList.DataTextField = "Name";
                DoctorRegisterPackageTypeDropDownList.DataValueField = "ID";
                DoctorRegisterPackageTypeDropDownList.DataBind();
            }
        }

        protected void DoctorRegisterButton_Click(object sender, EventArgs e)
        {
            string medicationType = DoctorRegisterPackageTypeDropDownList.SelectedValue;
            string DoctorOriginalExpireDate = DoctorRegisterPackageFormExpireDateTextBox.Text;
            string expireDate = FormatDateStr(DoctorOriginalExpireDate);
            try
            {
                string barcodeUnique = medicationPackageBLL.RegisterPackage(Convert.ToInt32(medicationType), expireDate);
                DoctorRegisterBarcodeImage.ImageUrl = string.Format("~/Layout/PresentBarcode.aspx?barcode={0}", barcodeUnique);
                //Response.Redirect("DoctorHome.aspx");
                if (barcodeUnique != null)
                {
                    //Response.Write(expireDate);
                    DoctorRegisterMessage.Text = DoctorRegisterPackageTypeDropDownList.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            }
        }

        private string FormatDateStr(string theDateStr)
        {
            string patternDate = "yyyy-MM-dd";
            DateTime convertDate = DateTime.ParseExact(theDateStr, patternDate, null, DateTimeStyles.None);
            string FormatedStr = convertDate.ToString();

            return FormatedStr;
        }
    }
}