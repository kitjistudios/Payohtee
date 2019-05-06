using Newtonsoft.Json;
using Payohtee.Models.Customer;
using Payohtee.Models.Personnel.Customs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace Payohtee.Models.Accounting.Customs
{
    /// <summary>
    /// Employee class to capture personal employee info. Employees interact with companies/customers
    /// </summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.
    /// </remarks>
    [Table("CustomsPayments")]
    public class CustomsPayment : Payment
    {
        #region Constructor

        public CustomsPayment()
        {

        }

        #endregion

        #region Properties


        /// <summary>
        /// Transaction Type
        /// </summary>
        /// <value>
        /// Value should refer to designated transaction type
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("TranType")]
        [JsonRequired]
        public string TranType { get; set; }

        /// <summary>
        /// Employee Number
        /// </summary>
        /// <value>
        /// Value should refer to given for employee number
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("TranType")]
        [JsonRequired] public string EmployeeNumber { get; set; }

        /// <summary>
        /// Employee Name
        /// </summary>
        /// <value>
        /// Value should refer to given for employee name
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("EmployeeName")]
        [JsonRequired]
        [XmlElement(DataType = "string", ElementName = "EmployeeName", Form = new System.Xml.Schema.XmlSchemaForm(), Namespace = "Payohtee.Models.Accounting.Customs")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Company Id
        /// </summary>
        /// <value>
        /// Value should refer to company id the employee worked for
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("CompanyId")]
        [JsonRequired]
        [XmlElement(DataType = "string", ElementName = "CompanyId", Form = new System.Xml.Schema.XmlSchemaForm(), Namespace = "Payohtee.Models.Accounting.Customs")]
        public string CompanyId { get; set; }

        /// <summary>
        /// Company Name
        /// </summary>
        /// <value>
        /// Value should refer to company name the employee worked for
        /// </value>
        [StringLength(50)]
        [JsonProperty("CompanyName")]
        [JsonRequired]
        [XmlElement(DataType = "string", ElementName = "CompanyName", Form = new System.Xml.Schema.XmlSchemaForm(), Namespace = "Payohtee.Models.Accounting.Customs")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Current Balance
        /// </summary>
        /// <value>
        /// Value should refer to last allocated company balance
        /// </value>
        [Column(TypeName = "decimal(18,2)")]
        [JsonProperty("CurrentBalance")]
        [JsonRequired]
        public decimal CurrentBalance { get; set; }

        /// <summary>
        /// Distance Travelled
        /// </summary>
        /// <value>
        /// Value should refer to the distance travelled from point A to company location
        /// </value>
        [Column(TypeName = "decimal(18,2)")]
        [JsonProperty("TravelDistance")]
        public decimal TravelDistance { get; set; }

        /// <summary>
        /// Travel Allowance
        /// </summary>
        /// <value>
        /// Value should refer to the travel allowance for a job
        /// </value>
        [Column(TypeName = "decimal(18,2)")]
        [JsonProperty("TravelAllowance")]
        public decimal TravelAllowance { get; set; }

        /// <summary>
        /// Has Subsistence
        /// </summary>
        /// <value>
        /// Value should refer to if the employee is receving subsistence or not
        /// </value>
        [JsonProperty("HasSubsistence")]
        public bool HasSubsistence { get; set; }

        /// <summary>
        /// Subsistence Allowance
        /// </summary>
        /// <value>
        /// Value should refer to the amount of paid subsistence allowance
        /// </value>
        [Column(TypeName = "decimal(18,2)")]
        [JsonProperty("SubsistenceAllowance")]
        public decimal SubsistenceAllowance { get; set; }

        /// <summary>
        /// Has Passencger
        /// </summary>
        /// <value>
        /// Value should refer to if the employee has a passenger or not
        /// </value>
        [JsonProperty("HasPassenger")]
        public bool HasPassenger { get; set; }

        /// <summary>
        /// Passenger Amount
        /// </summary>
        /// <value>
        /// Value should refer to the number of passengers traveling with employee
        /// </value>
        [JsonProperty("PassengerAmount")]
        public int PassengerAmount { get; set; }

        /// <summary>
        /// Passenger Allowance
        /// </summary>
        /// <value>
        /// Value should refer to the amount of paid passenger allowance
        /// </value>
        [Column(TypeName = "decimal(18,2)")]
        [JsonProperty("PassengerAllowance")]
        public decimal PassengerAllowance { get; set; }

        /// <summary>
        /// Overtime Amount
        /// </summary>
        /// <value>
        /// Value should refer to the paid amount of overtime without allowances(Pay rate * Hours Worked)
        /// </value>
        [Column(TypeName = "decimal(18,2)")]
        [JsonProperty("OvertimeAmount")]
        public decimal OvertimeAmount { get; set; }

        /// <summary>
        /// Total Amount
        /// </summary>
        /// <value>
        /// Value should refer to the total paid amount (Overtime + All allowances)
        /// </value>
        [Column(TypeName = "decimal(18,2)")]
        [JsonProperty("TotalAmount")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Comments
        /// </summary>
        /// <value>
        /// Value should refer to any commments made about the payment transaction
        /// </value>
        [JsonProperty("Comments")]
        public string Comments { get; set; }

        #region Full Properties
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
        /// Employees
        /// </summary>
        /// <value>
        /// One to many relationship of Employee to Payments
        /// </value>
        public ICollection<CustomsOfficer> CustomsOfficers { get; set; }

        #endregion

        #endregion

        #region Relationships

        public Company Company { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}
