using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public static Qualified_Contractor_Tracking.Insurance GetPolicy(int ID)
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.Insurances.Single(i => i.ID == ID);
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
        /// Gets all insurance brokers
        /// </summary>
        /// <returns>List of insurance brokers</returns>
        public static List<InsuranceBroker> GetInsuranceBrokers()
        {
            QCTLinqDataContext db = new QCTLinqDataContext();
            return db.InsuranceBrokers.ToList();
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
    }
}