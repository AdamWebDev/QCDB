using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Qualified_Contractor_Tracking.Classes;
using Telerik.Web.UI;
using System.IO;

namespace Qualified_Contractor_Tracking
{
    public partial class AddInsurancePolicy1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int ID, cID;

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

                if (int.TryParse(Request.QueryString["ID"], out ID) && int.TryParse(Request.QueryString["cID"],out cID)) 
                {
                    String mode = Request.QueryString["mode"];
                    if (mode.Equals("edit"))
                        Functions.SecurePage(); // only allow certain people to edit

                    Contractor c = Classes.Contractors.GetContractor(cID);
                    
                    if (mode.Equals("edit") || mode.Equals("read"))
                    {
                        // populate all fields
                        ltSubTitle.Text = "Edit policy of: " + c.Company;
                        btnDelete.Visible = true;
                        Insurance ins = Classes.Insurance.GetPolicy(ID);
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
                        txtInsEmail.Text = ins.InsuranceCompany1.Email;
                        ddBroker.SelectedValue = ins.BrokerID.HasValue ? ins.BrokerID.ToString() : String.Empty;
                        ddBrokerEmail.SelectedValue = ins.BrokerEmailID.HasValue ? ins.BrokerEmailID.ToString() : String.Empty;
                        ddCertSigned.Value = ins.CertSigned;
                        ddActive.Value = ins.Active;
                        
                        // build the paths for the file and the link to it.
                        String filelnk = "uploads/" + ID.ToString() + "/attachment.pdf";
                        String directory = Server.MapPath("uploads");
                        String filepath = directory + "/" + ID.ToString() + "/attachment.pdf";
                        if (File.Exists(filepath)) // only show it if there is an attached file.
                        {
                            lnkFiles.NavigateUrl = filelnk;
                            lnkFiles.Text = "View attachment";
                        }
                    }
                    if (mode.Equals("read")) // if we're only reading the info, disable all of the controls.
                    {
                        Functions.DisableControls(Page);
                        uploadCert.Enabled = btnSubmit.Visible = btnDelete.Visible = btnCancel.Visible = false;
                        ltSubTitle.Text = "View Insurance Policy";
                    }
                    else if (mode.Equals("delete")) // if we're deleting the insurance policy, hide everything and just show the confirmation.
                    {
                        ltSubTitle.Text = "Delete policy of " + c.Company;
                        pnDelete.Visible = true;
                        pnDetails.Visible = false;
                        btnCancel.Visible = false;
                        btnDelete.Visible = false;
                        phFiles.Visible = false;
                        uploadCert.Visible = false;
                        btnSubmit.Visible = false;
                    }
                    else if (mode.Equals("add"))
                    {
                        ltSubTitle.Text = "Add policy to: " + c.Company;
                    }
                    
                    btnDelete.NavURL = "~/InsurancePolicy.aspx?ID=" + ID.ToString() + "&cID=" + cID.ToString() + "&mode=delete";
                    btnCancel.NavURL = "~/EditContractor.aspx?ID=" + cID.ToString() + "#insurance";
                }
                else if(int.TryParse(Request.QueryString["cID"],out cID)) {
                    btnCancel.NavURL = "~/EditContractor.aspx?ID=" + cID.ToString() + "#insurance";
                }
            }
        }

        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            int cID = int.Parse(Request.QueryString["cID"]);
            int ID = 0;
            String mode = Request.QueryString["mode"];
            Insurance ins = new Insurance();
            if (mode.Equals("edit")) // existing policy - load it up!
            {
                ID = int.Parse(Request.QueryString["ID"]);
                ins = db.Insurances.Single(i => i.ID == ID);
            }
            else // new insurance policy - add the contractor ID
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
            
            ins.CertSigned = ddCertSigned.Value;
            ins.Active = ddActive.Value;
            if (!mode.Equals("edit")) // if existing, 
                db.Insurances.InsertOnSubmit(ins);

            db.SubmitChanges();

            if (!mode.Equals("edit"))
                ID = Convert.ToInt32(ins.ID);
            
            if (uploadCert.UploadedFiles.Count > 0)
            {
                String directory = Server.MapPath("uploads");
                directory = directory + "/" + ID;
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                foreach (UploadedFile file in uploadCert.UploadedFiles)
                {
                    file.SaveAs(directory+"/attachment"+file.GetExtension(),true);
                    String filelnk = "uploads/" + ID + "/attachment.pdf";
                    lnkFiles.NavigateUrl = filelnk;
                    lnkFiles.Text = "View attachment";
                }
            }

            notIns.Message = "Insurance Policy has been saved!";
            notIns.Type = "success";
            notIns.Visible = true;
            Functions.ScrollToTop(Page);
        }

        protected void lnkConfirmDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            QCTLinqDataContext db = new QCTLinqDataContext();
            Insurance ins = db.Insurances.Single(i => i.ID == ID);
            db.Insurances.DeleteOnSubmit(ins);
            db.SubmitChanges();
            notIns.Message = "Insurance Policy has been deleted!";
            notIns.Type = "success";
            notIns.Visible = true;
            lnkConfirmDelete.Visible = false;
            lnkCancelDelete.Visible = false;
            btnCancel.Visible = true;
            pnDelete.Visible = false;
        }

        protected void lnkCancelDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsurancePolicy.aspx?ID=" + Request.QueryString["ID"] + "&cID=" + Request.QueryString["cID"] + "&mode=edit");
        }

        protected void btnSubmitNewIns_Click(object sender, EventArgs e)
        {
            if (txtNewInsuranceCompanyName.Text.Length > 0)
            {
                QCTLinqDataContext db = new QCTLinqDataContext();
                InsuranceCompany ins = new InsuranceCompany
                {
                    Name = txtNewInsuranceCompanyName.Text,
                    Email = txtNewInsComEmail.Text,
                    Active = true
                };
                db.InsuranceCompanies.InsertOnSubmit(ins);
                db.SubmitChanges();
                ddInsuranceCompanies.DataSource = Classes.Insurance.GetInsuranceCompanies();
                ddInsuranceCompanies.DataTextField = "Name";
                ddInsuranceCompanies.DataValueField = "ID";
                ddInsuranceCompanies.DataBind();
                ddInsuranceCompanies.SelectedValue = ins.ID.ToString();
                txtInsEmail.Text = ins.Email;
                txtNewInsuranceCompanyName.Text = txtNewInsComEmail.Text = String.Empty;
            }
        }

        protected void btnEditIns_Click(object sender, EventArgs e)
        {
            if (ddInsuranceCompanies.SelectedIndex > 0)
            {
                QCTLinqDataContext db = new QCTLinqDataContext();
                int ID = int.Parse(ddInsuranceCompanies.SelectedValue);
                InsuranceCompany ins = db.InsuranceCompanies.Where(i => i.ID == ID).Single();
                ins.Name = txtNewInsuranceCompanyName.Text;
                ins.Email = txtNewInsComEmail.Text;
                db.SubmitChanges();
                ddInsuranceCompanies.Items.Clear();
                ddInsuranceCompanies.Items.Add(new ListItem("--Select--", ""));
                ddInsuranceCompanies.DataSource = Classes.Insurance.GetInsuranceCompanies();
                ddInsuranceCompanies.DataTextField = "Name";
                ddInsuranceCompanies.DataValueField = "ID";
                ddInsuranceCompanies.DataBind();
                ddInsuranceCompanies.SelectedValue = ID.ToString();
                txtInsEmail.Text = hdnInsEmail.Value = ins.Email;
                hdnInsName.Value = ins.Name;
            }
        }

        protected void ddInsuranceCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddInsuranceCompanies.SelectedIndex > 0)
            {
                var ins = Classes.Insurance.GetInsuranceCompany(int.Parse(ddInsuranceCompanies.SelectedValue));
                txtInsEmail.Text = hdnInsEmail.Value = ins.Email;
                hdnInsName.Value = ins.Name;
                lnkEditIns.Visible = true;
            }
            else
            {
                hdnInsEmail.Value = hdnInsName.Value = string.Empty;
                lnkEditIns.Visible = false;
            }
        }

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
                ddBrokerEmail.Items.Add(new ListItem( emails.Count + " email(s) found", ""));
                ddBrokerEmail.DataBind();
            }
            else
            {
                ddBrokerEmail.SelectedIndex = 0;
            }
        }

        

        

        
    }
}