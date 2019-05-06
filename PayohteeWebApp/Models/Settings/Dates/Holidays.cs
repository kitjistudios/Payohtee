using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Payohtee.Models.Settings.Dates
{
    [Table("Holidays")]
    public class Holidays
    {
        #region Constructor

        #endregion

        #region Properties

        public int HolidayId { get; set; }
        [Required]
        [StringLength(10)]
        public string HolidayCode { get; set; }
        [StringLength(50)]
        public string HolidayName { get; set; }
        public DateTime HolidayDate { get; set; }
        public DateTime DateModified { get; set; }
        [StringLength(50)]
        public string ModifiedBy { get; set; }


        #endregion

        #region Methods



        #endregion
    }
}
