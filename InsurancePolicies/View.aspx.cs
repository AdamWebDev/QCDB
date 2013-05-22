using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qualified_Contractor_Tracking.Classes;
using System.IO;


namespace Qualified_Contractor_Tracking.InsurancePolicies
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
            {
                int ID;
                if (int.TryParse(Request.QueryString["ID"], out ID))
                {
                    InsurancePolicy ins = Insurance.GetPolicy(ID);
                    lblCertReq.Text = ins.CertReqFor;
                    lblTypeOfPolicy.Text = ins.TypeOfPolicy1.Type;
                    lblTenantsLegalLiability.Text = ins.TenantsLegalLiability.ToYesNoString();
                    lblPerOccurance.Text = ins.PerOccurance.ToYesNoString();
                    lblProductsCompletedOps.Text = ins.ProductsCompletedOps.ToYesNoString();
                    lblNonOwnedAuto.Text = ins.NonOwnedAuto.ToYesNoString();
                    lblCrossLiability.Text = ins.CrossLiability.ToYesNoString();
                    lblNorCountAddIns.Text = ins.NCasAddIns.ToYesNoString();
                    lblPolicyNumber.Text = ins.PolicyNumber;
                    lblPolicyLimit.Text = ins.PolicyLimit1.Value.Equals("Other") ? ins.PolicyLimitOther : ins.PolicyLimit1.Value;
                    lblExpiryDate.Text = ins.ExpiryDate.DisplayDate();
                    lblInsComp.Text = ins.InsuranceCompany1.Name;
                    lblInsEmail.Text = "<a href='"+ ins.InsuranceCompany1.Email + "'>" + ins.InsuranceCompany1.Email + "</a>";
                    lblBroker.Text = ins.InsuranceBroker.Name;
                    lblBrokerEmail.Text = ins.BrokerEmailID.HasValue ? ins.InsuranceBrokerEmail.Email : "No email address";
                    lblCertSigned.Text = ins.CertSigned.ToYesNoString();

                    // build the paths for the file and the link to it.
                    String filelnk = "uploads/" + ID.ToString() + "/attachment.pdf";
                    String directory = Server.MapPath("uploads");
                    String filepath = directory + "/" + ID.ToString() + "/attachment.pdf";
                    if (File.Exists(filepath)) // only show it if there is an attached file.
                    {
                        lnkFiles.NavigateUrl = filelnk;
                        lnkFiles.Text = "View attachment";
                    }
                    ltContractorName.Text = ins.Contractor.ContactName;
                    

                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}