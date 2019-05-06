using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payohtee.Models.Settings.Rates
{
    [NotMapped]
    public class PayRate
    {
        #region Constructor
        public PayRate()
        {


        }
        #endregion

        #region Properties

        /// <summary>
        /// System Generated Rate Id
        /// </summary>
        /// <value>
        /// Value should refer to given Rate Id
        /// </value>
        [Key]
        public int RateId { get; set; }

        /// <summary>
        /// Rate Code
        /// </summary>
        /// <value>
        /// Value should refer to given organisation Rate Code assignment 
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("RateCode")]
        public string RateCode { get; set; }

        /// <summary>
        /// Rate Group
        /// </summary>
        /// <value>
        /// Value should refer to given distinguishing Rate Group  
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("RateGroup")]
        public string RateGroup { get; set; }

        /// <summary>
        /// Rate Amount
        /// </summary>
        /// <value>
        /// Value should refer to given numeric rate amout
        /// </value>
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Rate Amount")]
        [JsonProperty("RateAmount")]
        public decimal RateAmount { get; set; }

        public DateTime DateModified { get; set; }
        [StringLength(50)]
        public string ModifiedBy { get; set; }


        #endregion

        #region Methods



        #endregion

    }
}
