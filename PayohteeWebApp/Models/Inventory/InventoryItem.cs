using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payohtee.Models.Inventory
{
    [NotMapped]
    public class InventoryItem
    {
        #region Constructor

        public InventoryItem()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("ItemType")]
        [JsonRequired]
        public string ItemType { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [Required]
        [StringLength(10)]
        [JsonProperty("ItemName")]
        [JsonRequired]
        public string ItemName { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [Column(TypeName = "decimal(10,2)")]
        [JsonProperty("ItemUnitCost")]
        public decimal ItemUnitCost { get; set; }

        /// <summary>
        /// Transaction Number
        /// </summary>
        /// <value>
        /// Value should refer to given Transaction Number
        /// </value>
        [Column(TypeName = "decimal(10,2)")]
        [JsonProperty("UnitMeasurement")]
        public decimal UnitMeasurement { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}
