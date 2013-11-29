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
            int ID, cID;
            if (int.TryParse(Request.QueryString["ID"], out ID) && int.TryParse(Request.QueryString["cID"], out cID)) {
                btnCancel.NavURL = "~/EditContractor.aspx?ID=" + cID.ToString() + "#insurance";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            int cID = int.Parse(Request.QueryString["cID"]);
            Classes.Insurance.EditPolicy(ID, EditInsurance);
            Response.Redirect("~/EditContractor.aspx?ID=" + cID + "&msg=insedited#insurance");
        }

        protected void lnkConfirmDelete_Click(object sender, EventArgs e)
        {
            if (Classes.Insurance.DeletePolicy(int.Parse(Request.QueryString["ID"])))
            {
                Response.Redirect("~/EditContractor.aspx?ID=" + Request.QueryString["cID"] + "#insurance");
            }
            else
            {
                notIns.Message = "Oops - something went wrong when we tried to delete this policy!";
                notIns.Type = "error";
                notIns.Visible = true;
            }
        }

    }
}