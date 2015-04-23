using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using ENETCare.Presentation.Models;
using ENETCare.Business;

namespace ENETCare.Presentation.Account
{
    public partial class Register : Page
    {
        //Creates a new account,
        //adopted from official template
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //Instantiates a user manager
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            //Instantiates an application user, with submitted user info
            var user = new ApplicationUser()
            {
                FullName = FullName.Text,
                UserName = Email.Text,
                Email = Email.Text,
                DistributionCentreID = Int32.Parse(DistributionCentre.SelectedValue)
            };


            //identifies user role from user selection
            var userRole = Role.SelectedItem.Text;

            //creates an account in database
            IdentityResult result = manager.Create(user, Password.Text);

            //adds the account to selected role, if the account is successfully created
            if (result.Succeeded)
            {
                result = manager.AddToRole(manager.FindByEmail(Email.Text).Id, userRole);

                //Signs in the user
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                //redirect the account to corresponding homepage, if the role is successfully linked
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                IdentityHelper.RedirectToReturnUrl(Page.ResolveUrl("~/" + userRole + "Features/" + userRole + "Home.aspx"), Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}