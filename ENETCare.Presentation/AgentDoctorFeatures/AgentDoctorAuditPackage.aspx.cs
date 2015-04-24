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
            updateDispay();
            //warns the user to restart the audition task
            PackageType.Attributes.Add("onfocus", "javascript:return confirm('Are You Sure To Restart Audition Task?')");
        }

        protected void AuditPackageButton_Click(object sender, EventArgs e)
        {
            int parsedPackageId = getMedicationPackageId();
            madicationPackageManager.CheckAndUpdatePackage(parsedPackageId, Barcode.Text);

            insertBarcodeToSession(Barcode.Text);
        }

        protected void CommitAuditionButton_Click(object sender, EventArgs e)
        {
            //madicationPackageManager.AuditPackages(getMedicationPackageId(), scannedBarcodes);
            emptyScannedBarcodes();
        }

        protected void PackageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            emptyScannedBarcodes();
            updateDispay();
        }

        private void emptyScannedBarcodes()
        {
            Session["storedBarcodes"] = null;
            scannedBarcodes = new List<string>();
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

        private int getMedicationPackageId()
        {
            int parsedPackageId = Int32.Parse(PackageType.SelectedValue);
            return parsedPackageId;
        }
    }
}