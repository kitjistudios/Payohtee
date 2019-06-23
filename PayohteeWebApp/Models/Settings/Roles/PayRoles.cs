using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayohteeWebApp.Models.Settings
{
    [NotMapped]
    [JsonObject(Description = "Pay Role Base Class", Id = "")]
    public class PayRoles
    {
        #region Constructor

        public PayRoles()
        {

        }

        #endregion

        #region Properties

        [Key]
        public int RoleId { get; set; }

        /// <summary>
        /// Role Name
        /// </summary>
        /// <value>
        /// Value should refer to given organisation Role Name assignment 
        /// </value>
        [Required]
        [StringLength(50, ErrorMessage = "Role name is required")]
        [Display(Name = "Role Name")]
        [JsonProperty("PayRoleName")]
        [JsonRequired]
        public string PayRoleName { get; set; }

        #endregion


    }
}
