using Newtonsoft.Json;
using Payohtee.Models.Asset;
using Payohtee.Models.Customer;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payohtee.Models.Accounting.Police
{
    /// <summary>
    /// Employee class to capture personal employee info. Employees interact with companies/customers
    /// </summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.
    /// </remarks>
    [Table("PolicePayments")]
    public class PolicePayment : Payment
    {
        #region Constructor

        public PolicePayment()
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
        public string TranType { get; set; }

        /// <summary>
        /// Police Number
        /// </summary>
        /// <value>
        /// Value should refer to given for police officer number
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("PoliceNumber")]
        public string PoliceNumber { get; set; }

        /// <summary>
        /// Employee Number
        /// </summary>
        /// <value>
        /// Value should refer to given for employee number
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("EmployeeNumber")]
        public string EmployeeNumber { get; set; }

        /// <summary>
        /// Employee Name
        /// </summary>
        /// <value>
        /// Value should refer to given for employee name
        /// </value>
        [StringLength(10)]
        [JsonProperty("EmployeeName")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Company Name
        /// </summary>
        /// <value>
        /// Value should refer to company name the employee worked for
        /// </value>
        [StringLength(50)]
        [JsonProperty("CompanyName")]
        [JsonRequired]
        public string CompanyName { get; set; }

        /// <summary>
        /// Current Balance
        /// </summary>
        /// <value>
        /// Value should refer to last allocated company balance
        /// </value>
        [Column(TypeName = "decimal(10,2)")]
        [JsonProperty("EmployeeName")]
        public decimal CurrentBalance { get; set; }

        /// <summary>
        /// Overtime Amount
        /// </summary>
        /// <value>
        /// Value should refer to the paid amount of overtime without allowances(Pay rate * Hours Worked)
        /// </value>
        [Column(TypeName = "decimal(10,2)")]
        [JsonProperty("OvertimeAmount")]
        public decimal OvertimeAmount { get; set; }

        /// <summary>
        /// Total Amount
        /// </summary>
        /// <value>
        /// Value should refer to the total paid amount (Overtime + All allowances)
        /// </value>
        [Column(TypeName = "decimal(10,2)")]
        [JsonProperty("TotalAmount")]
        public decimal TotalAmount { get; set; }

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

        #endregion

        #region Relationships

        public Company Company { get; set; }
        //public Event Event { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}
