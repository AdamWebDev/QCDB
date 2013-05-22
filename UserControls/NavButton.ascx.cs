using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qualified_Contractor_Tracking
{
    public partial class NavButton : System.Web.UI.UserControl
    {

           public String NavURL
        {
            set { lnkLink.NavigateUrl = value; }
        }

        public String Icon
        {
            set { imgIcon.ImageUrl = value;}
        }

        public String Text
        {
            set { ltText.Text = value; }
        }

        public String AltText {
            set { imgIcon.AlternateText = value; }
        }

        
    }
}