using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENETCare.Presentation.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ENETCare.Presentation.Logic
{
    internal class RoleActions
    {
        internal void AddRoles()
        {
            //the following section is adopted from 
            //http://www.asp.net/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/membership-and-administration

            // Access the application context and create result variables.
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            //IdentityResult IdUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the "Agent" role if it doesn't already exist.
            string[] roleNames = {"Agent", "Doctor", "Manager"};

            for (int i = 0; i < roleNames.Length; i++)
            {
                if (!roleMgr.RoleExists(roleNames[i]))
                {
                    IdRoleResult = roleMgr.Create(new IdentityRole { Name = roleNames[i] });
                }
            }

            //// Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            //// object. Note that you can create new objects and use them as parameters in
            //// a single line of code, rather than using multiple lines of code, as you did
            //// for the RoleManager object.
            //var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //var appUser = new ApplicationUser
            //{
            //    UserName = "canEditUser@wingtiptoys.com",
            //    Email = "canEditUser@wingtiptoys.com"
            //};
            //IdUserResult = userMgr.Create(appUser, "Pa$$word1");

            //// If the new "canEdit" user was successfully created, 
            //// add the "canEdit" user to the "canEdit" role. 
            //if (!userMgr.IsInRole(userMgr.FindByEmail("canEditUser@wingtiptoys.com").Id, "canEdit"))
            //{
            //    IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("canEditUser@wingtiptoys.com").Id, "canEdit");
            //}
        }
    }
}