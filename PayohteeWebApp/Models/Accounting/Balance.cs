using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Payohtee.Models.Customer;

namespace Payohtee.Models.Accounting
{
    [Table("Balance")]
    public class Balance
    {
        #region Constructor

        public Balance()
        {
            
        }
        #endregion

        #region Properties
        [Key]
        public int  Tranid { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }
        public decimal LastDeposit { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal CompanyBalance { get; set; }
        [MaxLength]
        public string Comments { get; set; }

        #region Full Properties

        private string recenteredby;
        [NotMapped]
        public string RecEnteredBy
        {
            get { return recenteredby; }
            set { recenteredby = value; }
        }
        private DateTime recentereDateTime;
        [NotMapped]
        public DateTime RecEntered
        {
            get { return recentereDateTime; }
            set { recentereDateTime = value; }
        }
        private string remodifiedby;
        [NotMapped]
        public string RecModifiedBy
        {
            get { return remodifiedby; }
            set { remodifiedby = value; }
        }
        private DateTime recmodifiedDateTime;
        [NotMapped]
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
