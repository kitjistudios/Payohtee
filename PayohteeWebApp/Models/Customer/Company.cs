using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Payohtee.Models.GeoTracking;
using PayohteeWebApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    [JsonObject("Company")]
    public class Company : ICRUDCompany
    {
        #region Variables

        #endregion

        #region Constructor

        public Company()
        {
            Contacts = new List<Contact>();
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
        [JsonIgnore]
        public string Status { get; set; }

        #region Full Properties

        private GeoLocate coord;
        [NotMapped]
        [JsonIgnore]
        public GeoLocate Coord
        {
            get { return coord; }
            set { coord = value; }
        }
        private string companyaddress;
        [NotMapped]
        [JsonIgnore]
        public string CompanyAddress
        {
            get { return companyaddress; }
            set { companyaddress = value; }
        }
        private string recenteredby;
        [NotMapped]
        [JsonIgnore]
        public string RecEnteredBy
        {
            get { return recenteredby; }
            set { recenteredby = value; }
        }
        private DateTime recentereDateTime;
        [NotMapped]
        [JsonIgnore]
        public DateTime RecEntered
        {
            get { return recentereDateTime; }
            set { recentereDateTime = value; }
        }
        private string remodifiedby;
        [NotMapped]
        [JsonIgnore]
        public string RecModifiedBy
        {
            get { return remodifiedby; }
            set { remodifiedby = value; }
        }
        private DateTime recmodifiedDateTime;
        [NotMapped]
        [JsonIgnore]
        public DateTime RecModified
        {
            get { return recmodifiedDateTime; }
            set { recmodifiedDateTime = value; }
        }
        [NotMapped]
        [JsonIgnore]
        public Contact Contact { get; set; }

        #endregion

        #endregion

        #region Relationship

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<GeoLocate> Coordinates { get; set; }
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

        public async Task<List<string>> GetAsyncListCompanyName(string c)
        {
            var context = new PayohteeDbContext(options: new DbContextOptions<PayohteeDbContext>());
            List<string> list = (from a in context.DbContextCompany.Where(x => x.CompanyName.Contains(c) && x.Status == "Active")
                                 select a.CompanyName).ToList();
            return await Task.FromResult<List<string>>(list);
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

        Company ICRUDCompany.GetCompany(string companyname)
        {
            Company company = new Company();
            var context = new PayohteeDbContext(options: new DbContextOptions<PayohteeDbContext>());

            return null;
        }

        public String AddressBuilder()
        {
            var address = new StringBuilder();
            return address.Append(this.Address1).Append(this.Address2).ToString();
        }

        #endregion

        #region Snippets
        //fetch result json schema
        //    {
        //    "companyId": 125,
        //    "payohteeId": "12345",
        //    "CompanyName": "Kitjimanitou Studios",
        //    "CompanyAlias": "Kitji Studios",
        //    "CompanyTaxId": "00000",
        //    "CompanyIndustry": "IT",
        //    "Address1": "Breedys Land",
        //    "Address2": "",
        //    "Address3": "Silver Sands",
        //    "Address4": "Silver Sands",
        //    "Parish": "Christ Church",
        //    "Country": "Barbados",
        //    "PostalCode": "",
        //    "CompanyPhoneNumber": "246-254-5106",
        //    "FaxNumber": "",
        //    "CompanyEmail": "smarshall@kitjistudios.com",
        //    "contacts": []
        //}


        //register json schema
        //        {"CompanyId":0,
        //        "PayohteeId":"256",
        //        "CompanyName":"Disney Corp LLC",
        //        "CompanyAlias":"Disney",
        //        "CompanyTaxId":"000",
        //        "CompanyIndustry":"Entertainment",
        //        "Address1":"Mickey",
        //        "Address2":"Apt 234",
        //        "Address3":"Donald",
        //        "Address4":"Uncle Scrooge",
        //        "Parish":"St.Lucy",
        //        "Country":"Barbados",
        //        "PostalCode":"BB23554",
        //        "CompanyPhoneNumber":"246 965-8547",
        //        "FaxNumber":"",
        //        "CompanyEmail":"support@disney.com",
        //    "Contacts":[
        //      {"ContactId":0,
        //              "ContactName":"Donald",
        //              "ContactMobile":"245 854-8745",
        //              "ContactEmail":"dduck@gmail.com",
        //              "ContactTitle":"Mascot",
        //              "SocialMedia":null,
        //              "Company":null},
        //      {"ContactId":0,
        //              "ContactName":"Goofy",
        //              "ContactMobile":"256 854-8745",
        //              "ContactEmail":"goofy@gmail.com",
        //              "ContactTitle":"Icon",
        //              "SocialMedia":null,"Company":null}],
        //    "Coordinates":[{"GPSId":0,
        //              "Latitude":"13.060505599999999",
        //              "Longitude":"-59.506688",
        //              "Lat":13.060505599999999,
        //              "Lon":-59.506688,
        //              "Company":null}]}

        #endregion
    }
}

