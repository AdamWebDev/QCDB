using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qualified_Contractor_Tracking.Classes
{
    public class Agreements
    {
        public static List<TypeOfAgreement> GetAgreementTypes()
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.TypeOfAgreements.ToList();
        }

        public static List<AgreementsSigned> GetAgreementsSigned()
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.AgreementsSigneds.ToList();
        }

        public static List<Security> GetSecurityTypes()
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.Securities.ToList(); 
        }

        public static Agreement GetAgreement(int ID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.Agreements.Single(a => a.cID == ID);
        }
    }
}