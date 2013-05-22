using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Qualified_Contractor_Tracking
{
    public partial class DateDropDown : System.Web.UI.UserControl
    {
        private int startYear = DateTime.Now.Year - 3;
        private int span = 23;

        public int Day
        {
            get { return Int32.Parse(ddDay.SelectedValue); }
            set {
                if (value > 0)
                    ddDay.SelectedValue = value.ToString();
                else
                    ddDay.SelectedIndex = 0;
            }
        }

        public int Month
        {
            get { return Int32.Parse(ddMonth.SelectedValue); }
            set {
                if (value > 0)
                    ddMonth.SelectedValue = value.ToString();
                else
                    ddMonth.SelectedIndex = 0;
            }
        }

        public int Year
        {
            get { return Int32.Parse(ddYear.SelectedValue); }
            set {
                if (value > 0)
                    ddYear.SelectedValue = value.ToString();
                else
                    ddYear.SelectedIndex = 0;
            }
        }

        public int Span
        {
            set
            {
                span = value;
            }
        }

        public DateTime? Date
        {
            get
            {
                DateTime tempDateTime;
                String ddDateTime = ddDay.SelectedValue + "/" + ddMonth.SelectedValue + "/" + ddYear.SelectedValue;
                if (DateTime.TryParse(ddDateTime, out tempDateTime))
                    return tempDateTime;
                else
                    return (DateTime?)null;
            }
            set
            {
                if (value != null)
                {
                    DateTime date = (DateTime)value;
                    ddDay.SelectedValue = date.Day.ToString();
                    ddMonth.SelectedValue = date.Month.ToString();
                    int year = Int32.Parse(date.ToString("yyyy"));
                    if (year < startYear)
                    {
                        startYear = year;
                        ddYear.Items.Clear();
                        for (int i = startYear; i <= startYear + span; i++)
                        {
                            ddYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                        }
                        ddYear.DataBind();
                    }
                    else if (year > (startYear + 10))
                    {
                        ddYear.Items.Clear();
                        for (int i = startYear; i <= year + span; i++)
                        {
                            ddYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                        }
                        ddYear.DataBind();
                    }
                    ddYear.SelectedValue = year.ToString();
                }
            }
        }

        public String StartYear
        {
            set { 
                startYear = Int32.Parse(value);
            }
        }

        public Boolean Enabled
        {
            set {   
                if(!value) {
                    ddDay.Enabled = false;
                    ddMonth.Enabled = false;
                    ddYear.Enabled = false;
                }
            }

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
                for (int i = 1; i < 13; i++)
                {
                    ddMonth.Items.Add(new ListItem(info.GetMonthName(i), i.ToString()));
                    ddMonth.DataBind();
                }
                for (int i = 1; i <= 31; i++)
                {
                    ddDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    ddDay.DataBind();
                }

                for (int i = startYear; i <= startYear + span; i++)
                {
                    ddYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    ddYear.DataBind();
                }
            }
        }

        public void ClearItems()
        {
            ddDay.SelectedIndex = 0;
            ddMonth.SelectedIndex = 0;
            ddYear.SelectedIndex = 0;
        }

        public bool IsValid()
        {
            if (ddDay.SelectedIndex > 0 && ddMonth.SelectedIndex > 0 && ddYear.SelectedIndex > 0)
            {
                DateTime tempDateTime;
                String ddDateTime = ddDay.SelectedValue + "/" + ddMonth.SelectedValue + "/" + ddYear.SelectedValue;
                if (DateTime.TryParse(ddDateTime, out tempDateTime))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}