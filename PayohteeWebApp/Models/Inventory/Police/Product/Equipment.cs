using Payohtee.Models.Accounting.Police;
using Payohtee.Models.Asset;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payohtee.Models.Inventory.Police.Product
{
    [Table("Equipment")]
    public class Equipment : InventoryItem
    {
        #region Constructor

        public Equipment()
        {

        }

        #endregion

        #region Properties

        public int EquipmentId { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [Required]
        [StringLength(50)]
        [Display(Name = "Category")]
        public string Category { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [StringLength(50)]
        [Display(Name = "Equipment Owner")]
        public string Owner { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [StringLength(50)]
        [Display(Name = "Department")]
        public string Department { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [StringLength(50)]
        public string Location { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [MaxLength]
        [Display(Name = "Equipment Comments or Description")]
        public string Description { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [Display(Name = "Equipment (End of Life)")]
        public DateTime EndLifeDate { get; set; }
        [NotMapped]
        public List<Equipment> Equipments { get; set; }

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

        public ICollection<EquipmentPayment> EquipmentPayments { get; set; }
        //public ICollection<Event> Events { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}
