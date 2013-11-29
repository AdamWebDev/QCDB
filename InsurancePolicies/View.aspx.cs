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
                    lblNonOwnedAuto.Text = ins.NonOwnedAuto.HasValue ? ins.InsuranceNonOwnedAuto.Value : String.Empty;
                    lblCrossLiability.Text = ins.CrossLiability.ToYesNoString();
                    lblNorCountAddIns.Text = ins.NCasAddIns.ToYesNoString();
                    lblPolicyNumber.Text = ins.PolicyNumber;
                    lblPolicyLimit.Text = ins.PolicyLimit1.Value.Equals("Other") ? ins.PolicyLimitOther : ins.PolicyLimit1.Value;
                    lblExpiryDate.Text = ins.ExpiryDate.DisplayDate();
                    lblInsComp.Text = ins.insID.HasValue ? ins.InsuranceCompany1.Name : String.Empty;
                    lblInsEmail.Text = ins.insID.HasValue ? "<a href='mailto:"+ ins.InsuranceCompany1.Email + "'>" + ins.InsuranceCompany1.Email + "</a>" : String.Empty;
                    lblBroker.Text = ins.BrokerID.HasValue ? ins.InsuranceBroker.Name : String.Empty;
                    lblBrokerEmail.Text = ins.BrokerEmailID.HasValue ? "<a href='mailto:" + ins.InsuranceBrokerEmail.Email + "'>" + ins.InsuranceBrokerEmail.Email + "</a>" : String.Empty;
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
                    ltContractorName.Text = Contractors.GetContractorName(ins.cID);

                    

                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}