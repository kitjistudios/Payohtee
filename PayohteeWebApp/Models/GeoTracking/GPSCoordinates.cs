using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payohtee.Models.GeoTracking
{
    [Table("GPSCoordinates")]
    [JsonObject("GPSCoordinates")]
    public class GPSCoordinates
    {
        #region Variables

        #endregion

        #region Constructor

        public GPSCoordinates()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Company Identification
        /// </summary>
        /// <value>
        /// Value should be a system generate unique id
        /// </value>
        [Key]
        public int GPSId { get; set; }

        /// <summary>
        /// Company Identification
        /// </summary>
        /// <value>
        /// Value should be Latitude: 13.091216874999997
        /// </value>
        [Required]
        [StringLength(100)]
        [DisplayName("Latitude")]
        [JsonProperty("Latitude")]
        [JsonRequired]
        [NotMapped]
        public string Latitude { get; set; }

        /// <summary>
        /// Company Identification
        /// </summary>
        /// <value>
        /// Value should be a system generate unique id
        /// </value>
        [Required]
        [StringLength(100)]
        [DisplayName("Longitude")]
        [JsonProperty("Longitude")]
        [JsonRequired]
        [NotMapped]
        public string Longitude { get; set; }

        /// <summary>
        /// Company Identification
        /// </summary>
        /// <value>
        /// Value should be a system generate unique id
        /// </value>
        public DateTime Time { get; set; }

        #endregion

        #region Methods


        #endregion

    }
}
