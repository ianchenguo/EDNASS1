using ENETCare.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.Presentation.AgentDoctorFeatures
{
    public partial class AgentDoctorAuditPackage : System.Web.UI.Page
    {
        private List<string> scannedBarcodes = new List<string>();
        MedicationPackageBLL madicationPackageManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            madicationPackageManager = new MedicationPackageBLL(User.Identity.Name);

            if (Session["storedBarcodes"] == null)
            {
                Session["storedBarcodes"] = scannedBarcodes;
            }
            else
            {
                scannedBarcodes = Session["storedBarcodes"] as List<string>;
            }
        }



        protected void AuditPackageButton_Click(object sender, EventArgs e)
        {
            int parsedPackageId = Int32.Parse(PackageType.SelectedValue);
            madicationPackageManager.CheckAndUpdatePackage(parsedPackageId, Barcode.Text);

            insertBarcodeToSession(Barcode.Text);
        }

        private void insertBarcodeToSession(string barcode)
        {
            scannedBarcodes.Add(barcode);
            Session["storedBarcodes"] = scannedBarcodes;
            updateDispay();
        }

        private void updateDispay()
        {
            ScannedPackageTotal.Text = scannedBarcodes.Distinct().Count().ToString();
        }

    }
}