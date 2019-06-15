using Newtonsoft.Json;
using Payohtee.Models.Customer;
using Payohtee.Models.Personnel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Payohtee.Models.Banking
{
    /// <summary>
    /// Company class to represent external customers who interact with officers and department/entity.
    /// </summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.
    /// </remarks>
    [Table("BankAccounts")]
    [JsonObject("BankAccounts")]
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
        [JsonProperty]
        public string AccountNumber { get; set; }

        #endregion

        #region Relationships

        public Employee Employee { get; set; }
        public Company  Company { get; set; }
        #endregion
    }
}
