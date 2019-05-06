using Payohtee.Models.Asset;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payohtee.Models.Inventory.Police.Service
{
    [Table("Service")]
    public class Service : InventoryItem
    {
        #region Constructor

        public Service()
        {

        }
        #endregion

        #region Properties

        public int ServiceId { get; set; }  
        [Required]
        [StringLength(50)]
        [Display(Name = "Category")]
        public string Category { get; set; }
        [MaxLength]
        [Display(Name = "Service Description")]
        public string Description { get; set; }
        [StringLength(50)]
        [Display(Name = "Department")]
        public string Department { get; set; }


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

        #region Relationships

    

        #endregion

        #region Methods



        #endregion
    }
}
