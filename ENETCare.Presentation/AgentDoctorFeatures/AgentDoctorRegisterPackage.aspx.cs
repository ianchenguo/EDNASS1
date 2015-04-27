using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using ENETCare.Business;
using ENETCare.Presentation.Layout;
using ENETCare.Presentation.HelperUtilities;

namespace ENETCare.Presentation.AgentDoctorFeatures
{
    public partial class AgentDoctorRegisterPackage : Page
    {
        private MedicationPackageBLL medicationPackageBLL;
        private Features masterPageADregister;
        //private MedicationType packageTypeDefaultExpireDate = new MedicationType();
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
            medicationPackageBLL = new MedicationPackageBLL(User.Identity.Name);
            if (!Page.IsPostBack)
            {
                MedicationTypeList = new MedicationTypeBLL().GetMedicationTypeList();

                AgentDoctorPackageRegisterPackageTypeDropDwonList.DataSource = MedicationTypeList;
                AgentDoctorPackageRegisterPackageTypeDropDwonList.DataTextField = "Name";
                AgentDoctorPackageRegisterPackageTypeDropDwonList.DataValueField = "ID";
                AgentDoctorPackageRegisterPackageTypeDropDwonList.DataBind();
                SetDefaultExpireDate();
            }

            masterPageADregister = Page.Master.Master as Features;
            masterPageADregister.ConfigureAlertBox(false);
        }


        protected void AgentDoctorPackageRegisterPackageTypeDropDwonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDefaultExpireDate();
        }

        void SetDefaultExpireDate()
        {
            foreach (MedicationType mediTypeOBJ in MedicationTypeList)
            {
                if (Convert.ToInt32(AgentDoctorPackageRegisterPackageTypeDropDwonList.SelectedItem.Value) == mediTypeOBJ.ID)
                {
                    NedPackageRegisterFormExpireDate.Text = mediTypeOBJ.DefaultExpireDate.ToString("yyyy-MM-dd");
                    break;
                }
            }
        }


        protected void AgentDoctorRegisterButton_Click(object sender, EventArgs e)
        {
            string medicationType = AgentDoctorPackageRegisterPackageTypeDropDwonList.SelectedValue;
            string originalDateStr = NedPackageRegisterFormExpireDate.Text;
            try
            {
                string expireDate = this.FormatDate(originalDateStr);
                string barcodeUnique = medicationPackageBLL.RegisterPackage(Convert.ToInt32(medicationType), expireDate);
                string successMsg = "Successfully Register.";

                
                AgentDoctorRegisterBarcodeImage.ImageUrl = string.Format("PresentBarcode.aspx?barcode={0}", barcodeUnique);
                if (barcodeUnique != null)
                {
                    AgentDoctorRegisterMessage.Text = AgentDoctorPackageRegisterPackageTypeDropDwonList.SelectedItem.ToString();
                    this.ClearReadOnlyInputTextBoxExpiredDateAfterClick(AgentDoctorRegisterMessage.Text);
                }
                this.ADRegisterPackageHandleMessage(AlertBoxHelper.AlertType.Success, AlertBoxHelper.ALERT_STYLE_SUCCESS, successMsg);
            }
            catch (Exception ex)
            {
                AgentDoctorRegisterMessage.Text = "";
                AgentDoctorRegisterBarcodeImage.ImageUrl = "";
                NedPackageRegisterFormExpireDate.Text = "";
                this.ADRegisterPackageHandleMessage(AlertBoxHelper.AlertType.Error, AlertBoxHelper.ALERT_STYLE_DANGER, ex.Message.ToString());
                //Response.Write(string.Format("<p>Error: {0}</p>\n", ex.Message));
            }
        }
        private void ADRegisterPackageHandleMessage(AlertBoxHelper.AlertType alertType, string alertStyle, string alertContent)
        {
            masterPageADregister.ConfigureAlertBox(true, alertStyle, alertType.ToString(), alertContent);
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
                SetDefaultExpireDate();
            }
        }

    }
}