using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payohtee.Models.Asset
{
    [Table("Event")]
    public class Event
    {
        #region Constructor

        public Event()
        {
            
        }
        #endregion

        #region Properties

        public int EventId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [StringLength(50)]
        [Display(Name = "Event Company / Owner")]
        public string EventOwner { get; set; }
        [StringLength(50)]
        [Display(Name = "Contact")]
        public string Contact { get; set; }
        [Display(Name = "Contact Mobile")]
        [Phone]
        public string ContactMobile { get; set; }
        [Required]
        [Display(Name="Event Date")]
        public DateTime EventDate { get; set; }
        #endregion

        #region Relationships
        //public ICollection<PolicePayment> PolicePayments { get; set; }
        //public ICollection<EquipmentPayment> EquipmentPayments { get; set; }
        //public ICollection<EquipmentPayment> EquipmentPayments { get; set; }
        //public ICollection<ServicePayment> ServicePayments { get; set; }
        #endregion

        #region Methods



        #endregion
    }
}
