using ENETCare.Presentation.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENETCare.Presentation.HelperUtilities
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

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the "Agent" role if it doesn't already exist.
            string[] roleNames = { "Agent", "Doctor", "Manager" };

            for (int i = 0; i < roleNames.Length; i++)
            {
                if (!roleMgr.RoleExists(roleNames[i]))
                {
                    IdRoleResult = roleMgr.Create(new IdentityRole { Name = roleNames[i] });
                }
            }
        }
    }
}