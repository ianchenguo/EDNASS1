using ENETCare.Presentation.HelperUtilities;
using ENETCare.Presentation.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENETCare.Presentation.ManagerFeatures
{
    public partial class ManagerDistributionCenterCenters : System.Web.UI.Page
    {
        private Features baseMasterPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            baseMasterPage = Page.Master.Master as Features;

        }


        protected void On_Distribution_Centres_Bound(object sender, EventArgs e)
        {
            DistributionCentresView.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void DistributionCentresSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                baseMasterPage.ConfigureAlertBox(
                    true,
                    AlertBoxHelper.AlertType.Error.ToString(),
                    AlertBoxHelper.ALERT_STYLE_DANGER,
                    e.Exception.Message.ToString()
                    );

                e.ExceptionHandled = true;
            }
        }

    }
}