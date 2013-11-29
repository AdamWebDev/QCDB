using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Qualified_Contractor_Tracking.Classes
{
    public class Functions
    {
        public static String MergeValues(Control o)
        {
            String output = "";
            if (o is CheckBoxList)
            {
                CheckBoxList chkList = (CheckBoxList)o;
                foreach (ListItem c in chkList.Items)
                {
                    output += c.Value + ";";
                }
            }
            return output;
        }

        public static void ClearControls(Control o)
        {
            foreach (Control c in o.Controls)
            {
                if (c is TextBox)
                {
                    TextBox d = (TextBox)c;
                    d.Text = String.Empty;
                }
                else if (c is DropDownList)
                {
                    DropDownList d = (DropDownList)c;
                    d.SelectedIndex = 0;
                }
                else if (c is DateDropDown)
                {
                    DateDropDown d = (DateDropDown)c;
                    d.ClearItems();
                }
                else if (c is CheckBoxList)
                {
                    CheckBoxList d = (CheckBoxList)c;
                    foreach (ListItem f in d.Items)
                    {
                        f.Selected = false;
                    }
                }
                else if (c is TrueFalseDropDown)
                {
                    TrueFalseDropDown d = (TrueFalseDropDown)c;
                    d.Clear();
                }
                else if (c is DivisionDD)
                {
                    DivisionDD d = (DivisionDD)c;
                    d.Clear();
                }
            }
        }

        public static void DisableControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                {
                    TextBox d = (TextBox)c;
                    d.Enabled = false;
                }
                else if (c is DropDownList)
                {
                    DropDownList d = (DropDownList)c;
                    d.Enabled = false;
                }
                else if (c is DateDropDown)
                {
                    DateDropDown d = (DateDropDown)c;
                    d.Enabled = false;
                }
                else if (c is CheckBoxList)
                {
                    CheckBoxList d = (CheckBoxList)c;
                    foreach (ListItem f in d.Items)
                    {
                        f.Enabled = false;
                    }
                }
                else if (c is TrueFalseDropDown)
                {
                    TrueFalseDropDown d = (TrueFalseDropDown)c;
                    d.Enabled = false;
                }
                else if (c is DivisionDD)
                {
                    DivisionDD d = (DivisionDD)c;
                    d.Enabled = false;
                }

                DisableControls(c);
            }
        }

        public static void AddParameter(Control o, SqlCommand c, String fieldname)
        {
            if (o is TextBox)
            {
                TextBox txt = (TextBox)o;
                if(txt.Text.Length > 0)
                    c.Parameters.AddWithValue(fieldname, txt.Text);
                else
                    c.Parameters.AddWithValue(fieldname, DBNull.Value);
            }
            else if (o is DateDropDown)
            {
                DateDropDown ddd = (DateDropDown)o;
                if (ddd.IsValid())
                    c.Parameters.AddWithValue(fieldname, ddd.Date);
                else
                    c.Parameters.AddWithValue(fieldname, DBNull.Value);
            }
            else if (o is DropDownList)
            {
                DropDownList dd = (DropDownList)o;
                if (dd.SelectedIndex > 0)
                    c.Parameters.AddWithValue(fieldname, dd.SelectedValue);
                else
                    c.Parameters.AddWithValue(fieldname, DBNull.Value);
            }
            else if (o is CheckBoxList)
            {
                CheckBoxList chk = (CheckBoxList)o;
                c.Parameters.AddWithValue(fieldname,MergeValues(chk));
            }
            else if (o is TrueFalseDropDown)
            {
                TrueFalseDropDown dd = (TrueFalseDropDown)o;
                if (dd.Value == null)
                    c.Parameters.AddWithValue(fieldname, DBNull.Value);
                else 
                    c.Parameters.AddWithValue(fieldname, dd.Value);
            }
            
        }

        public static void PopulateCheckBoxes(CheckBoxList c, String inputs)
        {
            char[] separator = new char[] { ';' };
            String[] values = inputs.Split(separator);
            foreach (String str in values)
            {
                foreach (ListItem li in c.Items)
                {
                    if (li.Value.Equals(str))
                    {
                        li.Selected = true;
                        break;
                    }
                }
            }

        }

        public static void ScrollToTop(Page Page)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ScrollPage", "ResetScrollPosition();", true);
        }

        public static void SecurePage()
        {
            /*if (!HttpContext.Current.User.IsInRole(System.Configuration.ConfigurationManager.AppSettings["AuthenticatedGroup"]))
                HttpContext.Current.Response.Redirect("~/Default.aspx");*/
        }

        public static bool CanEdit()
        {
            return true;
            /*if (HttpContext.Current.User.IsInRole(System.Configuration.ConfigurationManager.AppSettings["AuthenticatedGroup"]))
                return true;
            else
                return false;*/
        }

    }
}