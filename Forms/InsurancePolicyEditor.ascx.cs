using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Qualified_Contractor_Tracking.Classes;
using Telerik.Web.UI;
using System.IO;

namespace Qualified_Contractor_Tracking.UserControls
{
    public partial class InsurancePolicyEditor : System.Web.UI.UserControl
    {
        public enum Modes { New, Edit }

        public Modes Mode { get; set; }

        public string CertificateRequestFor
        {
            get { return txtCertReq.Text; }
            set { txtCertReq.Text = value; }
        }

        public int? TypeOfPolicy 
        {
            get { return ddTypeOfPolicy.SelectedIndex > 0 ? int.Parse(ddTypeOfPolicy.SelectedValue) : (int?)null; }
            set { ddTypeOfPolicy.SelectedValue = value.HasValue ? value.ToString() : String.Empty;  }
        }

        public bool? TenantsLiability
        {
            get { return ddTenantsLiability.Value; }
            set { ddTenantsLiability.Value = value; }
        }

        public bool? PerOccurance
        {
            get { return ddPerOccurance.Value; }
            set { ddPerOccurance.Value = value; }
        }

        public bool? ProductsCompletedOps
        {
            get { return ddProductsCompletedOps.Value; }
            set { ddProductsCompletedOps.Value = value; }
        }

        public bool? NonOwnedAuto
        {
            get { return ddNonOwnedAuto.Value; }
            set { ddNonOwnedAuto.Value = value; }
        }

        public bool? CrossLiability
        {
            get { return ddCrossLiability.Value; }
            set { ddCrossLiability.Value = value; }
        }

        public bool? NorfolkCountyAsAdditionallyInsured
        {
            get { return ddNCasAddIns.Value; }
            set { ddNCasAddIns.Value = value; }
        }

        public string PolicyNumber
        {
            get { return txtPolicyNumber.Text; }
            set { txtPolicyNumber.Text = value; }
        }

        public int? PolicyLimit
        {
            get { return ddPolicyLimit.SelectedIndex > 0 ? int.Parse(ddPolicyLimit.SelectedValue) : (int?)null; }
            set { ddPolicyLimit.SelectedValue = value.HasValue ? value.ToString() : String.Empty; }
        }

        public string PolicyLimitOther
        {
            get { return txtPolicyLimitOther.Text; }
            set { txtPolicyLimitOther.Text = value; }
        }

        public DateTime? ExpiryDate
        {
            get { return dddExpiryDate.Date; }
            set { dddExpiryDate.Date = value; }
        }

        public int? InsuranceCompany
        {
            get { return ddInsuranceCompanies.SelectedIndex > 0 ? int.Parse(ddInsuranceCompanies.SelectedValue) : (int?)null; }
            set { ddInsuranceCompanies.SelectedValue = value.HasValue ? value.ToString() : String.Empty; }
        }

        public int? Broker
        {
            get { return ddBroker.SelectedIndex > 0 ? int.Parse(ddBroker.SelectedValue) : (int?)null; }
            set { ddBroker.SelectedValue = value.HasValue ? value.ToString() : String.Empty; }
        }

        public int? BrokerEmail
        {
            get { return ddBrokerEmail.SelectedIndex > 0 ? int.Parse(ddBrokerEmail.SelectedValue) : (int?)null; }
            set { ddBrokerEmail.SelectedValue = value.HasValue ? value.ToString() : String.Empty; }
        }

        public bool? CertificateSigned
        {
            get { return ddCertSigned.Value; }
            set { ddCertSigned.Value = value; }
        }

        public bool? Active
        {
            get { return ddActive.Value; }
            set { ddActive.Value = value; }
        }

        public UploadedFileCollection Files
        {
            get { return uploadCert.UploadedFiles; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // populate Type of Policy dropdown
                ddTypeOfPolicy.DataSource = Insurance.GetTypes();
                ddTypeOfPolicy.DataTextField = "Type";
                ddTypeOfPolicy.DataValueField = "ID";
                ddTypeOfPolicy.DataBind();

                // populate Policy Limit dropdown
                ddPolicyLimit.DataSource = Insurance.GetLimits();
                ddPolicyLimit.DataTextField = "Value";
                ddPolicyLimit.DataValueField = "ID";
                ddPolicyLimit.DataBind();

                //populate insurance company dropdown
                PopulateInsuranceCompanies();

                //populate insurance broker dropdown
                PopulateBrokers();

                int ID;

                // if this form is in edit mode, populate it!
                if (this.Mode == Modes.Edit)
                    if (int.TryParse(Request.QueryString["ID"], out ID)) PopulateForm(ID);
                else
                    ddActive.Value = true; // set this by default for easier entry
            } // is post back
        }

