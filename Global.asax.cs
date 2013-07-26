using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Qualified_Contractor_Tracking
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }
    }

    public static class BooleanExtensions
    {
        public static string ToYesNoString(this bool? value)
        {
            switch (value)
            {
                case true: return "Yes";
                case false: return "No";
                default: return "---";
            }
        }
    }

    public static class DateTimeExtensions
    {
        public static string DisplayDate(this DateTime value)
        {
            return value.ToString("MMMM dd, yyyy");
        }

        public static string DisplayDate(this DateTime? value)
        {
            if (value == null)
                return String.Empty;
            else
            {
                return DisplayDate((DateTime)value);
            }
        }
    }
}
