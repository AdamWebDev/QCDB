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
    public partial class Licenses : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            String mode = Request.QueryString["mode"];

            if (!Page.IsPostBack)
            {
                if (mode.Equals("edit"))
                    Functions.SecurePage();

                int ID = Int32.Parse(Request.QueryString["ID"]);
                int cID = Int32.Parse(Request.QueryString["cID"]);
                Contractor c = Classes.Contractors.GetContractor(cID);

                if (mode.Equals("edit") || mode.Equals("read"))
                {
                    btnDelete.Visible = true;
                    ltSubTitle.Text = "Edit licence of: " + c.Company;
                    QCTLinqDataContext db = new QCTLinqDataContext();
                    Licence l = db.Licences.Single(li => li.ID == ID);
                    txtTypeOfLicense.Text = l.TypeOfLicence;
                    ddCopyReceived.Value = l.CopyReceived;
                    txtFiledWith.Text = l.LicFiledWith;
                    ddDivision.DivisionID = l.Dept;
                }
                if (mode.Equals("read"))
                {
                    Functions.DisableControls(Page);
                    btnSubmit.Visible = false;
                    btnDelete.Visible = false;
                    ltSubTitle.Text = "View Licences";
                    btnCancel.Visible = false;
                }
                else if (mode.Equals("delete"))
                {
                    ltSubTitle.Text = "Delete Licence of " + c.Company;
                    pnDelete.Visible = true;
                    pnDetails.Visible = false;
                    btnCancel.Visible = false;
                    btnDelete.Visible = false;
                }
                else
                    ltSubTitle.Text = "Add Licence to: " + c.Company;

                btnCancel.NavURL = "~/EditContractor.aspx?ID=" + cID.ToString() + "#licences";
                btnDelete.NavURL = "~/Licences.aspx?ID=" + ID.ToString() + "&cID=" + cID.ToString() + "&mode=delete";
            }
        }
        //
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ID = Int32.Parse(Request.QueryString["ID"]);
            int cID = Int32.Parse(Request.QueryString["cID"]);
            string mode = Request.QueryString["mode"];

            QCTLinqDataContext db = new QCTLinqDataContext();
            Licence l = new Licence();
            if (mode.Equals("edit"))
                l = db.Licences.Single(li => li.ID == ID);
            else
                l.cID = cID;

            l.TypeOfLicence = txtTypeOfLicense.Text;
            l.CopyReceived = ddCopyReceived.Value;
            l.LicFiledWith = txtFiledWith.Text;
            l.Dept = ddDivision.DivisionID;
            if (!mode.Equals("edit"))
                db.Licences.InsertOnSubmit(l);
            db.SubmitChanges();
            notNotification.Type = "success";
            notNotification.Message = "Permit saved!";
            notNotification.Visible = true;
            Functions.ScrollToTop(Page);
           
        }

        protected void lnkConfirmDelete_Click(object sender, EventArgs e)
        {
            int ID = Int32.Parse(Request.QueryString["ID"]);
            QCTLinqDataContext db = new QCTLinqDataContext();
            Licence l = db.Licences.Single(li => li.ID == ID);
            db.Licences.DeleteOnSubmit(l);
            db.SubmitChanges();
            notNotification.Message = "Licence has been deleted!";
            notNotification.Type = "success";
            notNotification.Visible = true;
            lnkConfirmDelete.Visible = false;
            lnkCancelDelete.Visible = false;
            btnCancel.Visible = true;
            pnDelete.Visible = false;
            
        }

        protected void lnkCancelDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("Licences.aspx?ID=" + Request.QueryString["ID"] + "&cID=" + Request.QueryString["cID"] + "&mode=edit");
        }
    }
}