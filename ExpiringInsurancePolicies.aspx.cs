﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Qualified_Contractor_Tracking
{
    public partial class ExpiringInsurancePolicies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rptExpIns.DataSource = Classes.Insurance.GetExpiringInsurancePolicies();
                rptExpIns.DataBind();
            }
        }
    }
}