using ENETCare.Business;
using ENETCare.Presentation.HelperUtilities;
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
        private MedicationPackageBLL madicationPackageManager;
        private AgentDoctorFeatures masterPage;

        /// <summary>
        /// syncronises local scanned package list with stored list in current session,
        /// updates display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            madicationPackageManager = new MedicationPackageBLL(User.Identity.Name);

            masterPage = Page.Master as AgentDoctorFeatures;
            masterPage.ConfigureAlertBox(false);

            syncSessionStoredBarcodes();
            syncScannedPackageCounting();

            buttonsDataBind();
        }

        private void buttonsDataBind()
        {
            ScanPackageButton.DataBind();
            StartAuditButton.DataBind();
            CancelButton.DataBind();
            CommitAuditButton.DataBind();
        }

        /// <summary>
        /// Scans a packages and updates its state in storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ScanPackageButton_Click(object sender, EventArgs e)
        {
            //retrives the id of current selected package type
            int parsedPackageId = getMedicationPackageId();
            bool isChecked = false;

            try
            {
                //delegates the job to business domain, to check and update the package's state
                madicationPackageManager.CheckAndUpdatePackage(parsedPackageId, Barcode.Text);
                isChecked = true;
            }
            catch (ENETCareException ex)
            {
                handleMessage(AlertBoxHelper.AlertType.Error, AlertBoxHelper.ALERT_STYLE_DANGER, ex.Message.ToString());
                Barcode.Text = "";
            }

            if (isChecked)
            {
                var message = "Scan Success: Package (with barcode: " + Barcode.Text + ")'s state is updated.";
                handleMessage(AlertBoxHelper.AlertType.Success, AlertBoxHelper.ALERT_STYLE_SUCCESS, message);

                //maintains a list of the ids of scanned packages in current session
                insertBarcodeToSession(Barcode.Text);
                Barcode.Text = "";
            }
        }
        /// <summary>
        /// Audits all the scanned packages, to find lost packages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CommitAuditButton_Click(object sender, EventArgs e)
        {
            var isAudited = false;

            try
            {
                madicationPackageManager.AuditPackages(getMedicationPackageId(), scannedBarcodes);
                isAudited = true;
            }
            catch (ENETCareException ex)
            {
                handleMessage(AlertBoxHelper.AlertType.Error, AlertBoxHelper.ALERT_STYLE_DANGER, ex.Message.ToString());
            }

            if (isAudited)
            {
                var message = "Task Success: Packages scanned in the previous task are audited.";
                handleMessage(AlertBoxHelper.AlertType.Success, AlertBoxHelper.ALERT_STYLE_SUCCESS, message);

                emptyScannedBarcodes();
                syncScannedPackageCounting();
                syncHasActiveAuditTaskInSessionWithControl(null);

            }
        }

        /// <summary>
        /// Starts a new auid task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void StartAuditButton_Click(object sender, EventArgs e)
        {
            var message = "Task Start: A new audit task is started";
            handleMessage(AlertBoxHelper.AlertType.Success, AlertBoxHelper.ALERT_STYLE_SUCCESS, message);

            syncHasActiveAuditTaskInSessionWithControl(true);
        }

        /// <summary>
        /// Cancels current audit task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            var message = "Task Cancelled: The previous task is cancelled.";
            handleMessage(AlertBoxHelper.AlertType.Success, AlertBoxHelper.ALERT_STYLE_SUCCESS, message);
            syncHasActiveAuditTaskInSessionWithControl(null);
            emptyScannedBarcodes();
            syncScannedPackageCounting();
        }

        /// <summary>
        /// Conditionally disables cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CancelButton_PreRender(object sender, EventArgs e)
        {
            disableControlOnCondition(CancelButton.Attributes,null);
        }

        /// <summary>
        /// Conditionally disable package type list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PackageType_PreRender(object sender, EventArgs e)
        {

            disableControlOnCondition(PackageType.Attributes,true);
        }

        /// <summary>
        /// Conditionally disable barcode input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Barcode_PreRender(object sender, EventArgs e)
        {
            disableControlOnCondition(Barcode.Attributes, null);
        }

        private void syncHasActiveAuditTaskInSessionWithControl(bool? hasActiveAuditTask)
        {
            Session["hasActiveAuditTask"] = hasActiveAuditTask;
            buttonsDataBind();
        }

        private void handleMessage(AlertBoxHelper.AlertType alertType, string alertStyle, string alertContent)
        {
            masterPage.ConfigureAlertBox(true, alertStyle, alertType.ToString(), alertContent);
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
            syncScannedPackageCounting();
        }

        private void syncScannedPackageCounting()
        {
            ScannedPackageTotal.Text = scannedBarcodes.Distinct().Count().ToString();
        }

        private int getMedicationPackageId()
        {
            int parsedPackageId = Int32.Parse(PackageType.SelectedValue);
            return parsedPackageId;
        }

        private void syncSessionStoredBarcodes()
        {
            if (Session["storedBarcodes"] == null)
            {
                Session["storedBarcodes"] = scannedBarcodes;
            }
            else
            {
                scannedBarcodes = Session["storedBarcodes"] as List<string>;
            }
        }



        private void disableControlOnCondition(AttributeCollection attributeCollection, bool? condition)
        {
            attributeCollection.Remove("disabled");

            if (Session["hasActiveAuditTask"] as bool? == condition)
                attributeCollection.Add("disabled", "disabled");
        }

    }
}