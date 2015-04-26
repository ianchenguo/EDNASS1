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
        private string currentPackageType = "";
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
            syncPendingPackageTypeFromSession();
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
        /// Scans a package and updates its state in storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ScanPackageButton_Click(object sender, EventArgs e)
        {
            //retrieves the id of current selected package type
            int currentPackageId = getMedicationPackageId();
            bool isPackageStateUpdated = false;
            string updateFeedback = "";

            try
            {
                //delegates work to domain logic, to check and update the package's state
                isPackageStateUpdated = madicationPackageManager.CheckAndUpdatePackage(currentPackageId, Barcode.Text);
                updateFeedback = selectFeedbackBasedOnState(isPackageStateUpdated, updateFeedback);
                handleMessage(AlertBoxHelper.AlertType.Success, AlertBoxHelper.ALERT_STYLE_SUCCESS, updateFeedback);
                insertCurrentBarcodeToPendingListInSession(Barcode.Text);
            }
            catch (ENETCareException ex)
            {
                handleMessage(AlertBoxHelper.AlertType.Error, AlertBoxHelper.ALERT_STYLE_DANGER, ex.Message.ToString());
            }
            finally
            {
                Barcode.Text = "";
            }
        }

        private static string selectFeedbackBasedOnState(bool isPackageStateUpdated, string updateFeedback)
        {
            if (isPackageStateUpdated)
            {
                updateFeedback = "Package state is updated.";
            }
            else
            {
                updateFeedback = "Package state remains the same.";
            }
            return updateFeedback;
        }

        /// <summary>
        /// Audits all the scanned packages, to find lost packages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CommitAuditButton_Click(object sender, EventArgs e)
        {
            try
            {
                ViewState["lostPackages"] = madicationPackageManager.AuditPackages(getMedicationPackageId(), scannedBarcodes);
                //LostList.DataSource = ViewState["LostPackages"] as List<MedicationPackage>;
                var message = "Scanned packages were audited.";
                handleMessage(AlertBoxHelper.AlertType.Success, AlertBoxHelper.ALERT_STYLE_SUCCESS, message);
                emptyScannedBarcodes();
                emptyCurrentPackageType();
                updateAuditTaskStateInSession(null);
            }
            catch (ENETCareException ex)
            {
                handleMessage(AlertBoxHelper.AlertType.Error, AlertBoxHelper.ALERT_STYLE_DANGER, ex.Message.ToString());
            }
            finally
            {
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
            emptyCurrentPackageType();
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
            disableControlOnCondition(PackageType.Attributes, true);
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


        protected void PendingList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PendingList.PageIndex = e.NewPageIndex;
        }

        protected void LostList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LostList.PageIndex = e.NewPageIndex;
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

        private void emptyCurrentPackageType()
        {
            Session["storedPackageType"] = null;
            currentPackageType = "";
        }

        private void insertCurrentBarcodeToPendingListInSession(string barcode)
        {
            scannedBarcodes.Add(barcode);
            Session["storedBarcodes"] = new List<string>(scannedBarcodes.Distinct());
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

        private void syncPendingPackageTypeFromSession()
        {
            //only stores a package type after the user posts for the first time
            if (IsPostBack)
            {
                if (Session["storedPackageType"] == null)
                {
                    Session["storedPackageType"] = PackageType.SelectedValue;
                }
                else
                {
                    currentPackageType = Session["storedPackageType"] as string;
                    PackageType.SelectedValue = currentPackageType;
                }
            }
            else
            {
                if (Session["storedPackageType"] != null)
                {
                    currentPackageType = Session["storedPackageType"] as string;
                    PackageType.SelectedValue = currentPackageType;
                }
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
            PendingListPanel.DataBind();
            PendingList.DataBind();
            LostListPanel.DataBind();
            LostList.DataBind();
        }

    }
}