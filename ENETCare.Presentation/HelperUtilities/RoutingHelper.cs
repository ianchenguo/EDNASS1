using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENETCare.Presentation.HelperUtilities
{
    public static class RoutingHelper
    {
        public static string ResolveHomePath(string userPrimaryRole)
        {
            if (userPrimaryRole == "Agent" || userPrimaryRole == "Doctor")
            {
                return "~/AgentDoctorFeatures/AgentDoctorHome.aspx";
            }
            else if (userPrimaryRole == "Manager")
            {
                return "~/ManagerFeatures/ManagerHome.aspx";
            }
            else
            {
                return "~/Index.aspx";
            }
        }
    }
}