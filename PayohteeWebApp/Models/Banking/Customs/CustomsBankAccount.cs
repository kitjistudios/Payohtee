using Newtonsoft.Json;
using Payohtee.Models.Banking;
using Payohtee.Models.Personnel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayohteeWebApp.Models.Banking.Customs
{
    [Table("CustomsBankAccount")]
    [JsonObject("CustomsBankAccount")]
    public class CustomsBankAccount:BankAccount
    {
        #region Construction

        public CustomsBankAccount()
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
        public int CustomsOfficerAccountId { get; set; }

        #endregion

        #region Relationship

        public Employee Employee { get; set; }

        #endregion
    }
}
