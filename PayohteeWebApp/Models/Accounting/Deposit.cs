using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Payohtee.Models.Customer;

namespace Payohtee.Models.Accounting
{
    [Table("Deposit")]
    public class Deposit
    {
        #region Constructor

        public Deposit()
        {
            
        }
        #endregion

        #region Properties

        public int Tranid { get; set; }
        public decimal DepositAmount { get; set; }
        public ICollection<Company> Companies { get; set; }
        public string CompanyName { get; set; }

        #region Full Properties

        private string recenteredby;
        public string RecEnteredBy
        {
            get { return recenteredby; }
            set { recenteredby = value; }
        }
        private DateTime recentereDateTime;
        public DateTime RecEntered
        {
            get { return recentereDateTime; }
            set { recentereDateTime = value; }
        }
        private string remodifiedby;
        public string RecModifiedBy
        {
            get { return remodifiedby; }
            set { remodifiedby = value; }
        }
        private DateTime recmodifiedDateTime;
        public DateTime RecModified
        {
            get { return recmodifiedDateTime; }
            set { recmodifiedDateTime = value; }
        }
        #endregion

        #endregion

        #region Methods



        #endregion
    }
}
