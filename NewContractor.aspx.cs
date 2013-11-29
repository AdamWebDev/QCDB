using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace Qualified_Contractor_Tracking
{
    public partial class NewContractor : System.Web.UI.Page
    {
        protected void btnCreate_Click(object sender, EventArgs e)
        {

            QCTLinqDataContext db = new QCTLinqDataContext();
            Contractor c = new Contractor
            {
                Company = txtCompany.Text,
                VendorNumber = txtVendorNumber.Text,
                ContactName = txtContactName.Text,
                MailingAddress = txtMailAddress.Text,
                Town = txtTown.Text,
                PostalCode = txtPostalCode.Text,
                Email = txtEmail.Text,
                NCContact = txtNCContact.Text,
                ExemptFromAuto = false
            };
            db.Contractors.InsertOnSubmit(c);
            db.SubmitChanges();
            int ID = c.ID;

            WSIB w = new WSIB
            {
                cID = ID
            };
            db.WSIBs.InsertOnSubmit(w);
            db.SubmitChanges();

            Response.Redirect("~/EditContractor.aspx?ID=" + ID);
        }
    }
}