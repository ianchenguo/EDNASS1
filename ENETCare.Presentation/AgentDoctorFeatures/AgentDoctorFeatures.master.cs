using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using ENETCare.Presentation.Models;

namespace ENETCare.Presentation.AgentDoctorFeatures
{
    public partial class AgentDoctorFeatures : System.Web.UI.MasterPage
    {
        /// <summary>
        /// If current user's role is doctor, show distribute package feature on the task list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.IsInRole("Doctor"))
            {
                DoctorDistributPackageItem.Visible = false;
            }
        }
        /// <summary>
        /// Configures alert box's attributes and contents
        /// </summary>
        /// <param name="isVisible">decides if the alert box should be shown</param>
        /// <param name="alertStyle">sets alert style</param>
        /// <param name="alertTitle">sets alert title</param>
        /// <param name="alertContent">sets alert content</param>
        internal void ConfigureAlertBox(bool isVisible, string alertStyle, string alertTitle, string alertContent)
        {
            string defaultStyles= "alert alert-dismissible fade in";

            AlertBox.Visible = isVisible;
            AlertBox.Attributes["Class"] = defaultStyles + " " + alertStyle;
            AlertBoxTitle.InnerText = alertTitle;
            AlertBoxContent.InnerText = alertContent;
        }

        /// <summary>
        /// Only configures whether the alert box should be shown
        /// </summary>
        /// <param name="isVisible">decides if the alert box should be shown</param>
        internal void ConfigureAlertBox(bool isVisible)
        {
            AlertBox.Visible = isVisible;
        }
    }
}