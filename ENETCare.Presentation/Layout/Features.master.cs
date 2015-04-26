using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.Presentation.Layout
{
    public partial class Features : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Configures alert box's attributes and contents
        /// </summary>
        /// <param name="isVisible">decides if the alert box should be shown</param>
        /// <param name="alertStyle">sets alert style</param>
        /// <param name="alertTitle">sets alert title</param>
        /// <param name="alertContent">sets alert content</param>
        public void ConfigureAlertBox(bool isVisible, string alertStyle, string alertTitle, string alertContent)
        {
            string defaultStyles = "alert alert-dismissible fade in";

            AlertBox.Visible = isVisible;
            AlertBox.Attributes["Class"] = defaultStyles + " " + alertStyle;
            AlertBoxTitle.InnerHtml = alertTitle;
            AlertBoxContent.InnerHtml = alertContent;
        }

        /// <summary>
        /// Only configures whether the alert box should be shown
        /// </summary>
        /// <param name="isVisible">decides if the alert box should be shown</param>
        public void ConfigureAlertBox(bool isVisible)
        {
            AlertBox.Visible = isVisible;
        }
    }
}