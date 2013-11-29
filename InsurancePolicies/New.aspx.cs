using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Qualified_Contractor_Tracking.InsurancePolicies
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cID;
            if (int.TryParse(Request.QueryString["cID"], out cID)) {
                if (!Page.IsPostBack)
                    btnCancel.NavURL = "~/EditContractor.aspx?ID=" + cID.ToString() + "#insurance";
            }
            else { // if there isn't a valid cID in the URL, go back to the homepage
                Response.Redirect("~/Default.aspx");
            }
        }

        /// <summary>
        /// Adding an insurance policy!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int cID = int.Parse(Request.QueryString["cID"]);
            Classes.Insurance.AddNewPolicy(cID, NewPolicy);
            Response.Redirect("~/EditContractor.aspx?ID=" + cID + "&msg=insadded#insurance");
        }
    }
}