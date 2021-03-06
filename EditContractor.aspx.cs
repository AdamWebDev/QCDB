﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Qualified_Contractor_Tracking.Classes;
using System.Text;

namespace Qualified_Contractor_Tracking
{
    public partial class EditContractor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Functions.SecurePage();
                int cID;
                if ( !String.IsNullOrEmpty(Request.QueryString["ID"]) && int.TryParse(Request.QueryString["ID"].ToString(), out cID) )
                {
                    // populate links in various tabs
                    lnkNewInsurance.NavigateUrl = "~/InsurancePolicies/New.aspx?cID=" + cID;
                    lnkNewAgreemnt.NavigateUrl = "~/Agreements.aspx?cID=" + cID + "&mode=add";
                    lnkNewPermit.NavigateUrl = "~/Permits.aspx?cID=" + cID + "&mode=add";
                    lnkNewLicence.NavigateUrl = "~/Licences.aspx?cID=" + cID + "&mode=add";
                    btnCancel.NavURL = "~/ViewContractor.aspx?ID=" + cID;

                    ddPhoneType.DataSource = Contractors.GetPhoneTypes();
                    ddPhoneType.DataTextField = "Value";
                    ddPhoneType.DataValueField = "ID";
                    ddPhoneType.DataBind();

                    rptInsurance.DataSource = Contractors.GetInsurance(cID);
                    rptInsurance.DataBind();

                    rptAgreements.DataSource = Contractors.GetAgreements(cID);
                    rptAgreements.DataBind();

                    rptPermits.DataSource = Contractors.GetPermits(cID);
                    rptPermits.DataBind();

                    rptLicenses.DataSource = Contractors.GetLicenses(cID);
                    rptLicenses.DataBind();

                    ddWSIBCoverage.DataSource = Contractors.GetWSIBTypes();
                    ddWSIBCoverage.DataTextField = "Value";
                    ddWSIBCoverage.DataValueField = "ID";
                    ddWSIBCoverage.DataBind();

                    rptJobs.DataSource = Contractors.GetJobs(cID);
                    rptJobs.DataBind();

                    WSIB w = Contractors.GetWSIB(cID);

                    if (w != null)
                    {
                        ddWSIBCoverage.SelectedValue = w.WSIBCoverage.HasValue ? w.WSIBCoverage.ToString() : String.Empty;
                        if (ddWSIBCoverage.SelectedValue.Equals("1"))
                            phClearance.Visible = true;
                        else if (ddWSIBCoverage.SelectedValue.Equals("2"))
                            phIndOp.Visible = true;
                        else if (ddWSIBCoverage.SelectedValue.Equals("3"))
                            phWSIBExempt.Visible = true;
                        ddCertRecd.Value = w.WSIBCertRecd;
                        ddIndOpLetter.Value = w.IndOpLetterRecd;
                        txtIDNum.Text = w.IndOpIDNum;
                        ddWSIBExempt.Value = w.WSIBExemptFormRecd;
                        ddAODASubmitted.Value = w.AODAFormSubmit;
                        ddAODAStandardsCompliance.Value = w.AODAStandardsCompliance;
                        ddNCHSReqd.Value = w.NCHSPolicyReqd;
                        phNCHSPolicyRecd.Visible = ddNCHSReqd.Value == null ? false : (bool)ddNCHSReqd.Value;
                        ddNCHSReceived.Value = w.NCHSPolicyRecd;
                        ddMoL100.SelectedValue = w.MoL100Recd;
                        ddContHS.SelectedValue = w.HSPolicy;
                    }
                    
                    Contractor c = Contractors.GetContractor(cID);
                    CompanyTextBox.Text = c.Company;
                    ltSubTitle.Text = "Editing " + c.Company;
                    VendorNumberTextBox.Text = c.VendorNumber;
                    ContactNameTextBox.Text = c.ContactName;
                    MailingAddressTextBox.Text = c.MailingAddress;
                    TownTextBox.Text = c.Town;
                    PostalCodeTextBox.Text = c.PostalCode;
                    EmailTextBox.Text = c.Email;
                    txtNCContact.Text = c.NCContact;
                    ddExemptFromAuto.Value = c.ExemptFromAuto;
                    phExemptFromAutoComments.Visible = c.ExemptFromAuto == true;
                    txtExemptFromAutoComments.Text = c.ExemptFromAutoComments;
                    txtContratorNotes.Text = c.Notes;

                    rptPhones.DataSource = Contractors.GetPhoneNumbers(cID);
                    rptPhones.DataBind();

                    // if there are any status messages to display... display them!
                    if (Request.QueryString["msg"] != null)
                    {
                        switch (Request.QueryString["msg"])
                        {
                            case "insadded":
                                notInsurance.Type = "success";
                                notInsurance.Message = "Insurance Policy added!";
                                notInsurance.Visible = true;
                                break;
                            case "insedited":
                                notInsurance.Type = "success";
                                notInsurance.Message = "Insurance Policy updated!";
                                notInsurance.Visible = true;
                                break;
                        }
                    }
                }
            }
        }

        protected void imgDelete_Click(object sender, EventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            int ID = Convert.ToInt32(btn.Attributes["PhoneID"]);
            QCTLinqDataContext db = new QCTLinqDataContext();
            ContractorsPhone p = (from c in db.ContractorsPhones
                                 where c.ID == ID
                                 select c).SingleOrDefault();
            if (p != null)
            {
                db.ContractorsPhones.DeleteOnSubmit(p);
                db.SubmitChanges();
                rptPhones.DataSource = Contractors.GetPhoneNumbers(int.Parse(Request.QueryString["ID"]));
                rptPhones.DataBind();
            }
        }

        protected void ddAODASubmitted_SelectedIndexChanged(object sender, EventArgs e)
        {
            notAODA.Visible = ddAODASubmitted.Value == false;
        }

        protected void ddNCHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddNCHSReqd.Value == true)
                phNCHSPolicyRecd.Visible = true;
            else
            {
                phNCHSPolicyRecd.Visible = false;
                Functions.ClearControls(phNCHSPolicyRecd);
            }
        }

        protected void ddWSIBCoverage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddWSIBCoverage.SelectedValue.Equals("1"))
            {
                phClearance.Visible = true;
                phIndOp.Visible = false;
                Functions.ClearControls(phIndOp);
                phWSIBExempt.Visible = false;
                Functions.ClearControls(phWSIBExempt);
            }
            else if (ddWSIBCoverage.SelectedValue.Equals("2"))
            {
                phIndOp.Visible = true;
                phClearance.Visible = false;
                Functions.ClearControls(phClearance);
                phWSIBExempt.Visible = false;
                Functions.ClearControls(phWSIBExempt);
            }
            else if (ddWSIBCoverage.SelectedValue.Equals("3"))
            {
                phWSIBExempt.Visible = true;
                phIndOp.Visible = false;
                phClearance.Visible = false;
                Functions.ClearControls(phClearance);
                Functions.ClearControls(phIndOp);
            }
            else
            {
                phWSIBExempt.Visible = false;
                phIndOp.Visible = false;
                phClearance.Visible = false;
                Functions.ClearControls(phWSIBExempt);
                Functions.ClearControls(phClearance);
                Functions.ClearControls(phIndOp);
            }
        }

        protected void btnSaveWSIB_Click(object sender, EventArgs e)
        {
            int cID = Int32.Parse(Request.QueryString["ID"]);
            bool newWSIB = false;
            QCTLinqDataContext db = new QCTLinqDataContext();
            WSIB w = (from a in db.WSIBs
                            where a.cID == cID
                            select a).SingleOrDefault();

            if (w == null)  { 
                w = new WSIB();
                w.cID = cID;
                newWSIB = true;
            }

                w.WSIBCoverage = ddWSIBCoverage.SelectedIndex > 0 ? int.Parse(ddWSIBCoverage.SelectedValue) : (int?)null;
                w.WSIBCertRecd = ddCertRecd.Value;
                w.IndOpLetterRecd = ddIndOpLetter.Value;
                w.IndOpIDNum = txtIDNum.Text;
                w.WSIBExemptFormRecd = ddWSIBExempt.Value;
                w.AODAFormSubmit = ddAODASubmitted.Value;
                w.AODAStandardsCompliance = ddAODAStandardsCompliance.Value;
                w.NCHSPolicyReqd = ddNCHSReqd.Value;
                w.NCHSPolicyRecd = ddNCHSReceived.Value;
                w.MoL100Recd = ddMoL100.SelectedValue;
                w.HSPolicy = ddContHS.SelectedValue;

                if (newWSIB) db.WSIBs.InsertOnSubmit(w);

                db.SubmitChanges();
                
                notWSIB.Type = "success";
                notWSIB.Message = "Changes have been saved!";
                notWSIB.Visible = true;
                
            
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            int ID = Int32.Parse(Request.QueryString["ID"]);
            QCTLinqDataContext db = new QCTLinqDataContext();
            Contractor c = (from a in db.Contractors
                            where a.ID == ID
                            select a).SingleOrDefault();
            if (c != null) {
                c.Company = CompanyTextBox.Text;
                c.VendorNumber = VendorNumberTextBox.Text;
                c.ContactName = ContactNameTextBox.Text;
                c.MailingAddress = MailingAddressTextBox.Text;
                c.Town = TownTextBox.Text;
                c.PostalCode = PostalCodeTextBox.Text;
                c.Email = EmailTextBox.Text;
                c.NCContact = txtNCContact.Text;
                db.SubmitChanges();
                notContract.Type = "success";
                notContract.Message = "Changes have been saved!";
                notContract.Visible = true;
            }
        }

        public static Control GetPostBackControl(Page thePage)
        {
            Control myControl = null;
            string ctrlName = thePage.Request.Params.Get("__EVENTTARGET");
            if (((ctrlName != null) & (ctrlName != string.Empty)))
            {
                myControl = thePage.FindControl(ctrlName);
            }
            else
            {
                foreach (string Item in thePage.Request.Form)
                {
                    Control c = thePage.FindControl(Item);
                    if (((c) is System.Web.UI.WebControls.Button))
                    {
                        myControl = c;
                    }
                }
            }
            return myControl;
        }

        protected void btnAddPhone_Click(object sender, EventArgs e)
        {
            ddPhoneType.Visible = true;
            txtPhoneNumber.Visible = true;
            btnSavePhone.Visible = true;
            btnAddPhone.Visible = false;
        }


        protected void btnSavePhone_Click(object sender, EventArgs e)
        {
            int cID = Int32.Parse(Request.QueryString["ID"]);
            QCTLinqDataContext db = new QCTLinqDataContext();
            ContractorsPhone phone = new ContractorsPhone { 
                cID = cID,
                PhoneType = int.Parse(ddPhoneType.SelectedValue),
                PhoneNumber = txtPhoneNumber.Text
            };
            db.ContractorsPhones.InsertOnSubmit(phone);
            db.SubmitChanges();

            rptPhones.DataSource = Contractors.GetPhoneNumbers(cID);
            rptPhones.DataBind();
            ddPhoneType.SelectedIndex = 0;
            ddPhoneType.Visible = false;
            txtPhoneNumber.Text = String.Empty;
            txtPhoneNumber.Visible = false;
            btnSavePhone.Visible = false;
            btnAddPhone.Visible = true;
            
        }

        protected void btnSaveNotes_Click(object sender, EventArgs e)
        {
            lblNotesSaved.Visible = false;
            int cID = Int32.Parse(Request.QueryString["ID"]);
            QCTLinqDataContext db = new QCTLinqDataContext();
            Contractor c = db.Contractors.Single(u => u.ID == cID);
            c.Notes = txtContratorNotes.Text;
            db.SubmitChanges();
            lblNotesSaved.Visible = true;
        }

        protected void btnSaveJobs_Click(object sender, EventArgs e)
        {
            int cID = Int32.Parse(Request.QueryString["ID"]);
            QCTLinqDataContext db = new QCTLinqDataContext();
            lookupTag job = (from j in db.lookupTags
                             where j.Job == txtJobs.Text
                             select j).SingleOrDefault();
            int jID;

            if (job == null)
            {
                lookupTag newJob = new lookupTag
                {
                    Job = txtJobs.Text
                };
                db.lookupTags.InsertOnSubmit(newJob);
                db.SubmitChanges();
                jID = newJob.ID;
            }
            else
            {
                jID = job.ID;
            }

            Tag tag = new Tag
            {
                cID = cID,
                tID = jID
            };
            db.Tags.InsertOnSubmit(tag);
            db.SubmitChanges();

            rptJobs.DataSource = Contractors.GetJobs(cID);
            rptJobs.DataBind();
            txtJobs.Text = String.Empty;
        }

        protected void lnkRemoveJob_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            int ID = Convert.ToInt32(btn.Attributes["ItemID"]);
            QCTLinqDataContext db = new QCTLinqDataContext();
            Tag tag = (from t in db.Tags
                       where t.ID == ID
                       select t).Single();
            db.Tags.DeleteOnSubmit(tag);
            db.SubmitChanges();

            int cID = Int32.Parse(Request.QueryString["ID"]);
            rptJobs.DataSource = Contractors.GetJobs(cID);
            rptJobs.DataBind();
        }

        protected void lnkConfirmDelete_Click(object sender, EventArgs e)
        {
            int cID = Int32.Parse(Request.QueryString["ID"]);
            QCTLinqDataContext db = new QCTLinqDataContext();
            
            var agreements = db.Agreements.Where(a => a.cID == cID);
            int agCount = agreements.Count();
            db.Agreements.DeleteAllOnSubmit(agreements);

            var phones = db.ContractorsPhones.Where(p => p.cID == cID);
            int phoneCount = phones.Count();
            db.ContractorsPhones.DeleteAllOnSubmit(phones);

            var insurance = db.InsurancePolicies.Where(i => i.cID == cID);
            int insCount = insurance.Count();
            db.InsurancePolicies.DeleteAllOnSubmit(insurance);

            var licenses = db.Licences.Where(l => l.cID == cID);
            int licCount = licenses.Count();
            db.Licences.DeleteAllOnSubmit(licenses);

            var permits = db.Permits.Where(p => p.cID == cID);
            int perCount = permits.Count();
            db.Permits.DeleteAllOnSubmit(permits);

            var wsib = db.WSIBs.Where(w => w.cID == cID);
            int wsibCount = wsib.Count();
            db.WSIBs.DeleteAllOnSubmit(wsib);
            
            var tags = db.Tags.Where(t => t.cID == cID);
            int tagCount = tags.Count();
            db.Tags.DeleteAllOnSubmit(tags);

            var contractor = db.Contractors.Where(c => c.ID == cID).Single();
            db.Contractors.DeleteOnSubmit(contractor);
            db.SubmitChanges();

            StringBuilder sb = new StringBuilder();

            sb.Append( agCount.ToString() + " agreement(s) deleted.<br />");
            sb.Append( phoneCount.ToString() + "Phone number(s) deleted.<br />");
            sb.Append( insCount.ToString() + " insurance policies deleted.<br />");
            sb.Append( licCount.ToString() + " licences deleted.<br />");
            sb.Append( perCount.ToString() + " permits deleted.<br />");
            if (wsibCount > 0)
                sb.Append("WSIB Information deleted.<br />");
            sb.Append("Contractor deleted.");
            lnkConfirmDelete.Visible = false;

            phMainContent.Visible = false;
            Literal summary = new Literal();
            summary.Text = sb.ToString();
            phDeleteSummary.Controls.Add(summary);
            btnCancel.Text = "Back to Contractors";
            btnCancel.NavURL = "~/Default.aspx";
        }

        protected void ddExemptFromAuto_SelectedIndexChanged(object sender, EventArgs e)
        {
            notSaveExemption.Visible = false;
            if (ddExemptFromAuto.Value == true) phExemptFromAutoComments.Visible = true;
            else
            {
                phExemptFromAutoComments.Visible = false;
                txtExemptFromAutoComments.Text = String.Empty;
            }
        }

        protected void btnSaveAutoExemption_Click(object sender, EventArgs e)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            int cID = int.Parse(Request.QueryString["ID"]);
            Contractor c = db.Contractors.Single(u => u.ID == cID);
            c.ExemptFromAuto = ddExemptFromAuto.Value;
            c.ExemptFromAutoComments = txtExemptFromAutoComments.Text;
            db.SubmitChanges();
            notSaveExemption.Visible = true;
        }
    }
}