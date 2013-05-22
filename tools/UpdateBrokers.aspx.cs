using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Qualified_Contractor_Tracking.tools
{
    public partial class UpdateBrokers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadGrid1_OnPreRender(object sender, EventArgs e)
        {

        }

        protected void RadGrid1_InsertCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem && e.Item.IsInEditMode)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                //Hides the Update button for each edit form
                dataItem["EditCommandColumn"].Controls[2].Visible = false;
            }
        }

        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (GridItem item in RadGrid1.MasterTableView.Items)
                {
                    if (item is GridEditableItem)
                    {
                        GridEditableItem editableItem = item as GridDataItem;
                        editableItem.Edit = true;
                    }
                }
                RadGrid1.Rebind();
            }
        }

        protected void RadGrid1_ItemUpdated(object sender, GridUpdatedEventArgs e)
        {
            string radalertscript  ="";
            if (e.Exception != null)
            {
                 radalertscript = "<script language='javascript'>function f(){radalert('There was an error updating this record...', 230, 110); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
            }
            else
            {
                radalertscript = "<script language='javascript'>function f(){radalert('Record updated!', 230, 110); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript); 
            e.KeepInEditMode = true;
        }

        protected void RadGrid1_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            foreach (GridItem item in RadGrid1.MasterTableView.Items)
            {
                if (item is GridEditableItem)
                {
                    GridEditableItem editableItem = item as GridDataItem;
                    editableItem.Edit = true;
                }
            }
            RadGrid1.Rebind();
        }

    }
}