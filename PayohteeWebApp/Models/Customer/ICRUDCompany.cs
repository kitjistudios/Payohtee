using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payohtee.Models.Customer
{
    interface ICRUDCompany
    {
        /// <summary>
        /// My contract should create a new company record
        /// </summary>
        /// <value>
        /// this should create a new company
        /// </value>
        void CreateCompany(Company company);

        /// <summary>
        /// My contract should get a list of company objects
        /// </summary>
        /// <value>
        /// this should return a list of all company records
        /// </value>
        List<Company> GetListCompany();

        /// <summary>
        /// My contract should get a list of company names
        /// </summary>
        /// <value>
        /// this should return a list of company names
        /// </value>
        List<string> GetListCompanyName();

        /// <summary>
        /// My contract should get a suggestive list of companies
        /// </summary>
        /// <value>
        /// this should allow the asynch list search of company names
        /// this is for the asynchronous search for suggestive search in UI
        /// </value>
        Task<List<string>> GetAsyncListCompanyName(string c);

        /// <summary>
        /// My contract should get company object 
        /// </summary>
        /// <value>
        /// this should select the company object by id
        /// </value>
        Company GetCompany(string companyname);

        /// <summary>
        /// My contract should select a company to be edited
        /// </summary>
        /// <value>
        /// this should select the record to be edited by id
        /// </value>
        void EditCompany(int id);

        /// <summary>
        /// My contract should flag a company for deletion
        /// </summary>
        /// <value>
        /// this should flag the record for deletion
        /// </value>
        void DeleteCompany(int id);

        /// <summary>
        /// My contract should check to see if the company exists
        /// </summary>
        /// <value>
        /// this should check to see it the company exists
        /// </value>
        bool CompanyExists(int id);
    }
}
