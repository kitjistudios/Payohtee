using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PayohteeWebApp.Data;
using PayohteeWebApp.Models.Settings.Roles.Customs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payohtee.Models.Settings.Rates.Customs
{
    [Table("CustomsRates")]
    [JsonObject("CustomsRates")]
    public class CustomsRates : PayRates
    {
        #region Constructor
        public CustomsRates()
        {
            this.RateGroup = "CSTM";
        }
        #endregion

        #region Variables

        readonly PayohteeDbContext _context = new PayohteeDbContext(options: new DbContextOptions<PayohteeDbContext>());

        #endregion

        #region Properties

        /// <summary>
        /// Rate Code
        /// </summary>
        /// <value>
        /// Value should refer to given organisation Rate Code assignment 
        /// </value>
        [NotMapped]
        [JsonIgnore]
        public List<PayRates> ListCustomsPayRate { get; set; }

        public int RoleId { get; set; }
        [NotMapped]
        [ForeignKey("RoleId")]
        public  CustomsRoles CustomsRoles { get; set; }

        #endregion


        #region Methods
        public List<PayRates> GetListOfPayRates()
        {

            return this.ListCustomsPayRate;
        }

        #endregion

    }
}
