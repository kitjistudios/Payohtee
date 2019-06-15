using Newtonsoft.Json;
using PayohteeWebApp.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayohteeWebApi.Models.Notification
{
    public class Email
    {

        #region Construction

        public Email()
        {

        }

        #endregion

        #region Properties

        public string ResponseStatus { get; set; }
        public string Status { get; set; }
        public string StatusDescription { get; set; }
        public string Address { get; set; }
        public string Did_You_Mean { get; set; }
        public string Display_Name { get; set; }
        public string Domain { get; set; }
        public List<string> Emails { get; set; }
        public string Json { get; set; }
        public bool Is_Disposable_Address { get; set; }
        public bool Is_Role_Address { get; set; }
        public bool Is_Valid { get; set; }
        public string Local_Part { get; set; }
        public string Mailbox_Verification { get; set; }
        [JsonProperty]
        public object Parts { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string Reason { get; set; }
        public int AttemptNo { get; set; }
        public bool CertifiedVerified { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public string Event { get; set; }
        public string ID { get; set; }
        public bool Is_Accepted { get; set; }
        public bool Is_Routed { get; set; }
        public bool Is_Authenticated { get; set; }
        public bool Is_System_Test { get; set; }
        public bool Is_Test_Mode { get; set; }
        [JsonProperty("Items")]
        public List<Items> Items { get; set; }
        public string Recipient { get; set; }
        public string RecipientDomain { get; set; }
        //public string Response { get; set; }
        public string LogLevel { get; set; }
        [JsonProperty("Envelope")]
        public string Message { get; set; }
        public string MxHost { get; set; }
        public string Sender { get; set; }
        public string SendingIp { get; set; }
        public int SessionSeconds { get; set; }
        public string Targets { get; set; }
        public int TimeStamp { get; set; }
        public bool TLS { get; set; }
        public string Transport { get; set; }
        public bool UTF8 { get; set; }

        #endregion
    }
}
