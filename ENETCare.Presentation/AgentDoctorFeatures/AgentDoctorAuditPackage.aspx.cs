using ENETCare.Business;
using ENETCare.Presentation.HelperUtilities;
using ENETCare.Presentation.Layout;
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
        private Features baseMasterPage;

        /// <summary>
        /// syncronises local scanned package list with stored list in current session,
        /// updates display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            madicationPackageManager = new MedicationPackageBLL(User.Identity.Name);

            baseMasterPage = Page.Master.Master as Features;
            baseMasterPage.ConfigureAlertBox(false);

            syncPendingScannedListFromSession();
        }
        /// <summary>
        /// updates control apperance during page rendering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Page_PreRender(object sender, EventArgs e)
        {
            bindControlData();

        }

        /// <summary>
        /// Scans a packages and updates its state in storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ScanPackageButton_Click(object sender, EventArgs e)
        {
            //retrives the id of current selected package type
            int currentPackageId = getMedicationPackageId();
            bool isScanSucceeded = false;

            try
            {
                //delegates work to domain logic, to check and update the package's state
                madicationPackageManager.CheckAndUpdatePackage(currentPackageId, Barcode.Text);
                isScanSucceeded = true;
            }
            catch (ENETCareException ex)
            {
                handleMessage(AlertBoxHelper.AlertType.Error, AlertBoxHelper.ALERT_STYLE_DANGER, ex.Message.ToString());
                Barcode.Text = "";
            }

            if (isScanSucceeded)
            {
                string message;
                insertCurrentBarcodeToPendingListInSession(Barcode.Text);

                message =
                    "The state of the package with barcode " + Barcode.Text + " is updated." +
                    "<br/>The pending list contains " + scannedBarcodes.Distinct().Count().ToString() + " package(s)";
                handleMessage(AlertBoxHelper.AlertType.Success, AlertBoxHelper.ALERT_STYLE_SUCCESS, message);
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
                updateAuditTaskStateInSession(null);
                Barcode.Text = "";
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
           updateAuditTaskStateInSession(true);
        }

        /// <summary>
        /// Cancels current audit task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            var message = "Task Cancelled: The previous task is cancelled.";
            handleMessage(AlertBoxHelper.AlertType.Success, AlertBoxHelper.ALERT_STYLE_WARNING, message);
            updateAuditTaskStateInSession(null);
            emptyScannedBarcodes();
        }

        /// <summary>
        /// Conditionally disables cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CancelButton_PreRender(object sender, EventArgs e)
        {
            disableControlOnCondition(CancelButton.Attributes, null);
        }

        /// <summary>
        /// Conditionally disables package type list, and stores current package type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PackageType_PreRender(object sender, EventArgs e)
        {
            disableControlOnCondition(CancelButton.Attributes, null);

            //if (Session["hasActiveAuditTask"] == null)
            //{
            //    Session["AuditTaskPackageTypeId"] = PackageType.SelectedValue;
            //}

            //disableControlOnCondition(PackageType.Attributes, true);

            //if (Session["AuditTaskPackageTypeId"] != null)
            //{
            //    PackageType.SelectedValue = Session["AuditTaskPackageTypeId"] as string;
            //}

        }

        /// <summary>
        /// Conditionally disables barcode input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Barcode_PreRender(object sender, EventArgs e)
        {
            disableControlOnCondition(Barcode.Attributes, null);
        }

        private void updateAuditTaskStateInSession(bool? hasActiveAuditTask)
        {
            Session["hasActiveAuditTask"] = hasActiveAuditTask;
        }

        private void handleMessage(AlertBoxHelper.AlertType alertType, string alertStyle, string alertContent)
        {
            baseMasterPage.ConfigureAlertBox(true, alertStyle, alertType.ToString(), alertContent);
        }

        private void emptyScannedBarcodes()
        {
            Session["storedBarcodes"] = null;
            scannedBarcodes = new List<string>();
        }

        private void insertCurrentBarcodeToPendingListInSession(string barcode)
        {
            scannedBarcodes.Add(barcode);
            Session["storedBarcodes"] = scannedBarcodes;

        }

        private int getMedicationPackageId()
        {
            int parsedPackageId = Int32.Parse(PackageType.SelectedValue);
            return parsedPackageId;
        }

        private void syncPendingScannedListFromSession()
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

        private void bindControlData()
        {
            ScanPackageButton.DataBind();
            StartAuditButton.DataBind();
            CancelButton.DataBind();
            CommitAuditButton.DataBind();
        }


    }
}