        /// <summary>
        /// Populate the form with the information on the insurance policy
        /// </summary>
        /// <param name="ID">ID of the insurance policy</param>
        protected void PopulateForm(int ID) {
            
            // get the insurance policy based on ID
            InsurancePolicy ins = Insurance.GetPolicy(ID);
            
            // populate all fields
            txtCertReq.Text = ins.CertReqFor;
            ddTenantsLiability.Value = ins.TenantsLegalLiability;
            ddTypeOfPolicy.SelectedValue = ins.TypeOfPolicy.ToString();
            ddPerOccurance.Value = ins.PerOccurance;
            ddProductsCompletedOps.Value = ins.ProductsCompletedOps;
            ddNonOwnedAuto.Value = ins.NonOwnedAuto;
            ddCrossLiability.Value = ins.CrossLiability;
            ddNCasAddIns.Value = ins.NCasAddIns;
            txtPolicyNumber.Text = ins.PolicyNumber;
            ddPolicyLimit.SelectedValue = ins.PolicyLimit.ToString();
            if (ddPolicyLimit.SelectedItem.Text == "Other") txtPolicyLimitOther.Visible = true;
            txtPolicyLimitOther.Text = ins.PolicyLimitOther;
            dddExpiryDate.Date = ins.ExpiryDate;
            ddInsuranceCompanies.SelectedValue = ins.insID.HasValue ? ins.insID.ToString() : String.Empty;
            if (ddInsuranceCompanies.SelectedIndex > 0) lnkEditIns.Visible = true;
            
            txtInsEmail.Text = ins.InsuranceCompany1.Email;
            ddBroker.SelectedValue = ins.BrokerID.HasValue ? ins.BrokerID.ToString() : String.Empty;

            // populate broker dropdown based on broker... 
            if (ddBroker.SelectedIndex > 0)
            {// .. but only if there's a broker selected
                PopulateBrokerEmails((int)ins.BrokerID);
                lnkEditBroker.Visible = true;
            }

            ddBrokerEmail.SelectedValue = ins.BrokerEmailID.HasValue ? ins.BrokerEmailID.ToString() : String.Empty;
            if (ddBrokerEmail.SelectedIndex > 0) lnkEditBrokeEmail.Visible = true;

            ddCertSigned.Value = ins.CertSigned;
            ddActive.Value = ins.Active;

            // display the attached file (if there is one!)
            String filelnk = "~/uploads/" + ID.ToString() + "/attachment.pdf";
            String directory = Server.MapPath("uploads");
            String filepath = directory + "/" + ID.ToString() + "/attachment.pdf";
            if (File.Exists(filepath)) // only show it if there is an attached file.
            {
                lnkFiles.NavigateUrl = filelnk;
                lnkFiles.Text = "View attachment";
            }
        }

        /// <summary>
        /// Populates the Insurance Companies dropdown
        /// </summary>
        private void PopulateInsuranceCompanies()
        {
            ddInsuranceCompanies.Items.Clear();
            ddInsuranceCompanies.DataSource = Insurance.GetInsuranceCompanies();
            ddInsuranceCompanies.DataTextField = "Name";
            ddInsuranceCompanies.DataValueField = "ID";
            ddInsuranceCompanies.Items.Add(new ListItem("--Select--", ""));
            ddInsuranceCompanies.DataBind();
        }

        /// <summary>
        /// Populate Insurance Broker Dropdown
        /// </summary>
        private void PopulateBrokers()
        {
            ddBroker.Items.Clear();
            ddBroker.DataSource = Insurance.GetInsuranceBrokers();
            ddBroker.DataTextField = "Name";
            ddBroker.DataValueField = "ID";
            ddBroker.Items.Add(new ListItem("--Select--", ""));
            ddBroker.DataBind();
        }

        /// <summary>
        /// Populates the Broker Emails dropdown based on the selected broker
        /// </summary>
        /// <param name="BrokerID">The ID of the broker</param>
        private void PopulateBrokerEmails(int BrokerID)
        {
            ddBrokerEmail.Items.Clear();
            var emails = Insurance.GetInsuranceBrokerEmails(BrokerID);
            ddBrokerEmail.DataSource = emails;
            ddBrokerEmail.DataTextField = "Email";
            ddBrokerEmail.DataValueField = "ID";
            if (emails.Count > 0)
                ddBrokerEmail.Items.Add(new ListItem(emails.Count + " email(s) found.", ""));
            else 
                ddBrokerEmail.Items.Add(new ListItem("No emails found.", ""));
            ddBrokerEmail.DataBind();
        }

        

        /// <summary>
        /// Saving a new insurance company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmitNewIns_Click(object sender, EventArgs e)
        {
            if (txtNewInsuranceCompanyName.Text.Length > 0)
            {
                // build and populate the insurance company...
                QCTLinqDataContext db = new QCTLinqDataContext();
                InsuranceCompany ins = new InsuranceCompany
                {
                    Name = txtNewInsuranceCompanyName.Text,
                    Email = txtNewInsComEmail.Text,
                    Active = true
                };
                // save the changes
                db.InsuranceCompanies.InsertOnSubmit(ins);
                db.SubmitChanges();
                // now that the new insurance comapny is in the db, let's re-populate the dropdown...
                PopulateInsuranceCompanies();
                // ... and automatically select it!
                ddInsuranceCompanies.SelectedValue = ins.ID.ToString();
                // let's populate the associated email as well.
                txtInsEmail.Text = ins.Email;
                // let's clear the fields we used to create the new insurance policy
                txtNewInsuranceCompanyName.Text = txtNewInsComEmail.Text = String.Empty;
            }
        }

