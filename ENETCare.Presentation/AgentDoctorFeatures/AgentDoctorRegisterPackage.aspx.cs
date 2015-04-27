using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using ENETCare.Business;
using ENETCare.Presentation.Layout;

namespace ENETCare.Presentation.AgentDoctorFeatures
{
    public partial class AgentDoctorRegisterPackage : Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        protected void Page_Load(object sender, EventArgs e)
        {
            medicationPackageBLL = new MedicationPackageBLL(User.Identity.Name);
            if (!Page.IsPostBack)
            {
                AgentDoctorPackageRegisterPackageTypeDropDwonList.DataSource = new MedicationTypeBLL().GetMedicationTypeList();
                AgentDoctorPackageRegisterPackageTypeDropDwonList.DataTextField = "Name";
                AgentDoctorPackageRegisterPackageTypeDropDwonList.DataValueField = "ID";
                AgentDoctorPackageRegisterPackageTypeDropDwonList.DataBind();
                NedPackageRegisterFormExpireDate.Text = DateTime.Now.Date.ToShortDateString();
            }
        }

        //protected void Submit(object sender, EventArgs e)
        //{
        //    //what's this for?
        //    if (IsValid)
        //    {
        //        var test = AgentDoctorRegisterButton.Text;
        //        //MedicationPackageBLL packageBUS = new MedicationPackageBLL();
        //        //packageBUS.RegisterPackage(NedPackageRegisterFormPackageType.Text, NedPackageRegisterFormExpireDate.Text);
        //    }
        //}

        protected void AgentDoctorRegisterButton_Click(object sender, EventArgs e)
        {
            string medicationType = AgentDoctorPackageRegisterPackageTypeDropDwonList.SelectedValue;
            string originalDateStr = NedPackageRegisterFormExpireDate.Text;
            try
            {
                string expireDate = this.FormatDate(originalDateStr);
                string barcodeUnique = medicationPackageBLL.RegisterPackage(Convert.ToInt32(medicationType), expireDate);
                AgentDoctorRegisterBarcodeImage.ImageUrl = string.Format("PresentBarcode.aspx?barcode={0}", barcodeUnique);
                if (barcodeUnique != null)
                {
                    //Response.Write(expireDate);
                    AgentDoctorRegisterMessage.Text = AgentDoctorPackageRegisterPackageTypeDropDwonList.SelectedItem.ToString();
                    this.ClearReadOnlyInputTextBoxExpiredDateAfterClick(AgentDoctorRegisterMessage.Text);
                }
                 //Response.Redirect("AgentDoctorHome.aspx");
            }
            catch (Exception ex)
            {
                AgentDoctorRegisterMessage.Text = "";
                AgentDoctorRegisterBarcodeImage.ImageUrl = "";
                NedPackageRegisterFormExpireDate.Text = "";
                Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            }
        }

        private string FormatDate(string originalDateStr)
        {
            string patternDate = "yyyy-MM-dd";
            DateTime convertDate = DateTime.ParseExact(originalDateStr, patternDate, null, DateTimeStyles.None);
            string FormatDate = convertDate.ToString();
            return FormatDate;
        }  

        private void ClearReadOnlyInputTextBoxExpiredDateAfterClick(string MsgOfMedicationTypeInfrontOfBarcode)
        {
            if (MsgOfMedicationTypeInfrontOfBarcode != null && AgentDoctorRegisterMessage.Text != string.Empty)
            {
                NedPackageRegisterFormExpireDate.Text = string.Empty;
            }
        }
    }
}