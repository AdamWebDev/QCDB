using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qualified_Contractor_Tracking.InsurancePolicies
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Classes.Functions.SecurePage(); // only allow certain people to edit
            int ID;
            if (int.TryParse(Request.QueryString["ID"], out ID)) {
                btnDelete.NavURL = "~/InsurancePolicy/Delete.aspx?ID=" + ID.ToString();
                //btnCancel.NavURL = "~/EditContractor.aspx?ID=" + ins.cID.ToString() + "#insurance";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            int cID = int.Parse(Request.QueryString["cID"]);
            Classes.Insurance.EditPolicy(ID, EditInsurance);
            Response.Redirect("~/EditContractor.aspx?ID=" + cID + "&msg=insedited#insurance");
        }
    }
}