        /// <summary>
        /// Edit the selected insurance company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditIns_Click(object sender, EventArgs e)
        {
            if (ddInsuranceCompanies.SelectedIndex > 0)
            {
                QCTLinqDataContext db = new QCTLinqDataContext();
                // pull the insurance company based on the selected object
                int ID = int.Parse(ddInsuranceCompanies.SelectedValue);
                InsuranceCompany ins = db.InsuranceCompanies.Where(i => i.ID == ID).Single();
                // update the values
                ins.Name = txtNewInsuranceCompanyName.Text;
                ins.Email = txtNewInsComEmail.Text;
                // save the changes!
                db.SubmitChanges();
                // let's clear and repopulate the dropdown menu
                PopulateInsuranceCompanies();
                // select the appropriate selection
                ddInsuranceCompanies.SelectedValue = ID.ToString();
                // populate the email address and name
                txtInsEmail.Text = ins.Email;
            }
        }

        /// <summary>
        /// Add a new broker to be available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmitNewBroker_Click(object sender, EventArgs e)
        {
            // ensure the user has actually entered something to add
            if (txtNewBroker.Text.Length > 0)
            {
                QCTLinqDataContext db = new QCTLinqDataContext();
                // create and populate the broker object
                InsuranceBroker b = new InsuranceBroker
                {
                    Name = txtNewBroker.Text,
                    Active = true
                };
                // insert...
                db.InsuranceBrokers.InsertOnSubmit(b);
                db.SubmitChanges();
                // repopulate the broker dropdown...
                PopulateBrokers();
                // select the newly entered broker
                ddBroker.SelectedValue = b.ID.ToString();
                // clear the broker email list, as there won't be any email associated with a new broker yet
                ddBrokerEmail.Items.Clear();
                ddBrokerEmail.Items.Add(new ListItem("No email selected", ""));
            }
        }

        protected void btnEditBroker_Click(object sender, EventArgs e)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            int ID = int.Parse(ddBroker.SelectedValue);
            InsuranceBroker b = db.InsuranceBrokers.Single(a => a.ID == ID);
            b.Name = txtNewBroker.Text;
            db.SubmitChanges();
            ddBroker.SelectedItem.Text = b.Name;
        }

        /// <summary>
        /// Add a new email to a selected broker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmitNewBrokerEmail_Click(object sender, EventArgs e)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            int brokerID = int.Parse(ddBroker.SelectedValue);
            InsuranceBrokerEmail email = new InsuranceBrokerEmail
            {
                bID = brokerID ,
                Email = txtNewBrokerEmail.Text,
                Active = true
            };
            db.InsuranceBrokerEmails.InsertOnSubmit(email);
            db.SubmitChanges();
            PopulateBrokerEmails(brokerID);
            ddBrokerEmail.SelectedValue = email.ID.ToString();
        }

        /// <summary>
        /// Saves the changes to a modified broker email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditBrokerEmail_Click(object sender, EventArgs e)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            InsuranceBrokerEmail email = db.InsuranceBrokerEmails.Single(u => u.ID == int.Parse(ddBrokerEmail.SelectedValue));
            email.Email = txtNewBrokerEmail.Text;
            db.SubmitChanges();
            PopulateBrokerEmails(email.bID);
            ddBrokerEmail.SelectedValue = email.ID.ToString();
        }

        /// <summary>
        /// Looks up the email addresses associated with a certain insurance company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddInsuranceCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ensure that an insurace company was chosen
            if (ddInsuranceCompanies.SelectedIndex > 0)
            {
                // look up the insurance company and get the email address
                var ins = Insurance.GetInsuranceCompany(int.Parse(ddInsuranceCompanies.SelectedValue));
                // populate!
                txtInsEmail.Text = ins.Email;
                lnkEditIns.Visible = true;
            }
            else
            {
                lnkEditIns.Visible = false;
                txtInsEmail.Text = String.Empty;
            }
        }


        /// <summary>
        /// Look up the associated email addresses of a broker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddBroker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddBroker.SelectedIndex > 0)
            {
                int bID = int.Parse(ddBroker.SelectedValue);
                ddBrokerEmail.Items.Clear();
                var emails = Classes.Insurance.GetInsuranceBrokerEmails(bID);
                ddBrokerEmail.DataSource = emails;
                ddBrokerEmail.DataTextField = "Email";
                ddBrokerEmail.DataValueField = "ID";
                ddBrokerEmail.Items.Add(new ListItem(emails.Count + " email(s) found", ""));
                ddBrokerEmail.DataBind();
                lnkEditBroker.Visible = true;
            }
            else
            {
                ddBrokerEmail.SelectedIndex = 0;
                lnkEditBroker.Visible = false;
            }
            lnkEditBrokeEmail.Visible = false;
        }

        protected void ddBrokerEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddBrokerEmail.SelectedIndex > 0)
            {
                lnkEditBrokeEmail.Visible = true;
            }
            else
            {
                lnkEditBrokeEmail.Visible = false;
            }
        }
    }
}