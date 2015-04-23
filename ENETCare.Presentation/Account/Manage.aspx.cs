using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using ENETCare.Presentation.Models;

namespace ENETCare.Presentation.Account
{
    public partial class Manage : System.Web.UI.Page
    {

        private ApplicationUserManager manager;
        private ApplicationUser user;
        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }

        protected void ChangeInfo_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //Instantiates user manager
                manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                //retrieves user account
                user = manager.FindById(User.Identity.GetUserId());
                //updates general user info
                user.FullName = FullName.Text;
                user.Email = user.UserName = Email.Text;
                user.DistributionCentreID = Int32.Parse(DistributionCentre.SelectedValue);
                //user.DistributionCentre = DistributionCentre.Text;
                IdentityResult result = manager.Update(user);
                //updates user password
                result = manager.ChangePassword(User.Identity.GetUserId(), CurrentPassword.Text, NewPassword.Text);
                //relogins the user
                if (result.Succeeded)
                {
                    IdentityHelper.SignIn(manager, user, isPersistent: false);
                    Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else
                {
                    AddErrors(result);
                }
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected void DistributionCentre_PreRender(object sender, EventArgs e)
        {
            //Instantiates user manager
            manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //retrieves user account
            user = manager.FindById(User.Identity.GetUserId());
            //selects the user's current centre (IDs begins from 1)
            DistributionCentre.SelectedIndex = user.DistributionCentreID - 1;
        }
    }
}