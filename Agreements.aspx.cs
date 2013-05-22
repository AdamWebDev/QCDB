using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Qualified_Contractor_Tracking.Classes;

namespace Qualified_Contractor_Tracking
{
    public partial class Agreements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulatePage();
            }
        }

        protected void ddTypeOfAgreement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddTypeOfAgreement.SelectedItem.Text.Equals("Contract"))
            {
                phContract.Visible = true;
                phCRC.Visible = false;
                txtCRCFiledWith.Text = String.Empty;
                ddDivision.Clear();
            }
            else if (ddTypeOfAgreement.SelectedItem.Text.Equals("Agreement"))
            {
                phContract.Visible = false;
                phCRC.Visible = true;
                Functions.ClearControls(phContract);
                
            }
            else {
                phCRC.Visible = false;
                phContract.Visible = false;
                txtCRCFiledWith.Text = String.Empty;
                ddDivision.Clear();
                Functions.ClearControls(phContract);
            }
        }


        protected void chkTypeSecurity_OnSelectedIndexChanged(object sender, EventArgs e) 
        {
            foreach (ListItem li in chkTypeSecurity.Items)
            {
                if (li.Selected)
                {
                    if (li.Value.Equals("1"))
                        phBidDeposit.Visible = true;
                    else if (li.Value.Equals("2"))
                        phPerfBond.Visible = true;
                    else if (li.Value.Equals("3"))
                        phLabourBond.Visible = true;
                }
                else
                {
                    if (li.Value.Equals("1"))
                    {
                        phBidDeposit.Visible = false;
                        Functions.ClearControls(phBidDeposit);
                    }
                    else if (li.Value.Equals("2"))
                    {
                        phPerfBond.Visible = false;
                        Functions.ClearControls(phPerfBond);
                    }
                    else if (li.Value.Equals("3"))
                    {
                        phLabourBond.Visible = false;
                        Functions.ClearControls(phLabourBond);
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            int ID = Int32.Parse(Request.QueryString["ID"]);
            int cID = Int32.Parse(Request.QueryString["cID"]);
            String mode = Request.QueryString["mode"];

            using (QCTLinqDataContext db = new QCTLinqDataContext())
            {
                Agreement ag = new Agreement();

                if (mode.Equals("edit"))
                    ag = db.Agreements.Single(u => u.ID == ID);
                else
                    ag.cID = cID;

                ag.TypeOfAgreement = ddTypeOfAgreement.SelectedIndex > 0 ? int.Parse(ddTypeOfAgreement.SelectedValue) : (int?)null;
                ag.Description = txtDescription.Text;
                ag.TermEffectiveDate = dddTermEffectiveDate.Date;
                ag.TermExpiryDate = dddTermExpiryDate.Date;
                ag.ExtensionExpiryDate = dddExtensionExpiryDate.Date;
                ag.AmountBeforeTax = txtAmtBeforeTax.Text;
                ag.AgreementSigned = ddAgreementSigned.SelectedIndex > 0 ? int.Parse(ddAgreementSigned.SelectedValue) : (int?)null;
                ag.PONumber = txtPONumber.Text;
                ag.DivisionIssued = ddDivisionIssued.DivisionID;
                ag.SecuritiesRequired = Functions.MergeValues(chkTypeSecurity);
                ag.BidDepositRecd = ddBidDepositRecd.Value;
                ag.BidDepositAmt = txtBidDepositAmnt.Text;
                ag.PerfBondReceived = ddPerfBondRecd.Value;
                ag.PerfBondAmt = txtPerfBondAmt.Text;
                ag.LabourBondRecd = ddLabourBondRecd.Value;
                ag.LabourBondAmt = txtLabourBondAmt.Text;
                ag.TestingReqd = ddTestingRequired.Value;
                ag.TestingRecd = ddTestingReceived.Value;
                ag.MOLReqd = ddMOLReqd.Value;
                ag.MOLRecd = ddMOLRecd.Value;
                ag.MTOCertRecd = ddMTOCertRecd.Value;
                ag.TrucksCal = dddTrucksCalibrated.Date;
                ag.Form1000Req = ddForm1000Req.Value;
                ag.Form1000Recd = ddForm1000Rec.Value;
                ag.OtherReq = txtOtherReq.Text;
                ag.TenPerHoldback = ddTenPerHoldback.Value;
                ag.CRCFiledWith = txtCRCFiledWith.Text;
                ag.CRCDept = ddDivision.DivisionID;

                if (!mode.Equals("edit"))
                    db.Agreements.InsertOnSubmit(ag);

                db.SubmitChanges();
            }
            
            notAgreement.Message = "Agreement saved!";
            notAgreement.Type = "success";
            notAgreement.Visible = true;
            Functions.ScrollToTop(Page);
        }

        protected void lnkCancelDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Agreements.aspx?ID=" + Request.QueryString["ID"] + "&cID=" + Request.QueryString["cID"] + "&mode=edit");
        }

        protected void lnkConfirmDelete_Click(object sender, EventArgs e)
        {
            using (QCTLinqDataContext db = new QCTLinqDataContext())
            {
                int ID = int.Parse(Request.QueryString["ID"]);
                Agreement ag = Classes.Agreements.GetAgreement(ID);
                db.Agreements.DeleteOnSubmit(ag);
                db.SubmitChanges();
            }
            notAgreement.Message = "Insurance Policy has been deleted!";
            notAgreement.Type = "success";
            notAgreement.Visible = true;
            lnkConfirmDelete.Visible = false;
            lnkCancelDelete.Visible = false;
            btnCancel.Visible = true;
            pnDelete.Visible = false; 
        }

        protected void PopulatePage()
        {
            // populate dropdowns // 
            ddTypeOfAgreement.DataSource = Classes.Agreements.GetAgreementTypes();
            ddTypeOfAgreement.DataValueField = "ID";
            ddTypeOfAgreement.DataTextField = "Value";
            ddTypeOfAgreement.DataBind();

            ddTypeOfAgreement.DataSource = Classes.Agreements.GetAgreementsSigned();
            ddAgreementSigned.DataValueField = "ID";
            ddAgreementSigned.DataTextField = "Value";
            ddAgreementSigned.DataBind();


            chkTypeSecurity.DataSource = Classes.Agreements.GetSecurityTypes();
            chkTypeSecurity.DataValueField = "ID";
            chkTypeSecurity.DataTextField = "Value";
            chkTypeSecurity.DataBind();

            String mode = Request.QueryString["mode"];

            if (mode.Equals("edit"))
                Functions.SecurePage();

            Contractor ct = Classes.Contractors.GetContractor(int.Parse(Request.QueryString["cID"]));

            btnCancel.NavURL = "~/EditContractor.aspx?ID=" + Request.QueryString["cID"] + "#agreements";
            btnDelete.NavURL = "~/Agreements.aspx?ID=" + Request.QueryString["ID"] + "&cID=" + Request.QueryString["cID"] + "&mode=delete";

            if (mode.Equals("edit") || mode.Equals("read"))
            {
                Agreement ag = Classes.Agreements.GetAgreement(int.Parse(Request.QueryString["ID"]));

                ltSubTitle.Text = "Edit policy of: " + ct.Company;
                ddTypeOfAgreement.SelectedValue = ag.TypeOfAgreement.ToString();
                switch (ddTypeOfAgreement.SelectedItem.Text)
                {
                    case "Contract":
                        phContract.Visible = true;
                        break;
                    case "Agreement":
                        phLabourBond.Visible = true;
                        phCRC.Visible = true;
                        break;
                }
                txtDescription.Text = ag.Description;
                dddTermEffectiveDate.Date = ag.TermEffectiveDate;
                dddTermExpiryDate.Date = ag.TermExpiryDate;
                dddExtensionExpiryDate.Date = ag.ExtensionExpiryDate;
                txtAmtBeforeTax.Text = ag.AmountBeforeTax;
                ddAgreementSigned.SelectedValue = ag.AgreementSigned.ToString();
                txtPONumber.Text = ag.PONumber;
                ddDivisionIssued.DivisionID = ag.DivisionIssued;
                Functions.PopulateCheckBoxes(chkTypeSecurity, ag.SecuritiesRequired);
                foreach (ListItem li in chkTypeSecurity.Items)
                {
                    if (li.Selected)
                    {
                        if (li.Value.Equals("1"))
                            phBidDeposit.Visible = true;
                        else if (li.Value.Equals("2"))
                            phPerfBond.Visible = true;
                        else if (li.Value.Equals("3"))
                            phLabourBond.Visible = true;
                    }
                }
                ddBidDepositRecd.Value = ag.BidDepositRecd;
                txtBidDepositAmnt.Text = ag.BidDepositAmt;
                ddPerfBondRecd.Value = ag.PerfBondReceived;
                txtPerfBondAmt.Text = ag.PerfBondAmt;
                ddLabourBondRecd.Value = ag.LabourBondRecd;
                txtLabourBondAmt.Text = ag.LabourBondAmt;
                ddTestingRequired.Value = ag.TestingReqd;
                ddTestingReceived.Value = ag.TestingRecd;
                ddMOLReqd.Value = ag.MOLReqd;
                ddMOLRecd.Value = ag.MOLRecd;
                ddMTOCertRecd.Value = ag.MTOCertRecd;
                dddTrucksCalibrated.Date = ag.TrucksCal;
                ddForm1000Req.Value = ag.Form1000Req;
                ddForm1000Rec.Value = ag.Form1000Recd;
                txtOtherReq.Text = ag.OtherReq;
                ddTenPerHoldback.Value = ag.TenPerHoldback;
                txtCRCFiledWith.Text = ag.CRCFiledWith;
                ddDivision.DivisionID = ag.CRCDept;
            }
            if (mode.Equals("edit"))
            {
                btnDelete.Visible = true;
            }
            if (mode.Equals("delete"))
            {
                ltSubTitle.Text = "Delete Agreement of " + ct.Company;
                pnDelete.Visible = true;
                pnDetails.Visible = false;
                btnCancel.Visible = false;
                btnDelete.Visible = false;
                btnSubmit.Visible = false;
            }
            if (mode.Equals("read"))
            {
                Functions.DisableControls(Page);
                btnSubmit.Visible = false;
                ltSubTitle.Text = "View Agreement";
                btnCancel.Visible = false;
            }
            else
            {
                ltSubTitle.Text = "Add Agreement to: " + ct.Company;
            }
        }
    }
}