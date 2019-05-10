using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PayohteeWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Payohtee.Models.Customer
{
    /// <summary>
    /// Company class to represent external customers who interact with officers and department/entity.
    /// </summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.
    /// </remarks>
    [Table("Company")]
    public class Company : ICRUDCompany
    {
        #region Variables

        #endregion

        #region Constructor

        public Company()
        {
         
        }

        #endregion

        #region Propeties

        /// <summary>
        /// Company Identification
        /// </summary>
        /// <value>
        /// Value should be a system generate unique id
        /// </value>
        public int CompanyId { get; set; }
        /// <summary>
        /// Company Identification
        /// </summary>
        /// <value>
        /// Value should be a system generate unique id
        /// </value>
        public string PayohteeId { get; set; }
        /// <summary>
        /// Company Name
        /// </summary>
        /// <value>
        /// Value should be a single string name. Special characters are allowed
        /// </value>
        [Required]
        [StringLength(50)]
        [Display(Name = "Company Name")]
        [JsonProperty("CompanyName")]
        [JsonRequired]
        public string CompanyName { get; set; }
        /// <summary>
        /// Company Alias
        /// </summary>
        /// <value>
        /// Value should be a single string name. Special characters are allowed
        /// </value>
        [Required]
        [StringLength(50)]
        [Display(Name = "Company Alias")]
        [JsonProperty("CompanyAlias")]
        [JsonRequired]
        public string CompanyAlias { get; set; }
        /// <summary>
        /// Company Tax Number
        /// </summary>
        /// <value>
        /// Value should be a single string name. Special characters are allowed
        /// </value>
        [Required]
        [StringLength(50)]
        [Display(Name = "Company Tax Id")]
        [JsonProperty("CompanyTaxId")]
        [JsonRequired]
        public string CompanyTaxId { get; set; }
        /// <summary>
        /// Company Industry
        /// </summary>
        /// <value>
        /// Value should be a single string name. Special characters are allowed
        /// </value>
        [Required]
        [StringLength(50)]
        [Display(Name = "Company Industry")]
        [JsonProperty("CompanyIndustry")]
        [JsonRequired]
        public string CompanyIndustry { get; set; }
        /// <summary>
        /// Address 1
        /// </summary>
        /// <value>
        /// Value should refer to apt, ave etc
        /// </value>
        [StringLength(50)]
        [Display(Name = "Street Address")]
        [JsonProperty("Address1")]
        public string Address1 { get; set; }
        /// <summary>
        /// Address 2
        /// </summary>
        /// <value>
        /// Value should refer to road, street etc
        /// </value>
        [StringLength(50)]
        [Display(Name = "Apartment")]
        [JsonProperty("Address2")]
        public string Address2 { get; set; }
        /// <summary>
        /// Address 3
        /// </summary>
        /// <value>
        /// Value should refer to county, village, district etc
        /// </value>
        [StringLength(50)]
        [Display(Name = "City")]
        [JsonProperty("Address3")]
        public string Address3 { get; set; }
        /// <summary>
        /// Address 4
        /// </summary>
        /// <value>
        /// Value should refer to toe, street etc
        /// </value>
        [StringLength(50)]
        [Display(Name = "District")]
        [JsonProperty("Address4")]
        public string Address4 { get; set; }
        /// <summary>
        /// Parish
        /// </summary>
        /// <value>
        /// Value should refer to parish in given country
        /// </value>
        [StringLength(50)]
        [Display(Name = "Parish")]
        [JsonProperty("Parish")]
        public string Parish { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        /// <value>
        /// Value should refer to given country default (BBD)
        /// </value>
        [StringLength(50)]
        [Display(Name = "Country")]
        [JsonProperty("Country")]
        public string Country { get; set; }
        [StringLength(10)]
        /// <summary>
        /// Postal Code
        /// </summary>
        /// <value>
        /// Value should refer to given country postal code
        /// </value>
        [Display(Name = "Postal Code")]
        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }
        /// <summary>
        /// Company Phone Number
        /// </summary>
        /// <value>
        /// Value should refer to given company phone number
        /// </value>
        [Required]
        [StringLength(15)]
        [Display(Name = "Company Phone")]
        [JsonProperty("CompanyPhoneNumber")]
        public string CompanyPhoneNumber { get; set; }
        /// <summary>
        /// Company Fax Number
        /// </summary>
        /// <value>
        /// Value should refer to given company fax number
        /// Do people still use these things? :)
        /// </value>
        [StringLength(15)]
        [Display(Name = "Fax")]
        [JsonProperty("FaxNumber")]
        public string FaxNumber { get; set; }
        /// <summary>
        /// Company Email address
        /// </summary>
        /// <value>
        /// Value should refer to given email address
        /// </value>
        [Required]
        [StringLength(50)]
        [Display(Name = "Business Email")]
        [JsonProperty("CompanyEmail")]
        [JsonRequired]
        public string CompanyEmail { get; set; }
        /// <summary>
        /// Company Status
        /// </summary>
        /// <value>
        /// Value should refer to the status of the company
        /// This should be pipe delimited to allow range of states
        /// </value>
        [MaxLength]
        [Display(Name = "Company Status")]
        public string Status { get; set; }

        #region Full Properties

        private string companyaddress;
        [NotMapped]
        public Contact  Contact { get; set; }
        [NotMapped]
        public string CompanyAddress
        {
            get { return companyaddress; }
            set { companyaddress = value; }
        }
        private string recenteredby;
        [NotMapped]
        public string RecEnteredBy
        {
            get { return recenteredby; }
            set { recenteredby = value; }
        }
        private DateTime recentereDateTime;
        [NotMapped]
        public DateTime RecEntered
        {
            get { return recentereDateTime; }
            set { recentereDateTime = value; }
        }
        private string remodifiedby;
        [NotMapped]
        public string RecModifiedBy
        {
            get { return remodifiedby; }
            set { remodifiedby = value; }
        }
        private DateTime recmodifiedDateTime;
        [NotMapped]
        public DateTime RecModified
        {
            get { return recmodifiedDateTime; }
            set { recmodifiedDateTime = value; }
        }

        #endregion

        #endregion

        #region Relationship

        public ICollection<Contact> Contacts { get; set; }
        //public ICollection<BankAccount> Banking { get; set; } 
        //public ICollection<PolicePayment> PolicePayments { get; set; }
        //public ICollection<EquipmentPayment> EquipmentPayments { get; set; }

        #endregion

        #region Methods

        public List<Company> GetListCompany()
        {
            throw new NotImplementedException();
        }

        public List<string> GetListCompanyName()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAsyncListCompanyName(string c)
        {
            var context = new PayohteeDbContext(options: new DbContextOptions<PayohteeDbContext>());
            List<string> list = (from a in context.DbContextCompany.Where(x => x.CompanyName.Contains(c))
                                 select a.CompanyName).ToList();
            return list;
        }

        public void DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }

        public void EditCompany(int id, Company company)
        {
            throw new NotImplementedException();
        }

        public void GetCompany(int? id)
        {
            throw new NotImplementedException();
        }

        public void CreateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public bool CompanyExists(int id)
        {
            throw new NotImplementedException();
        }

        public void EditCompany(int id)
        {
            throw new NotImplementedException();
        }

        //public void GetCompany(string companyname)
        //{
        //    var context = new PayohteeDbContext(options: new DbContextOptions<PayohteeDbContext>());
        //    List<string> list = (from a in context.DbContextCompany.Where(x => x.CompanyName.Contains(c))
        //                         select a.CompanyName).ToList();
        //    return list;
        //}

        Company ICRUDCompany.GetCompany(string companyname)
        {
            Company company = new Company();
            var context = new PayohteeDbContext(options: new DbContextOptions<PayohteeDbContext>());

            return null;
        }

        #endregion

    }


}
