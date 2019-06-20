using Newtonsoft.Json;
using Payohtee.Models.Settings.Rates.Customs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayohteeWebApp.Models.Settings.Roles.Customs
{
    [Table("CustomsRole")]
    [JsonObject("CustomsRole")]
    public class CustomsRoles : PayRoles
    {
        #region Constructor

        public CustomsRoles()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Rate Code
        /// </summary>
        /// <value>
        /// Value should refer to given organisation Rate Code assignment 
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("ShortName")]
        public string ShortName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public List<CustomsRoles> RolesList { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<String> CustomsRolesList { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<String> CustomsRateList { get; set; }
        [NotMapped]
  
        public List<CustomsRates> RateList { get; set; }
        #endregion

        #region Relationships

        public CustomsRates CustomsRates { get; set; }

        #endregion

        #region Methods

        public List<String> GetListCustomsRoles()
        {
            var roles = new List<String>();
            roles.Add("Comptroller Customs");
            roles.Add("Guard");
            roles.Add("Customs Officer");
            CustomsRolesList = roles;
            return CustomsRolesList;
        }


        #endregion
    }
}
