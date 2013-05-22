using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;



namespace Qualified_Contractor_Tracking
{
    /// <summary>
    /// Summary description for AutoSuggestWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AutoSuggestWebService : System.Web.Services.WebService
    {

        [WebMethod(Description="Get the available tags")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetTags(string prefixText)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            var q = from t in db.lookupTags
                    where t.Job.StartsWith(prefixText)
                    select t;
            string[] tags = new string[q.Count()];
            int i=0;
            foreach(lookupTag tag in q)
            {
                tags.SetValue(tag.Job,i);
                i++;
            }

            return tags;
        }
    }
}
