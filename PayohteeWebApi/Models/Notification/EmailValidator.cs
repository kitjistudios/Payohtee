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
    public class EmailValidator
    {
        #region Constructor

   public EmailValidator()
        {

        }

        #endregion

        #region Grabble Email Validation Properties


        #endregion

        #region Methods
        public string PluckEmails(List<string> emails)
        {
            if (emails.Count == 0)
            {
                return "no emails";
            }
            else
            {
                foreach (var item in emails)
                {
                    //return Email = item;
                }
            }
            return null;
        }

        public IRestResponse GetValidate()
        {
            RestClient client = new RestClient
            {
                BaseUrl = new Uri("https://api.mailgun.net/v3"),
                Authenticator =
                new HttpBasicAuthenticator("api",
                                           Resources.MGPublicValidation)
            };
            RestRequest request = new RestRequest
            {
                Resource = "/address/validate",
                Method = Method.GET
            };
            request.AddParameter("address", "smarshall@kitjistudios.com");
            request.AddHeader("header", "value");
            IRestResponse IRresponse = client.Execute(request);
            var response = IRresponse.Content;
            //CheckEmailValidity(response);
            return IRresponse;
        }

        public IRestResponse GetValidate(string email)
        {
            RestClient client = new RestClient
            {
                BaseUrl = new Uri("https://api.mailgun.net/v3"),
                Authenticator =
                new HttpBasicAuthenticator("api",
                                           Resources.MGPublicValidation)
            };
            RestRequest request = new RestRequest
            {
                Resource = "/address/validate",
                Method = Method.GET
            };
            request.AddParameter("address", email);
            request.AddHeader("header", "value");
            IRestResponse IRresponse = client.Execute(request);
            var response = IRresponse.Content;
            //CheckEmailValidity(response);
            return IRresponse;
        }

        public IRestResponse GetValidate(List<string> email)
        {
            RestClient client = new RestClient
            {
                BaseUrl = new Uri("https://api.mailgun.net/v3"),
                Authenticator =
                new HttpBasicAuthenticator("api",
                                           Resources.MGPublicValidation)
            };
            RestRequest request = new RestRequest
            {
                Resource = "/address/validate",
                Method = Method.GET
            };
            request.AddParameter("address", email);
            request.AddHeader("header", "value");
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            return response;
        }

        public IRestResponse GetParse(List<string> address)
        {
            RestClient client = new RestClient();
            string addresses = string.Empty;
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                                            Resources.MGPublicValidation);
            RestRequest request = new RestRequest
            {
                Resource = "/address/parse",
                Method = Method.GET
            };
            foreach (var item in address)
            {
                addresses = address + item + ",";
            }
            request.AddParameter("addresses",
                                 addresses);
            return client.Execute(request);
        }

        public IRestResponse GetParse()
        {
            RestClient client = new RestClient
            {
                BaseUrl = new Uri("https://api.mailgun.net/v3"),
                Authenticator =
                new HttpBasicAuthenticator("api",
                                            Resources.MGPublicValidation)
            };
            RestRequest request = new RestRequest
            {
                Resource = "/address/parse",
                Method = Method.GET
            };
            request.AddParameter("addresses",
                                  "Guzman <john_shayne@hotmail.com>,smarshall@kitjistudios.com");
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return response;
        }

        //public bool CheckEmailValidity(string response)
        //{
        //    var alltokens = JsonConvert.DeserializeObject<EmailValidator>(response);
        //    Address = alltokens.Address;
        //    Did_You_Mean = alltokens.Did_You_Mean;
        //    Is_Disposable_Address = alltokens.Is_Disposable_Address;
        //    Is_Role_Address = alltokens.Is_Role_Address;
        //    Is_Valid = alltokens.Is_Valid;
        //    Mailbox_Verification = alltokens.Mailbox_Verification;
        //    Reason = alltokens.Reason;
        //    var morejson = alltokens.Parts.ToString();
        //    var parttokens = JsonConvert.DeserializeObject<EmailValidator>(morejson);
        //    Local_Part = parttokens.Local_Part;
        //    Domain = parttokens.Domain;
        //    Display_Name = parttokens.Display_Name;
        //    return Is_Valid = alltokens.Is_Valid;
        //}

        #endregion

        #region MailGun Email Validity JSON response schema
        //      {
        //  "address": "foo@mailgun.net",
        //  "did_you_mean": null,
        //  "is_disposable_address": false,
        //  "is_role_address": false,
        //  "is_valid": true,
        //  "mailbox_verification": null,
        //  "parts": {
        //      "display_name": null,
        //      "domain": "mailgun.net",
        //      "local_part": "foo"
        //  },
        //  "reason": null
        //}
        #endregion

    }
}
