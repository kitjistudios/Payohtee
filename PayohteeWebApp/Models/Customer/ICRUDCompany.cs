using System.Collections.Generic;

namespace Payohtee.Models.Customer
{
    interface ICRUDCompany
    {

        /// <summary>
        /// Get list of company records
        /// </summary>
        /// <value>
        /// this should return a list of all company records
        /// </value>
        List<Company> GetListCompany();

        /// <summary>
        /// Get list of company names
        /// </summary>
        /// <value>
        /// this should return a list of company names
        /// </value>
        List<string> GetListCompanyName();

        /// <summary>
        /// Get list asynchronously
        /// </summary>
        /// <value>
        /// this should allow the asynch list search of company names
        /// this is for the asynchronous search for suggestive search in UI
        /// </value>
        List<string> GetAsyncListCompanyName(string c);

        /// <summary>
        /// Company Status
        /// </summary>
        /// <value>
        /// Value should refer to the status of the company
        /// This should be pipe delimited to allow range of states
        /// </value>
        void DeleteCompany(int id);

        /// <summary>
        /// Company Status
        /// </summary>
        /// <value>
        /// Value should refer to the status of the company
        /// This should be pipe delimited to allow range of states
        /// </value>
        void EditCompany(int id);

        /// <summary>
        /// Company Status
        /// </summary>
        /// <value>
        /// Value should refer to the status of the company
        /// This should be pipe delimited to allow range of states
        /// </value>
        //void GetCompany(int? id);
        Company GetCompany(string companyname);
        /// <summary>
        /// Company Status
        /// </summary>
        /// <value>
        /// Value should refer to the status of the company
        /// This should be pipe delimited to allow range of states
        /// </value>
        void CreateCompany(Company company);

        /// <summary>
        /// Company Status
        /// </summary>
        /// <value>
        /// Value should refer to the status of the company
        /// This should be pipe delimited to allow range of states
        /// </value>
        bool CompanyExists(int id);
    }
}
