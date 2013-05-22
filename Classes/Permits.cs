using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qualified_Contractor_Tracking.Classes
{
    public class Permits
    {
        public static List<TypeOfPermit> GetTypes()
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.TypeOfPermits.ToList();
        }

        public static List<Security> GetSecurityTypes()
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.Securities.ToList();
        }
    }   
}