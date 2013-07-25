using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qualified_Contractor_Tracking.UserControls;
using Telerik.Web.UI;
using System.IO;


namespace Qualified_Contractor_Tracking.Classes
{
    public class Insurance
    {
        /// <summary>
        /// Get Types of Policies
        /// </summary>
        public static List<TypeOfPolicy> GetTypes()
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.TypeOfPolicies.ToList();
        }

        /// <summary>
        /// Get Policy Limits
        /// </summary>
        public static List<PolicyLimit> GetLimits()
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.PolicyLimits.ToList();
        }

        /// <summary>
        ///  Get a specific Insurance Policy 
        /// </summary>
        /// <param name="ID">ID of the policy to be returned</param>
        public static InsurancePolicy GetPolicy(int ID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.InsurancePolicies.Single(i => i.ID == ID);
        }

        /// <summary>
        /// Gets all insurance companies
        /// </summary>
        /// <returns>A list of insurance companies</returns>
        public static List<InsuranceCompany> GetInsuranceCompanies()
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.InsuranceCompanies.OrderBy(i => i.Name).ToList();
        }

        /// <summary>
        /// Gets a specific insurance company
        /// </summary>
        /// <param name="ID">ID of the insurance company in question</param>
        /// <returns>A single Insurance Company object</returns>
        public static InsuranceCompany GetInsuranceCompany(int ID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.InsuranceCompanies.Where(i => i.ID == ID).SingleOrDefault();
        }

        /// <summary>
        /// Adds an insurance company
        /// </summary>
        /// <param name="name">Name of the insurance company</param>
        /// <param name="email">Email address of the insurance company</param>
        public static void AddInsuranceCompany(string name,string email)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            InsuranceCompany i = new InsuranceCompany
            {
                Name = name,
                Email = email,
                Active = true
            };
            db.InsuranceCompanies.InsertOnSubmit(i);
            db.SubmitChanges();
        }

        /// <summary>
        /// Get the email address of an insurance company
        /// </summary>
        /// <param name="ID">ID of the insurance comapny</param>
        /// <returns>Email address (string)</returns>
        public static String GetInsuranceCompanyEmail(int ID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.InsuranceCompanies.Where(i => i.ID == ID).Select(e => e.Email).FirstOrDefault();
        }

        /// <summary>
        /// Returns a specific insurance broker
        /// </summary>
        /// <param name="ID">ID of the insurance broker</param>
        /// <returns>Insurance broker object</returns>
        public static InsuranceBroker GetInsuranceBroker(int ID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.InsuranceBrokers.Single(i => i.ID == ID);
        }

        /// <summary>
        /// Gets all insurance brokers
        /// </summary>
        /// <returns>List of insurance brokers</returns>
        public static List<InsuranceBroker> GetInsuranceBrokers()
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.InsuranceBrokers.OrderBy(i => i.Name).ToList();
        }

        /// <summary>
        /// Adds an insurance broker
        /// </summary>
        /// <param name="name">Name of the insurance broker</param>
        public static void AddInsuranceBroker(string name)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            InsuranceBroker b = new InsuranceBroker
            {
                Name = name,
                Active = true
            };
            db.InsuranceBrokers.InsertOnSubmit(b);
            db.SubmitChanges();
        }


        /// <summary>
        /// Gets the email addresses associated with a specific broker
        /// </summary>
        /// <param name="bID">ID of the broker</param>
        /// <returns>A list of email addresses</returns>
        public static List<InsuranceBrokerEmail> GetInsuranceBrokerEmails(int bID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.InsuranceBrokerEmails.Where(e => e.bID == bID).OrderBy(e => e.Email).ToList();
        }

        /// <summary>
        /// Adds an email address associated with an insurance broker
        /// </summary>
        /// <param name="email">Email address of the broker</param>
        /// <param name="bID">ID of the related broker</param>
        public static void AddInsuranceBrokerEmail(string email, int bID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            InsuranceBrokerEmail e = new InsuranceBrokerEmail
            {
                Email = email,
                bID = bID,
                Active = true
            };
            db.InsuranceBrokerEmails.InsertOnSubmit(e);
            db.SubmitChanges();
        }

        /// <summary>
        /// Creates a new insurance policy
        /// </summary>
        /// <param name="cID">Contractor ID</param>
        /// <param name="p">Policy Details</param>
        public static void AddNewPolicy(int cID, InsurancePolicyEditor p)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            
            // create and populate!
            InsurancePolicy ins = new InsurancePolicy();
            ins.cID = cID;
            ins.TenantsLegalLiability = p.TenantsLiability;
            ins.CertReqFor = p.CertificateRequestFor;
            ins.TypeOfPolicy = p.TypeOfPolicy;
            ins.PerOccurance = p.PerOccurance;
            ins.ProductsCompletedOps = p.ProductsCompletedOps;
            ins.NonOwnedAuto = p.NonOwnedAuto;
            ins.CrossLiability = p.CrossLiability;
            ins.NCasAddIns = p.NorfolkCountyAsAdditionallyInsured;
            ins.PolicyNumber = p.PolicyNumber;
            ins.PolicyLimit = p.PolicyLimit;
            ins.PolicyLimitOther = p.PolicyLimitOther;
            ins.ExpiryDate = p.ExpiryDate;
            ins.insID = p.InsuranceCompany;
            ins.BrokerID = p.Broker;
            ins.BrokerEmailID = p.BrokerEmail;
            ins.CertSigned = p.CertificateSigned;
            ins.Active = p.Active;
            // save to database!
            db.InsurancePolicies.InsertOnSubmit(ins);
            db.SubmitChanges();

            // let's look at the uploaded file
            if (p.Files.Count > 0) // see if there's a file to attach...
                UploadInsuranceDocument(ins.ID, p.Files);
        }

        public static void EditPolicy(int ID, InsurancePolicyEditor p)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();

            // create and populate!
            InsurancePolicy ins = db.InsurancePolicies.Single(i => i.ID == ID);
            ins.TenantsLegalLiability = p.TenantsLiability;
            ins.CertReqFor = p.CertificateRequestFor;
            ins.TypeOfPolicy = p.TypeOfPolicy;
            ins.PerOccurance = p.PerOccurance;
            ins.ProductsCompletedOps = p.ProductsCompletedOps;
            ins.NonOwnedAuto = p.NonOwnedAuto;
            ins.CrossLiability = p.CrossLiability;
            ins.NCasAddIns = p.NorfolkCountyAsAdditionallyInsured;
            ins.PolicyNumber = p.PolicyNumber;
            ins.PolicyLimit = p.PolicyLimit;
            ins.PolicyLimitOther = p.PolicyLimitOther;
            ins.ExpiryDate = p.ExpiryDate;
            ins.insID = p.InsuranceCompany;
            ins.BrokerID = p.Broker;
            ins.BrokerEmailID = p.BrokerEmail;
            ins.CertSigned = p.CertificateSigned;
            ins.Active = p.Active;
            // save to database!
            db.SubmitChanges();

            // let's look at the uploaded file
            if (p.Files.Count > 0) // see if there's a file to attach...
                UploadInsuranceDocument(ins.ID, p.Files);
        }

        private static void UploadInsuranceDocument(int ID, UploadedFileCollection files)
        {
            String directory = HttpContext.Current.Server.MapPath("uploads");
            directory = directory + "/" + ID.ToString(); // build the path to the file upload
            // if the directory doesn't exist already, create it
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            // upload the file and rename it to attachment.pdf
            foreach (UploadedFile file in files)
            {
                file.SaveAs(directory + "/attachment" + file.GetExtension(), true);
                String filelnk = "uploads/" + ID.ToString() + "/attachment.pdf";
            }
        }

        public static List<ExpiringInsurancePolicy> GetExpiringInsurancePolicies()
        {
            return GetExpiringInsurancePolicies("company");
        }

        public static List<ExpiringInsurancePolicy> GetExpiringInsurancePolicies(string sortby)
        {
            ExpiringInsuranceDataContext db = new ExpiringInsuranceDataContext();
            switch (sortby)
            {
                case "expiry":
                    return db.ExpiringInsurancePolicies.OrderBy(i => i.ExpiryDate).ToList();
                default:
                    return db.ExpiringInsurancePolicies.OrderBy(i => i.Company).ToList();
            }
        }
    }
}