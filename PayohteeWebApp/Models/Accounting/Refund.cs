using Payohtee.Models.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Payohtee.Models.Accounting
{
    [Table("Refund")]
    public class Refund
    {
        #region Constructor

        public Refund()
        {

        }
        #endregion

        #region Properties

        public int Tranid { get; set; }
        public decimal RefundAmount { get; set; }
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
