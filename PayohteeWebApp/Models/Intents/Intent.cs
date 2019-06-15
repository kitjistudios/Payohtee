using Newtonsoft.Json;
using Payohtee.Models.Customer;
using Payohtee.Models.GeoTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayohteeWebApp.Models.Intents
{
    /// <summary>
    /// Company class to represent external customers who interact with officers and department/entity.
    /// </summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.
    /// </remarks>
    [Table("Intents")]
    [JsonObject("Intents")]
    public class Intent : IIntent
    {
        #region Constructor

        #endregion

        #region Properties

        [Key]
        public int IntentId { get; set; }

        #region  When

        [Required]
        [JsonProperty("StartDate")]
        [JsonRequired]
        public DateTime StartDate { get; set; }
        [Required]
        [JsonProperty("EndDate")]
        [JsonRequired]
        public DateTime EndDate { get; set; }
        [Required]
        [JsonProperty("StartTime")]
        [JsonRequired]
        public TimeSpan StartTime { get; set; }
        [Required]
        [JsonProperty("EndTime")]
        [JsonRequired]
        public TimeSpan EndTime { get; set; }

        #endregion

        #region  Where

        /// <summary>
        /// Intent Latitude
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
        /// Intent Longitude
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
        /// Intent Latitude
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
        /// Intent Longitude
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
        /// List of coordinates
        /// </summary>
        /// <value>
        /// Value should be a list of located/pinged coordinates
        /// </value>
        [NotMapped]
        [JsonIgnore]
        public List<GeoLocate> CoordCollection { get; set; }

        #endregion

        #region What

        public string Description { get; set; }

        #endregion

        [JsonIgnore]
        public string Status { get; set; }

        #endregion

        #region Methods

        public void CreateIntent(Intent Intent)
        {
            throw new NotImplementedException();
        }

        public void CreateListIntent(List<Intent> IntentList)
        {
            throw new NotImplementedException();
        }

        public List<Intent> GetIntent(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Relationships

        public Company Company { get; set; }

        #endregion
    }
}
