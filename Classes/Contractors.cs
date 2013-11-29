using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qualified_Contractor_Tracking.Classes
{
    public partial class AvailableContractorDetails : AvailableContractor
    {
        public bool IsValid { get; set; }
    }
    
    public class Contractors
    {
        public static Contractor GetContractor(int ID) {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.Contractors.Single(c => c.ID == ID);
        }

        public static string GetContractorName(int ID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.Contractors.Where(u => u.ID == ID).Select(u => u.Company).Single();
        }

        public static List<lookupPhoneType> GetPhoneTypes()
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.lookupPhoneTypes.ToList();
        }

        public class PhoneDetails
        {
            public int ID { get; set; }
            public string PhoneNumber { get; set; }
            public string PhoneType { get; set; }
        }

        public static List<PhoneDetails> GetPhoneNumbers(int cID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            var q = from p in db.ContractorsPhones
                    where p.cID == cID
                    select new PhoneDetails()
                    {
                        ID = p.ID,
                        PhoneNumber = p.PhoneNumber,
                        PhoneType = p.lookupPhoneType.Value
                    };
            return q.ToList();
        }

        public static List<TypeOfWSIB> GetWSIBTypes()
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.TypeOfWSIBs.ToList();
        }

        public class InsuranceDetails
        {
            public InsurancePolicy InsurancePolicy { get; set; }
            public string Type { get; set; }
            public string Value { get; set; }
        }

        public static List<InsuranceDetails> GetInsurance(int cID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            var q = from i in db.InsurancePolicies
                    where i.cID == cID
                    select new InsuranceDetails()
                    {
                        InsurancePolicy = i,
                        Type = i.TypeOfPolicy1.Type,
                        Value = i.PolicyLimit.HasValue ? i.PolicyLimit1.Value : i.PolicyLimitOther
                    };
            return q.ToList();
        }

        public class AgreementDetails
        {
            public Agreement Agreement { get; set; }
            public string TypeOfAgreement { get; set; }
        }

        public static List<AgreementDetails> GetAgreements(int cID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            var q = from a in db.Agreements
                    where a.cID == cID
                    select new AgreementDetails()
                    {
                        Agreement = a,
                        TypeOfAgreement = a.TypeOfAgreement1.Value
                    };
            return q.ToList();
        }

        public static List<Permit> GetPermits(int cID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            var q = from p in db.Permits
                    where p.cID == cID
                    select p;
            return q.ToList();
        }

        public static List<Licence> GetLicenses(int cID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            var q = from l in db.Licences
                    where l.cID == cID
                    select l;
            return q.ToList();
        }

        public class JobDetails
        {
            public Tag Job { get; set; }
            public String JobTitle { get; set; }
        }

        public static List<JobDetails> GetJobs(int cID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            var q = from j in db.Tags
                    where j.cID == cID
                    join t in db.lookupTags on j.tID equals t.ID
                    select new JobDetails()
                    {
                        Job = j,
                        JobTitle = t.Job
                    };
            return q.ToList();
        }

        public static WSIB GetWSIB(int cID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.WSIBs.SingleOrDefault(w => w.cID == cID);
        }

        public class ContractorsWithServices {
            public int ID { get; set; }
            public string Company {get; set; }
            public string Email { get; set; }
            public bool IsValid { get; set; }
            public string MatchingService { get; set; }
        }

        public static List<ContractorsWithServices> GetContractorsByService(String service)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            var contractors = from t in db.lookupTags
                      join Tags in db.Tags on new { ID = t.ID } equals new { ID = Convert.ToInt32(Tags.tID) }
                      join c in db.AvailableContractors on new { CID = Convert.ToInt32(Tags.cID) } equals new { CID = c.ID }
                      where t.Job.Contains(service)
                      select new ContractorsWithServices
                      {
                          ID = c.ID,
                          Company = c.Company,
                          Email = c.Email,
                          IsValid = (c.HasValidCGL == 1 && c.HasHSPolicy == 1 && c.HasAODA == 1 && (c.ExemptFromAuto == true || c.ValidAuto == 1 )) ? true : false,
                          MatchingService = t.Job
                      };
            return contractors.ToList();
        }

        public static List<AvailableContractorDetails> GetContractors()
        {
            return GetContractors(String.Empty,false);
        }

        public static List<AvailableContractorDetails> GetContractors(String searchName)
        {
            return GetContractors(searchName, false);
        }

        

        public static List<AvailableContractorDetails> GetContractors(String searchName, bool ShowAvailableOnly)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            var q = from c in db.AvailableContractors
                    select new AvailableContractorDetails
                    {
                        ID = c.ID,
                        Company = c.Company,
                        VendorNumber = c.VendorNumber,
                        Town = c.Town,
                        Email = c.Email,
                        HasValidCGL = c.HasValidCGL,
                        HasHSPolicy = c.HasHSPolicy,
                        HasAODA = c.HasAODA,
                        ValidWSIB = c.ValidWSIB,
                        ValidAuto = c.ValidAuto,
                        ExemptFromAuto = c.ExemptFromAuto,
                        IsValid = (c.HasValidCGL == 1 && c.HasHSPolicy == 1 && c.HasAODA == 1 && (c.ValidAuto == 1 || c.ExemptFromAuto == true)),
                        //IsValid = true,
                        ContactName = c.ContactName,
                        PostalCode = c.PostalCode
                    };
            
            if (!searchName.Equals(String.Empty))
            {
                var z = from c in q
                    where c.Company.Contains(searchName)
                    select c;
                q = z;
            }
            
            if (ShowAvailableOnly)
            {
                var z = from c in q
                        where c.IsValid == true
                        select c;
                q = z;
            }
            return q.ToList();
        }
    }
}