using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qualified_Contractor_Tracking.Classes;

namespace Qualified_Contractor_Tracking
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["view"]))
            {
                if (Request.QueryString["view"].Equals("available"))
                    rptContractor.DataSource = Contractors.GetContractors(String.Empty,true);
                else
                    rptContractor.DataSource = Contractors.GetContractors(String.Empty);
            }
            else
                rptContractor.DataSource = Contractors.GetContractors(String.Empty);
            
            rptContractor.DataBind();

            if (Functions.CanEdit())
                btnNewContractor.Visible = true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            rptContractor.DataSource = Contractors.GetContractors(txtSearch.Text);
            rptContractor.DataBind();
        }
    }
}