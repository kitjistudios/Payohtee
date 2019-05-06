using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Payohtee.Models.Customer;

namespace Payohtee.Models
{
    /// <summary>
    /// Class level summary documentation goes here.
    /// </summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.
    /// </remarks>
    [Table("Contacts")]
    public class Contact 
    {
        #region Constructor
        public Contact()
        {

        }
        #endregion

        #region Properties

        public int ContactId { get; set; }
        /// <summary>
        /// Contact Name
        /// </summary>
        /// <value>
        /// Value should refer to given contact name
        /// </value>
        [Required]
        [MaxLength]
        [Display(Name = "Contact Name")]
        [JsonProperty("ContactName")]
        public string ContactName { get; set; }

        /// <summary>
        /// Contact mobile number
        /// </summary>
        /// <value>
        /// Value should refer to given email contact mobile number
        /// </value>
        [Phone]
        [Required]
        [Display(Name = "Contact Mobile")]
        [JsonProperty("ContactMobile")]
        public string ContactMobile { get; set; }

        /// <summary>
        /// Company Email address
        /// </summary>
        /// <value>
        /// Value should refer to given email address
        /// </value>
        [EmailAddress]
        [MaxLength]
        [Display(Name = "Contact Email")]
        [JsonProperty("ContactEmail")]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Contact Title
        /// </summary>
        /// <value>
        /// Value should refer to given contact job title
        /// </value>
        [MaxLength]
        [Display(Name = "Contact Title")]
        [JsonProperty("ContactTitle")]
        public string ContactTitle { get; set; }

        /// <summary>
        /// Contact Social Medial handles
        /// </summary>
        /// <value>
        /// Value should refer to given social media handles (Pipe Delimited)
        /// </value>
        [MaxLength]
        [Display(Name = "Social Media Tags")]
        [JsonProperty("SocialMedia")]
        public string SocialMedia { get; set; }

        [NotMapped]
        public List<string> SocialMediaHandles { get; set; }
        [NotMapped]
        public List<Contact> CompanyContacts { get; set; }

        #endregion

        #region Relationships
        public Company  Company { get; set; }
        #endregion

        #region Methods



        #endregion


    }
}
