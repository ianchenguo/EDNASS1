using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENETCare.Presentation.HelperUtilities;

namespace ENETCareTest.WebformHelpersTest
{
    [TestClass]
    public class RoutingHelperTest
    {
        [TestMethod]
        public void ResolveHomePath_Doctor_ShouldBeAgentDoctorHome()
        {
            var roleLiteral = "Doctor";
            Assert.AreEqual(RoutingHelper.ResolveHomePath(roleLiteral), "~/AgentDoctorFeatures/AgentDoctorHome.aspx");
        }

        [TestMethod]
        public void ResolveHomePath_Agent_ShouldBeAgentDoctorHome()
        {
            var roleLiteral = "Agent";
            Assert.AreEqual(RoutingHelper.ResolveHomePath(roleLiteral), "~/AgentDoctorFeatures/AgentDoctorHome.aspx");
        }

        [TestMethod]
        public void ResolveHomePath_Manager_ShouldBeManagerHome()
        {
            var roleLiteral = "Manager";
            Assert.AreEqual(RoutingHelper.ResolveHomePath(roleLiteral), "~/ManagerFeatures/ManagerHome.aspx");
        }

        [TestMethod]
        public void ResolveHomePath_Anonymous_ShouldBeIndex()
        {
            var roleLiteral = "";
            Assert.AreEqual(RoutingHelper.ResolveHomePath(roleLiteral), "~/Index.aspx");
        }
    }
}
