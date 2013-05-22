using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;

namespace Qualified_Contractor_Tracking.InsurancePolicies
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cID;
            if (int.TryParse(Request.QueryString["cID"], out cID)) {
            
                if (!Page.IsPostBack)
                {
                    // populate Type of Policy dropdown
                    ddTypeOfPolicy.DataSource = Classes.Insurance.GetTypes();
                    ddTypeOfPolicy.DataTextField = "Type";
                    ddTypeOfPolicy.DataValueField = "ID";
                    ddTypeOfPolicy.DataBind();

                    // populate Policy Limit dropdown
                    ddPolicyLimit.DataSource = Classes.Insurance.GetLimits();
                    ddPolicyLimit.DataTextField = "Value";
                    ddPolicyLimit.DataValueField = "ID";
                    ddPolicyLimit.DataBind();

                    //populate insurance company dropdown
                    ddInsuranceCompanies.DataSource = Classes.Insurance.GetInsuranceCompanies();
                    ddInsuranceCompanies.DataTextField = "Name";
                    ddInsuranceCompanies.DataValueField = "ID";
                    ddInsuranceCompanies.DataBind();

                    //populate insurance broker dropdown
                    ddBroker.DataSource = Classes.Insurance.GetInsuranceBrokers();
                    ddBroker.DataTextField = "Name";
                    ddBroker.DataValueField = "ID";
                    ddBroker.DataBind();

                    ddActive.Value = true; // set this by default for easier entry
                    btnCancel.NavURL = "~/EditContractor.aspx?ID=" + cID.ToString() + "#insurance";
                }
            }
            else { // if there isn't a valid cID in the URL, go back to the homepage
                Response.Redirect("~/Default.aspx");
            }
        }

        /// <summary>
        /// Updates form fields and values dependant on the selected insurance company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddInsuranceCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddInsuranceCompanies.SelectedIndex > 0) // if the user has actually selected a company...
            {
                var ins = Classes.Insurance.GetInsuranceCompany(int.Parse(ddInsuranceCompanies.SelectedValue));
                // populate both the email field and the hidden fields used in editing insurance companies
                txtInsEmail.Text = hdnInsEmail.Value = ins.Email; 
                hdnInsName.Value = ins.Name;
                lnkEditIns.Visible = true; // show the "Edit" button!
            }
            else
            {
                hdnInsEmail.Value = hdnInsName.Value = string.Empty; // no company selected, so clear the hidden fields...
                lnkEditIns.Visible = false; // ... and hide the edit button
            }
        }

        /// <summary>
        /// Creates a new insurance company, adds it to the corresponding dropdown as well as populates the email field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmitNewIns_Click(object sender, EventArgs e)
        {
            if (txtNewInsuranceCompanyName.Text.Length > 0) // ensure that the user has actually selected a company to edit...
            {
                QCTLinqDataContext db = new QCTLinqDataContext();
                // create the insurance company...
                InsuranceCompany ins = new InsuranceCompany
                {
                    Name = txtNewInsuranceCompanyName.Text,
                    Email = txtNewInsComEmail.Text,
                    Active = true
                };
                // add the ins company to the database
                db.InsuranceCompanies.InsertOnSubmit(ins);
                db.SubmitChanges();

                // now, add the newly added ins company to the dropdown and select it.
                ddInsuranceCompanies.Items.Add(new ListItem(ins.Name, ins.ID.ToString()));
                ddInsuranceCompanies.SelectedValue = ins.ID.ToString();
                txtInsEmail.Text = ins.Email; // populate the ins company email address...
                // clear the fields used in creating the insurance company
                txtNewInsuranceCompanyName.Text = txtNewInsComEmail.Text = String.Empty; 
            }
        }

        /// <summary>
        /// Update an insurance company!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditIns_Click(object sender, EventArgs e)
        {
            if (ddInsuranceCompanies.SelectedIndex > 0) // ensure that an ins company has been selected
            {
                QCTLinqDataContext db = new QCTLinqDataContext();
                int ID = int.Parse(ddInsuranceCompanies.SelectedValue);
                // get the insurance company in question
                InsuranceCompany ins = db.InsuranceCompanies.Where(i => i.ID == ID).Single();
                // update the fields accordingly.
                ins.Name = txtNewInsuranceCompanyName.Text;
                ins.Email = txtNewInsComEmail.Text;
                db.SubmitChanges(); // save changes
                // let's repopulate the dropdown with the updated information.
                ddInsuranceCompanies.Items.Clear();
                ddInsuranceCompanies.Items.Add(new ListItem("--Select--", ""));
                ddInsuranceCompanies.DataSource = Classes.Insurance.GetInsuranceCompanies();
                ddInsuranceCompanies.DataTextField = "Name";
                ddInsuranceCompanies.DataValueField = "ID";
                ddInsuranceCompanies.DataBind();
                ddInsuranceCompanies.SelectedValue = ID.ToString(); // and select the current insurance company
                // update the appropriate fields..
                txtInsEmail.Text = hdnInsEmail.Value = ins.Email; 
                hdnInsName.Value = ins.Name;
            }
        }

        /// <summary>
        /// When changing brokers, update the broker email to associate this insurane policy with a person
        /// at the insurance broker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddBroker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddBroker.SelectedIndex > 0) // ensure a broker is selected
            {
                int bID = int.Parse(ddBroker.SelectedValue);
                ddBrokerEmail.Items.Clear(); // clear the dropdown each time
                var emails = Classes.Insurance.GetInsuranceBrokerEmails(bID); // get the email addresses
                ddBrokerEmail.DataSource = emails;
                ddBrokerEmail.DataTextField = "Email";
                ddBrokerEmail.DataValueField = "ID";
                // the initial item will show a count of how many emails are associated with the insurance company
                ddBrokerEmail.Items.Add(new ListItem(emails.Count + " email(s) found", "")); 
                ddBrokerEmail.DataBind();
            }
            else // if no broker is selected, clear the email list.
            {
                ddBrokerEmail.Items.Clear();
                ddBrokerEmail.Items.Add(new ListItem("--Please select a broker--", String.Empty));
            }
        }

        /// <summary>
        /// Adding an insurance policy!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            int cID = int.Parse(Request.QueryString["cID"]);
            // create and populate!
            Insurance ins = new Insurance();
            ins.cID = cID;
            ins.TenantsLegalLiability = ddTenantsLiability.Value;
            ins.CertReqFor = txtCertReq.Text;
            ins.TypeOfPolicy = ddTypeOfPolicy.SelectedIndex > 0 ? int.Parse(ddTypeOfPolicy.SelectedValue) : (int?)null;
            ins.PerOccurance = ddPerOccurance.Value;
            ins.ProductsCompletedOps = ddProductsCompletedOps.Value;
            ins.NonOwnedAuto = ddNonOwnedAuto.Value;
            ins.CrossLiability = ddCrossLiability.Value;
            ins.NCasAddIns = ddNCasAddIns.Value;
            ins.PolicyNumber = txtPolicyNumber.Text;
            ins.PolicyLimit = ddPolicyLimit.SelectedIndex > 0 ? int.Parse(ddPolicyLimit.SelectedValue) : (int?)null;
            ins.PolicyLimitOther = txtPolicyLimitOther.Text;
            ins.ExpiryDate = dddExpiryDate.Date;
            ins.insID = ddInsuranceCompanies.SelectedIndex > 0 ? int.Parse(ddInsuranceCompanies.SelectedValue) : (int?)null;
            ins.BrokerID = ddBroker.SelectedIndex > 0 ? int.Parse(ddBroker.SelectedValue) : (int?)null;
            ins.BrokerEmailID = ddBrokerEmail.SelectedIndex > 0 ? int.Parse(ddBrokerEmail.SelectedValue) : (int?)null;
            ins.CertSigned = ddCertSigned.Value;
            ins.Active = ddActive.Value;
            // save to database!
            db.Insurances.InsertOnSubmit(ins);
            db.SubmitChanges();

            // let's look at the uploaded file
            if (uploadCert.UploadedFiles.Count > 0) // see if there's a file to attach...
            {
                String directory = Server.MapPath("uploads");
                directory = directory + "/" + ins.ID.ToString(); // build the path to the file upload
                // if the directory doesn't exist already, create it
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                // upload the file and rename it to attachment.pdf
                foreach (UploadedFile file in uploadCert.UploadedFiles)
                {
                    file.SaveAs(directory + "/attachment" + file.GetExtension(), true);
                    String filelnk = "uploads/" + ins.ID.ToString() + "/attachment.pdf";
                    lnkFiles.NavigateUrl = filelnk;
                    lnkFiles.Text = "View attachment";
                }
            }
            // once we're done, redirect to the insurance page!!
            Response.Redirect("~/EditContractor.aspx?ID=" + cID + "&msg=insadded#insurance");
        }
    }
}