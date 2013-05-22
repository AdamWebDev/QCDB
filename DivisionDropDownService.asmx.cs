using System.Web.Script.Services;
using AjaxControlToolkit;
using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

    [ScriptService]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class DivisionDropDownService : System.Web.Services.WebService
    {
        [WebMethod]
        public CascadingDropDownNameValue[] GetDepartments(string knownCategoryValues, string category)
        {
            IEnumerable depts = GetDepartments();
            List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();
            l.Add(new CascadingDropDownNameValue("--Select--",""));
            foreach (Qualified_Contractor_Tracking.Department dept in depts)
            {
                l.Add(new CascadingDropDownNameValue(dept.Value,dept.ID.ToString()));
            }
            return l.ToArray();
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetDivisions(string knownCategoryValues, string category) 
        {
            int DepartmentID;
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            if (!kv.ContainsKey("Departments") || !Int32.TryParse(kv["Departments"], out DepartmentID))
            {
                throw new ArgumentException("Couldn't find department.");
            }
            IEnumerable divisions = GetDivisions(DepartmentID);
            List<CascadingDropDownNameValue> l = new List<CascadingDropDownNameValue>();
            l.Add(new CascadingDropDownNameValue("--Select--",""));
            foreach (Qualified_Contractor_Tracking.Division div in divisions)
            {
                l.Add(new CascadingDropDownNameValue(div.Division1,div.ID.ToString()));
            }
            return l.ToArray();
        }

        private IEnumerable<Qualified_Contractor_Tracking.Department> GetDepartments()
        {
            Qualified_Contractor_Tracking.QCTLinqDataContext db = new Qualified_Contractor_Tracking.QCTLinqDataContext();
            return db.Departments.ToList();
        }

        private IEnumerable<Qualified_Contractor_Tracking.Division> GetDivisions(int deptID)
        {
            Qualified_Contractor_Tracking.QCTLinqDataContext db = new Qualified_Contractor_Tracking.QCTLinqDataContext();
            var q = from d in db.Divisions
                    where d.Department == deptID
                    select d;
            return q.ToList();
        }

    }
