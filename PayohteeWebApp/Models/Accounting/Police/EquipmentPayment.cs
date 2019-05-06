using Newtonsoft.Json;
using Payohtee.Models.Customer;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payohtee.Models.Accounting.Police
{
    public class EquipmentPayment

    {
        #region Constructor

        public EquipmentPayment()
        {

        }

        #endregion

        #region Properties
        /// <summary>
        /// Transaction Id
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [Key]
        public int TranId { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("TransactionNumber")]
        [JsonRequired]
        public string TransactionNumber { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("ItemName")]
        [JsonRequired]
        public string ItemName { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [Column(TypeName = "decimal(10,2)")]
        [JsonProperty("ItemUnitCost")]
        public decimal ItemUnitCost { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [JsonProperty("ItemAmount")]
        public int ItemAmount { get; set; }

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
