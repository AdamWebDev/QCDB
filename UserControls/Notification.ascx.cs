using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qualified_Contractor_Tracking
{
    public partial class Notification : System.Web.UI.UserControl
    {
        private String _type = "information";
        public String Type
        {
            set { _type = value;
            switch (_type.ToLower())
            {
                case "attention":
                    pnNotification.CssClass = "notification attention png_bg";
                    break;
                case "success":
                    pnNotification.CssClass = "notification success png_bg";
                    break;
                case "error":
                    pnNotification.CssClass = "notification error png_bg";
                    break;
                default:
                    pnNotification.CssClass = "notification information png_bg";
                    break;
            }
            
            }
        }

        public String Message
        {
            set { ltMessage.Text = value; }
        }

    }
}


            