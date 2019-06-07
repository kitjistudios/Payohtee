using Newtonsoft.Json;
using Payohtee.Models.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payohtee.Models.GeoTracking
{
    [Table("GPSCoordinates")]
    [JsonObject("GPSCoordinates")]
    public class GeoLocate
    {
        #region Variables

        #endregion

        #region Constructor

        public GeoLocate()
        {
            CoordCollection = new List<GeoLocate>();
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
        /// Company Latitude
        /// </summary>
        /// <value>
        /// Value should be string Latitude: 13.091216874999997
        /// </value>
        [Required]
        [StringLength(100)]
        [DisplayName("Latitude")]
        [JsonProperty("Latitude")]
        [JsonRequired]
        public string Latitude { get; set; }

        /// <summary>
        /// Company Longitude
        /// </summary>
        /// <value>
        /// Value should be string Longitude: 69.091216874999997
        /// </value>
        [Required]
        [StringLength(100)]
        [DisplayName("Longitude")]
        [JsonProperty("Longitude")]
        [JsonRequired]
        public string Longitude { get; set; }

        /// <summary>
        /// Company Latitude
        /// </summary>
        /// <value>
        /// Value should be a decimal Latitude value
        /// </value>
        //[Range(10, 8)]
        [Column(TypeName = "decimal(10,8)")]
        [DisplayName("Lat")]
        [JsonProperty("Lat")]
        [JsonRequired]
        public decimal Lat { get; set; }

        /// <summary>
        /// Company Longitude
        /// </summary>
        /// <value>
        /// Value should be a decimal Longitude value
        /// </value>
        //[Range(11, 8)]
        [Column(TypeName = "decimal(11,8)")]
        [DisplayName("Lon")]
        [JsonProperty("Lon")]
        [JsonRequired]
        public decimal Lon { get; set; }

        /// <summary>
        /// Company Coord time stamp
        /// </summary>
        /// <value>
        /// Time component 
        /// </value>
        [NotMapped]
        [JsonIgnore]
        public DateTime Time { get; set; }

        /// <summary>
        /// List of coordinates
        /// </summary>
        /// <value>
        /// Value should be a list of located/pinged coordinates
        /// </value>
        [NotMapped]
        [JsonIgnore]
        public List<GeoLocate> CoordCollection { get; set; }

        #endregion

        #region Relationships

        public Company Company { get; set; }

        #endregion

        #region Methods


        #endregion

    }
}
