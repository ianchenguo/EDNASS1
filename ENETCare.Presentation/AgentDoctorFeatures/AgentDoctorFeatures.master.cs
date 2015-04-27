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
    }
}