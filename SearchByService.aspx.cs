using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qualified_Contractor_Tracking
{
    public partial class SearchByService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack && txtSearch.Text.Length > 0)
            {
                var results = Classes.Contractors.GetContractorsByService(txtSearch.Text);
                if (results.Count > 0)
                {
                    rptContractor.DataSource = results;
                    rptContractor.DataBind();
                    rptContractor.Visible = true;
                    phEmpty.Visible = false;
                }
                else
                {
                    phEmpty.Visible = true;
                    rptContractor.Visible = false;
                }
            }
        }
    }
}