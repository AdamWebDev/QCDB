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
                    ltWSIBCoverage.Text = w.TypeOfWSIB.Value;
                    if (ltWSIBCoverage.Text.Equals("WSIB Clearance Certificate"))
                        phClearance.Visible = true;
                    else if (ltWSIBCoverage.Text.Equals("Independant Operator Letter"))
                        phIndOp.Visible = true;
                    else if (ltWSIBCoverage.Text.Equals("WSIB Exemption"))
                        phWSIBExempt.Visible = true;
                    ltlWSIBCert.Text = w.WSIBCertRecd.ToYesNoString();
                    ltCertNum.Text = w.WSIBCertNum;
                    ltCertEffDate.Text = w.WSIBEffDate.DisplayDate();
                    ltCertExpDate.Text = w.WSIBExpDate.DisplayDate();
                    ltCertDesc.Text = w.CertDescr;
                    ltIndOp.Text = w.IndOpLetterRecd.ToYesNoString();
                    ltIDNum.Text = w.IndOpIDNum;
                    ltExemptionRecd.Text = w.WSIBExemptFormRecd.ToYesNoString();
                    ltCompSub.Text = w.AODAFormSubmit.ToYesNoString();
                    ltNCHS.Text = w.NCHSPolicy.ToYesNoString();
                    ltConHS.Text = w.HSPolicy;

                }
            }
        }
    }
}