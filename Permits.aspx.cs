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
    public partial class Permits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            String mode = Request.QueryString["mode"];
            int ID, cID;
            if (int.TryParse(Request.QueryString["cID"], out cID) && int.TryParse(Request.QueryString["ID"], out ID))
            {
                if (!Page.IsPostBack)
                {
                    if (mode.Equals("edit"))
                    {
                        Functions.SecurePage();
                        btnDelete.Visible = true;
                    }

                    ddTypeOfPermit.DataSource = Classes.Permits.GetTypes();
                    ddTypeOfPermit.DataTextField = "Type";
                    ddTypeOfPermit.DataValueField = "ID";
                    ddTypeOfPermit.DataBind();

                    ddTypeOfSecurity.DataSource = Classes.Permits.GetSecurityTypes();
                    ddTypeOfSecurity.DataTextField = "Value";
                    ddTypeOfSecurity.DataValueField = "ID";
                    ddTypeOfSecurity.DataBind();

                    btnCancel.NavURL = "~/EditContractor.aspx?ID=" + cID.ToString() + "#permits";
                    btnDelete.NavURL = "~/Permits.aspx?ID=" + ID.ToString() + "&cID=" + cID.ToString() + "&mode=delete";

                    QCTLinqDataContext db = new QCTLinqDataContext();
                    Contractor c = db.Contractors.Single(con => con.ID == cID);
                    
                    if (mode.Equals("edit") || mode.Equals("read"))
                    {

                        ltSubTitle.Text = "Edit permit of: " + c.Company;
                        Permit permit = db.Permits.Single(p => p.ID == ID);
                        ddTypeOfPermit.SelectedValue = permit.TypeOfPermit.HasValue ? permit.TypeOfPermit.ToString() : String.Empty;
                        if (ddTypeOfPermit.SelectedValue.Equals("6") || ddTypeOfPermit.SelectedValue.Equals("7"))
                        {
                            phAutoInsurance.Visible = true;
                            phWaterSewer.Visible = false;
                        }
                        else if (ddTypeOfPermit.SelectedValue.Equals("2") || ddTypeOfPermit.SelectedValue.Equals("3"))
                        {
                            phWaterSewer.Visible = true;
                            phAutoInsurance.Visible = false;
                        }

                        ddCGL.Value = permit.CGLIns;
                        ddAutoInsurance.Value = permit.AutoIns;
                        ddTypeOfSecurity.SelectedValue = permit.TypeOfSecurity.HasValue ? permit.TypeOfSecurity.ToString() : String.Empty;
                        dddExpiryDate.Date = permit.ExpDate;
                    }
                    if (mode.Equals("read"))
                    {
                        Functions.DisableControls(Page);
                        btnSubmit.Visible = false;
                        btnDelete.Visible = false;
                        ltSubTitle.Text = "View Permits";
                        btnCancel.Visible = false;
                    }
                    else if (mode.Equals("delete"))
                    {
                        ltSubTitle.Text = "Delete Permit of " + c.Company;
                        pnDelete.Visible = true;
                        pnDetails.Visible = false;
                        btnCancel.Visible = false;
                        btnDelete.Visible = false;
                        btnSubmit.Visible = false;
                    }
                    else
                    {
                        ltSubTitle.Text = "Add permit to: " + c.Company;
                    }
                }
            }
        }

        protected void ddTypeOfPermit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddTypeOfPermit.SelectedValue.Equals("6") || ddTypeOfPermit.SelectedValue.Equals("7"))
            {
                phAutoInsurance.Visible = true;
                phWaterSewer.Visible = false;
            }
            else if (ddTypeOfPermit.SelectedValue.Equals("2") || ddTypeOfPermit.SelectedValue.Equals("3"))
            {
                phWaterSewer.Visible = true;
                phAutoInsurance.Visible = false;
            }
            else
            {
                phWaterSewer.Visible = false;
                phAutoInsurance.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int cID = int.Parse(Request.QueryString["cID"]);
            int ID = int.Parse(Request.QueryString["ID"]);
            string mode = Request.QueryString["mode"];
            QCTLinqDataContext db = new QCTLinqDataContext();
            Permit p = new Permit();
            if (mode.Equals("edit"))
                p = db.Permits.Single(permit => permit.ID == ID);
            else
                p.cID = cID;
            
            p.TypeOfPermit = ddTypeOfPermit.SelectedIndex > 0 ? int.Parse(ddTypeOfPermit.SelectedValue) : (int?)null;
            p.CGLIns = ddCGL.Value;
            p.AutoIns = ddAutoInsurance.Value;
            p.TypeOfSecurity = ddTypeOfSecurity.SelectedIndex > 0 ? int.Parse(ddTypeOfSecurity.SelectedValue) : (int?)null;
            p.ExpDate = dddExpiryDate.Date;
            if (!mode.Equals("edit"))
                db.Permits.InsertOnSubmit(p);
            db.SubmitChanges();
            
            notAgreement.Message = "Permit saved!";
            notAgreement.Type = "success";
            notAgreement.Visible = true;
            Functions.ScrollToTop(Page);
            
        }

        protected void lnkConfirmDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            QCTLinqDataContext db = new QCTLinqDataContext();
            Permit p = db.Permits.Single(permit => permit.ID == ID);
            db.Permits.DeleteOnSubmit(p);
            db.SubmitChanges();
            notAgreement.Message = "Permit has been deleted!";
            notAgreement.Type = "success";
            notAgreement.Visible = true;
            lnkConfirmDelete.Visible = false;
            lnkCancelDelete.Visible = false;
            btnCancel.Visible = true;
            pnDelete.Visible = false;
            
        }

        protected void lnkCancelDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Permits.aspx?ID=" + Request.QueryString["ID"] + "&cID=" + Request.QueryString["cID"] + "&mode=edit");
        }
    }
}