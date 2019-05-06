using Microsoft.EntityFrameworkCore;
using Payohtee.Data;
using PayohteeWebApp.Data;
using System.Collections.Generic;

namespace Payohtee.Models.Settings.Rates.Customs
{
    public class CustomsRates : PayRate
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
        public List<PayRate> ListCustomsPayRate { get; set; }

        #endregion

        #region Methods
        public List<PayRate> GetListOfPayRates()
        {
      
            return this.ListCustomsPayRate;
        }

        #endregion

    }
}
