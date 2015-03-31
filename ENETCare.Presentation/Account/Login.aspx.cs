using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using ENETCare.Presentation.Models;

namespace ENETCare.Presentation.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            
            //what's the following section for?////////////////
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
            /////////////////////////////////////////////////
        }

        protected void LogIn(object sender, EventArgs e)
        {
            //what's this for?
            if (IsValid)
            {
                // Validates the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.Find(Email.Text, Password.Text);
                if (user != null)
                {
                    //signs in the user
                    IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                    //redirects the route
                    //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    var userRoles = manager.GetRoles(user.Id);
                    IdentityHelper.RedirectToReturnUrl(Page.ResolveUrl("~/" + userRoles[0] + "Features/" + userRoles[0] + "Home.aspx"), Response);
                }
                else
                {
                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}