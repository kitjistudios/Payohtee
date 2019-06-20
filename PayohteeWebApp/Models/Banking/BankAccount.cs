using Newtonsoft.Json;
using Payohtee.Models.Customer;
using Payohtee.Models.Personnel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payohtee.Models.Banking
{
    /// <summary>
    /// Company class to represent external customers who interact with officers and department/entity.
    /// </summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.
    /// </remarks>
    [NotMapped]
    [JsonObject(Description = "Bank Account Base Class", Id = "")]
    public class BankAccount
    {
        #region Constructor

        public BankAccount()
        {

        }

        #endregion

        #region Properties

        [Key]
        public int AccountId { get; set; }

        /// <summary>
        /// Bank name 
        /// </summary>
        /// <value>
        /// Value should be name of bank
        /// </value>
        [Required(ErrorMessage = "Bank name is required")]
        [StringLength(50)]
        [Display(Name = "Bank Name")]
        [JsonProperty("BankName")]
        [JsonRequired]
        public string BankName { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        /// <value>
        /// Value should be a valid account number
        /// </value>
        [Required(ErrorMessage = "Account number is required")]
        [StringLength(50)]
        [Display(Name = "Account Number")]
        [JsonProperty("AccountNumber")]
        [JsonRequired]
        public string AccountNumber { get; set; }

        #endregion
    }
}
