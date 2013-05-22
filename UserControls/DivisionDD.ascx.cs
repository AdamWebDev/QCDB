using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Qualified_Contractor_Tracking
{
    public partial class DivisionDD : System.Web.UI.UserControl
    {
        public int? DivisionID
        {
            get
            {
                return ddDiv.SelectedIndex > 0 ? int.Parse(ddDiv.SelectedValue) : (int?)null;
            }
            set
            {
                if (value.HasValue)
                {
                    ccd1.SelectedValue = _GetDepartment(value).ToString();
                    ccd2.SelectedValue = value.ToString();
                }
            }
        }

        public bool Enabled
        {
            set
            {
                if (value)
                {
                    ddDept.Enabled = true;
                    ddDiv.Enabled = true;
                }
                else
                {
                    ddDept.Enabled = false;
                    ddDiv.Enabled = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        

        public void Clear()
        {
            ddDiv.SelectedIndex = 0;
            ddDept.SelectedIndex = 0;
        }

        private int _GetDepartment(int? DivisionID)
        {
            if (DivisionID.HasValue) {
                QCTLinqDataContext db = new QCTLinqDataContext();
                int? dept = (from d in db.Divisions
                           where d.ID == DivisionID
                           select d.Department).SingleOrDefault();
                return (int)dept;
            }
            else 
                return 0;

            
        }

    }
}