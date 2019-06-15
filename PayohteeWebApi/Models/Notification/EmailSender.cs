using PayohteeWebApi.Properties;
using PayohteeWebApp.Properties;
using RestSharp;
using RestSharp.Authenticators;
using System;

namespace PayohteeWebApp.Models.Notification
{
    public class EmailSender
    {
        #region Constructor

        public EmailSender()
        {

        }

        #endregion

        #region Properties

        #endregion

        #region Methods


        //Sending a plain text message
        public IRestResponse SendSimpleMessage(string email)
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
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@sandbox5ff8cad74309449185ef0dd885ce24df.mailgun.org>");
            //request.AddParameter("to", "bar@example.com");
            request.AddParameter("to", email);
            request.AddParameter("subject", "We value your patronage");
            request.AddParameter("text", "Thank you for using Payohtee");
            request.Method = Method.POST;
            return client.Execute(request);
        }

        public IRestResponse SendSimpleMessage(string email, string activationcode)
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
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@sandbox5ff8cad74309449185ef0dd885ce24df.mailgun.org>");
            //request.AddParameter("to", "bar@example.com");
            request.AddParameter("to", email);
            request.AddParameter("subject", "Grabble values your patronage");
            request.AddParameter("text", "Thank you for using Grabble:\n" + "Please use the link below and activation code to accept Grabble handshake\n" + activationcode);
            request.Method = Method.POST;
            return client.Execute(request);
        }

        public IRestResponse SendGrabbleAuthCode(string email)
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
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@sandbox5ff8cad74309449185ef0dd885ce24df.mailgun.org>");
            request.AddParameter("to", email);
            request.AddParameter("subject", "Grabble Authentication Code");
            //request.AddParameter("text", "Here is your Grabbler Activation Code: " + new Dispatcher().GrabbleGuid);
            request.Method = Method.POST;
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            //return response;
            return client.Execute(request);

            //Also simultaneously save auth code to database
        }
 

        #endregion



    }
}
