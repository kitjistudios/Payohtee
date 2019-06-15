using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Payohtee.Models.Accounting;
using Payohtee.Models.Banking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Payohtee.Models.Personnel
{
    /// <summary>
    /// Employee class to capture personal employee info. Employees interact with companies/customers
    /// </summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.
    /// </remarks>
    [NotMapped]
    [JsonObject(Description = "Employee Base Class", Id = "")]
    public class Employee
    {
        #region Constructor

        public Employee()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Employee unique Identification
        /// </summary>
        /// <value>
        /// System generated employee id
        /// </value>
        [Key]
        public int EmployeeId { get; set; }

        /// <summary>
        /// National Registration Number
        /// </summary>
        /// <value>
        /// Value should refer to given national registration number
        /// </value>
        [Required]
        [StringLength(10, ErrorMessage = "NRN must be 10 characters with no special characters")]
        [Display(Name = "National Registration #")]
        [JsonProperty("NationalRegNo")]
        [JsonRequired]
        [XmlElement(DataType = "string", ElementName = "NationalRegNo", Form = new System.Xml.Schema.XmlSchemaForm(), Namespace = "Payohtee.Models.Personnel")]
        public string NationalRegNo { get; set; }

        /// <summary>
        /// National Insurance Scheme Number
        /// </summary>
        /// <value>
        /// Value should refer to given NIS number
        /// </value>
        [Required]
        [StringLength(7, ErrorMessage = "NIS must be 6 characters")]
        [Display(Name = "National Insurance #")]
        [JsonProperty("NISNo")]
        [JsonRequired]
        public string NISNo { get; set; }

        /// <summary>
        /// Tax Identification Number
        /// </summary>
        /// <value>
        /// Value should refer to given tax identification number
        /// </value>
        [Required]
        [StringLength(20)]
        [Display(Name = "Tax Identification #")]
        [JsonProperty("TIN")]
        [JsonRequired]
        public string TIN { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        /// <value>
        /// Value should refer to given title or prefix of employee
        /// </value>
        [StringLength(50)]
        [Display(Name = "Title")]
        [JsonProperty("Title")]
        public string Title { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        /// <value>
        /// Value should refer to given first name of employee
        /// </value>
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        [JsonRequired]
        public string FirstName { get; set; }

        /// <summary>
        /// Middle Name
        /// </summary>
        /// <value>
        /// Value should refer to given middle name of employee
        /// </value>
        [StringLength(50)]
        [Display(Name = "Middle Name")]
        [JsonProperty("MiddleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        /// <value>
        /// Value should refer to given last name of employee
        /// </value>
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        [JsonProperty("LastName")]
        [JsonRequired]
        public string LastName { get; set; }

        /// <summary>
        /// Initial
        /// </summary>
        /// <value>
        /// Value should refer to given initials of employee
        /// </value>
        [StringLength(50)]
        [Display(Name = "Initial")]
        [JsonProperty("Initial")]
        public string Initial { get; set; }

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
        [JsonProperty("Apartment")]
        public string Address2 { get; set; }

        /// <summary>
        /// Address 3
        /// </summary>
        /// <value>
        /// Value should refer to county, village, district etc
        /// </value>
        [StringLength(50)]
        [Display(Name = "City")]
        [JsonProperty("City")]
        public string Address3 { get; set; }

        /// <summary>
        /// Address 4
        /// </summary>
        /// <value>
        /// Value should refer to toe, street etc
        /// </value>
        [StringLength(50)]
        [Display(Name = "District")]
        [JsonProperty("District")]
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

        /// <summary>
        /// Postal Code
        /// </summary>
        /// <value>
        /// Value should refer to given country postal code
        /// </value>
        [StringLength(10)]
        [Display(Name = "Postal Code")]
        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Phone Home
        /// </summary>
        /// <value>
        /// Value should refer to given Home Phone
        /// </value>
        [StringLength(15)]
        [Display(Name = "Home Phone")]
        [JsonProperty("HomePhone")]
        public string HomePhone { get; set; }

        /// <summary>
        /// Phone Mobile
        /// </summary>
        /// <value>
        /// Value should refer to given Mobile Phone
        /// </value>
        [Required]
        [StringLength(15)]
        [Display(Name = "Mobile Phone")]
        [JsonProperty("Mobile")]
        [JsonRequired]
        public string Mobile { get; set; }

        /// <summary>
        /// Phone Work
        /// </summary>
        /// <value>
        /// Value should refer to given Work Phone
        /// </value>
        [StringLength(15)]
        [Display(Name = "Work Phone")]
        [JsonProperty("WorkPhone")]
        public string WorkPhone { get; set; }

        /// <summary>
        /// Phone Work Extension
        /// </summary>
        /// <value>
        /// Value should refer to given Work Phone Extension
        /// </value>
        [StringLength(4)]
        [Display(Name = "Extension")]
        [JsonProperty("Extension")]
        public string Extension { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// <value>
        /// Value should refer to given email address
        /// This should reflect the system Identity User address
        /// </value>
        [Required]
        [EmailAddress]
        [StringLength(50)]
        [Display(Name = "Email")]
        [JsonProperty("Email")]
        [JsonRequired]
        public string EmployeeEmail { get; set; }

        /// <summary>
        /// Date of Birth
        /// </summary>
        /// <value>
        /// Value should refer to employee date of birth
        /// </value>
        [Display(Name = "Birth Date")]
        [JsonProperty("DateOfBirth")]
        [JsonRequired]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        /// <value>
        /// Value should refer to current age of employee
        /// </value>
        [JsonProperty("Age")]
        public int Age { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        /// <value>
        /// Value should refer to gender of employee
        /// </value>
        [StringLength(7)]
        [JsonProperty("Gender")]
        [JsonRequired]
        public string Gender { get; set; }

        /// <summary>
        /// Rate Code
        /// </summary>
        /// <value>
        /// Value should refer to given rate code assigned to the employee by management
        /// </value>
        [Required]
        [StringLength(8)]
        [Display(Name = "Rate Code")]
        [JsonProperty("RateCode")]
        [JsonRequired]
        public string RateCode { get; set; }

        /// <summary>
        /// Pay Rate
        /// </summary>
        /// <value>
        /// Value should refer to given for overtime payment rate
        /// </value>
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Pay Rate")]
        [JsonProperty("PayRate")]
        [JsonRequired]
        public decimal PayRate { get; set; }

        /// <summary>
        /// Post Name
        /// </summary>
        /// <value>
        /// Value should refer to given post of the employee
        /// </value>
        [StringLength(50)]
        [Display(Name = "Post Name")]
        [JsonProperty("PostName")]
        [JsonRequired]
        public string PostName { get; set; }

        /// <summary>
        /// Salary Scale
        /// </summary>
        /// <value>
        /// Value should refer to given salary scale of employee
        /// </value>
        [StringLength(50)]
        [Display(Name = "Salary Scale")]
        [JsonProperty("SalaryScale")]
        public string SalaryScale { get; set; }

        /// <summary>
        /// Special Notes
        /// </summary>
        /// <value>
        /// Value should refer to any special free form text information on employee
        /// Can also be used for memo info
        /// </value>
        [MaxLength]
        [Display(Name = "Comments and Special Notes")]
        [JsonProperty("SpecialNotes")]
        public string SpecialNotes { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Value should refer to any special free form text information on employee
        /// Can also be used for memo info
        /// </value>
        [StringLength(10)]
        [Display(Name = "Employement Status")]
        [JsonProperty("Status")]
        public string Status { get; set; }

        #region Full Properties
        private string employeeaddress;
        [NotMapped]
        public string EmployeeAddress
        {
            get { return employeeaddress; }
            set { employeeaddress = value; }
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

        #region Relationship
        /// <summary>
        /// Payment
        /// </summary>
        /// <value>
        /// Given One to Many Relationship- One Employee to Many Payments
        /// </value>
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }

        #endregion

        #endregion

        #region Methods


        #endregion

    }
}
