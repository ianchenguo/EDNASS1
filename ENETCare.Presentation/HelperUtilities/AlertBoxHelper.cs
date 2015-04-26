using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENETCare.Presentation.HelperUtilities
{
    public class AlertBoxHelper
    {
        public const string ALERT_STYLE_SUCCESS = "alert-success";
        public const string ALERT_STYLE_DANGER = "alert-danger";
        public const string ALERT_STYLE_WARNING = "alert-warning";


        public enum AlertType
        {
            Success,
            Error
        };
    }
}