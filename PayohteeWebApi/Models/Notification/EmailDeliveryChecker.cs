using Newtonsoft.Json;
using PayohteeWebApi.Properties;
using PayohteeWebApp.Properties;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayohteeWebApp.Models.Notification
{
    public class EmailDeliveryChecker
    {
        #region Constructor

        public EmailDeliveryChecker()
        {

        }
        #endregion


        #region Properties

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
        public string Response { get; set; }
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

        #region Methods
        public IRestResponse EventsDateTimeRecipient(string email, string datetime)
        {
            RestClient client = new RestClient
            {
                BaseUrl = new Uri("https://api.mailgun.net/v3"),
                Authenticator =
                new HttpBasicAuthenticator("api",
                                            Resources.MGAPIKey)
            };
            RestRequest request = new RestRequest();
            request.AddParameter("domain", Resources.MGDomainName, ParameterType.UrlSegment);
            request.Resource = "{domain}/events";
            //'Thu, 13 Oct 2011 18:02:00 GMT'
            request.AddParameter("begin", datetime);
            request.AddParameter("recipient", email);
            request.AddParameter("ascending", "yes");
            request.AddParameter("limit", 2);
            request.AddParameter("pretty", "yes");

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return response;
        }

        public bool CheckIsDelivered(string response)
        {
            var tokens = JsonConvert.DeserializeObject<EmailDeliveryChecker>(response);
            var delivered = false;
            foreach (var item in tokens.Items)
            {
                if (item.Event == "accepted")
                {
                    Is_Accepted = true;
                }
                else
               if (item.Event == "delivered")
                {
                    delivered = true;
                    Event = item.Event;
                }
                else
                if (item.Event == "failed")
                {
                    delivered = false;
                    Event = item.Event;
                }
                else
                if (item.Event == "rejected")
                {
                    delivered = false;
                    Event = item.Event;
                }
            }


            return delivered;
        }
        #endregion

        #region MailGun Sent Email Checker JSON Schema
        //        {
        //  "event": "delivered",
        //  "id": "hK7mQVt1QtqRiOfQXta4sw",
        //  "timestamp": 1529692199.626182,
        //  "log-level": "info",
        //  "envelope": {
        //    "transport": "smtp",
        //    "sender": "sender@example.org",
        //    "sending-ip": "123.123.123.123",
        //    "targets": "john@example.com"
        //  },
        //  "flags": {
        //    "is-routed": false,
        //    "is-authenticated": false,
        //    "is-system-test": false,
        //    "is-test-mode": false
        //  },
        //  "delivery-status": {
        //    "tls": true,
        //    "mx-host": "aspmx.l.example.com",
        //    "code": 250,
        //    "description": "",
        //    "session-seconds": 0.4367079734802246,
        //    "utf8": true,
        //    "attempt-no": 1,
        //    "message": "OK",
        //    "certificate-verified": true
        //  },
        //  "message": {
        //    "headers": {
        //      "to": "team@example.org",
        //      "message-id": "20180622182958.1.48906CB188F1A454@exmple.org",
        //      "from": "sender@exmple.org",
        //      "subject": "Test Subject"
        //    },
        //    "attachments": [],
        //    "size": 586
        //  },
        //  "storage": {
        //    "url": "https://se.api.mailgun.net/v3/domains/example.org/messages/eyJwI...",
        //    "key": "eyJwI..."
        //  },
        //  "recipient": "john@example.com",
        //  "recipient-domain": "example.com",
        //  "campaigns": [],
        //  "tags": [],
        //  "user-variables": {}
        //}
        #endregion
    }

    public class Items
    {
        #region Constructor
        public Items()
        {

        }
        #endregion

        #region Properties
        public string Event { get; set; }
        public string Recipient_Domain { get; set; }
        public decimal TimeStamp { get; set; }
        //     {
        //  "tags": [],
        //  "envelope": {
        //    "sender": "mailgun@sandbox5ff8cad74309449185ef0dd885ce24df.mailgun.org",
        //    "transport": "smtp",
        //    "targets": "dawnoneal@outlook.com"
        //  },
        //  "storage": {
        //    "url": "https://se.api.mailgun.net/v3/domains/sandbox5ff8cad74309449185ef0dd885ce24df.mailgun.org/messages/eyJwIjpmYWxzZSwiayI6ImQxYjM3NWMyLWFkMjQtNGI1Yi1iODhlLTYzZmZmNDM4Nzk4OSIsInMiOiI1NWFjNTJiZjQ3IiwiYyI6InRhbmtiIn0=",
        //    "key": "eyJwIjpmYWxzZSwiayI6ImQxYjM3NWMyLWFkMjQtNGI1Yi1iODhlLTYzZmZmNDM4Nzk4OSIsInMiOiI1NWFjNTJiZjQ3IiwiYyI6InRhbmtiIn0="
        //  },
        //  "log-level": "info",
        //  "id": "J4JRxSanSUuZl5nP486i4g",
        //  "campaigns": [],
        //  "method": "http",
        //  "user-variables": {},
        //  "flags": {
        //    "is-routed": false,
        //    "is-authenticated": true,
        //    "is-system-test": false,
        //    "is-test-mode": false
        //  },
        //  "recipient-domain": "outlook.com",
        //  "timestamp": 1538944651.172436,
        //  "message": {
        //    "headers": {
        //      "to": "dawnoneal@outlook.com",
        //      "message-id": "20181007203731.1.C892FCD4B2659BD3@sandbox5ff8cad74309449185ef0dd885ce24df.mailgun.org",
        //      "from": "Excited User <mailgun@sandbox5ff8cad74309449185ef0dd885ce24df.mailgun.org>",
        //      "subject": "We value your patronage"
        //    },
        //    "attachments": [],
        //    "size": 552
        //  },
        //  "recipient": "dawnoneal@outlook.com",
        //  "event": "accepted"
        //}

        #endregion


    }
}
