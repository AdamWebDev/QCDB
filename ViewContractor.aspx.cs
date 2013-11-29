using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Qualified_Contractor_Tracking.Classes;

namespace Qualified_Contractor_Tracking
{
    public partial class ViewContractor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!Page.IsPostBack) {
                int ID = int.Parse(Request.QueryString["ID"]);

                if (Functions.CanEdit())
                    btnEdit.NavURL = "~/EditContractor.aspx?ID=" + ID;
                else
                    btnEdit.Visible = false;

                QCTLinqDataContext db = new QCTLinqDataContext();

                Contractor c = db.Contractors.Single(i => i.ID == ID);
                ltVendorNumber.Text = c.VendorNumber;
                ltCompany.Text = c.Company;
                ltContactName.Text = c.ContactName;
                ltMailingAddress.Text = c.MailingAddress;
                ltTown.Text = c.Town;
                ltPostalCode.Text = c.PostalCode;
                lnkEmail.NavigateUrl = "mailto:" + c.Email;
                lnkEmail.Text = c.Email;
                ltNCContact.Text = c.NCContact;
                notExemptFromAuto.Visible = c.ExemptFromAuto == true ? true : false;
                notExemptFromAuto.Message = c.ExemptFromAuto == true ? "This contractor is exempt from auto insurance: " + c.ExemptFromAutoComments : String.Empty;
                lblContractorNotes.Text = (c.Notes == null || c.Notes.Equals(String.Empty)) ? "No notes for this contractor." : c.Notes;

                rptPhones.DataSource = Contractors.GetPhoneNumbers(ID);
                rptPhones.DataBind();

                rptInsurance.DataSource = Contractors.GetInsurance(ID);
                rptInsurance.DataBind();

                rptAgreements.DataSource = Contractors.GetAgreements(ID);
                rptAgreements.DataBind();

                rptPermits.DataSource = Contractors.GetPermits(ID);
                rptPermits.DataBind();

                rptLicenses.DataSource = Contractors.GetLicenses(ID);
                rptLicenses.DataBind();

                rptJobs.DataSource = Contractors.GetJobs(ID);
                rptJobs.DataBind();

                WSIB w = Contractors.GetWSIB(ID);

                if (w != null)
                {
                    ltWSIBCoverage.Text = w.WSIBCoverage.HasValue ? w.TypeOfWSIB.Value : "---";
                    if (ltWSIBCoverage.Text.Equals("WSIB Clearance Certificate"))
                        phClearance.Visible = true;
                    else if (ltWSIBCoverage.Text.Equals("Independant Operator Letter"))
                        phIndOp.Visible = true;
                    else if (ltWSIBCoverage.Text.Equals("WSIB Exemption"))
                        phWSIBExempt.Visible = true;
                    ltlWSIBCert.Text = w.WSIBCertRecd.ToYesNoString();
                    ltIndOp.Text = w.IndOpLetterRecd.ToYesNoString();
                    ltIDNum.Text = w.IndOpIDNum;
                    ltExemptionRecd.Text = w.WSIBExemptFormRecd.ToYesNoString();
                    ltCompSub.Text = w.AODAFormSubmit.ToYesNoString();
                    ltAODAStandards.Text = w.AODAStandardsCompliance.ToYesNoString();
                    ltNCHSReqd.Text = w.NCHSPolicyReqd.ToYesNoString();
                    phNCHS.Visible = w.NCHSPolicyReqd == null ? false : w.NCHSPolicyReqd.Value;
                    ltNCHSRecd.Text = w.NCHSPolicyRecd.ToYesNoString();
                    ltMoL100Recd.Text = (w.MoL100Recd == null || w.MoL100Recd.Equals(String.Empty)) ? "---" : w.MoL100Recd;
                    ltConHS.Text = (w.HSPolicy == null || w.HSPolicy.Equals(String.Empty)) ? "---" : w.HSPolicy;
                }
            }
        }
    }
}