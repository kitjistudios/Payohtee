using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayohteeWebApi.Properties;
using RestSharp;
using RestSharp.Authenticators;

namespace PayohteeWebApi.Controllers
{

    [ApiController]
    public class EmailController : ControllerBase
    {
        // GET: api/email/register
        [Route("api/email/[action]")]
        [ActionName("validate")]
        [HttpGet]
        public  ActionResult<String> GetValidate()
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
            var response =  IRresponse.Content;
            //CheckEmailValidity(response);
            return response;
        }

        // POST: api/email/simplemailit
        [Route("api/email/[action]")]
        [ActionName("simplemailit")]
        [HttpPost]
        public IRestResponse SendSimpleMessage()
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
            request.AddParameter("to", "smarshall@kitjistudios.com");
            request.AddParameter("subject", "We value your patronage");
            request.AddParameter("text", "Thank you for using Payohtee");
            request.Method = Method.POST;
            return client.Execute(request);
        }

        // POST: api/email/complexmailit
        [Route("api/email/[action]")]
        [ActionName("complexmailit")]
        [HttpPost]
        //Sending a message with HTML and text parts. This example also attaches two files to the message:
        public IRestResponse SendComplexMessage()
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
            request.AddParameter("to", "smarshall@kitjistudios.com");
            request.AddParameter("cc", "frederick.masterton@hotmail.com");
            request.AddParameter("bcc", "kamar.durant@gmail.com");
            request.AddParameter("subject", "Hello from Payohtee");
            request.AddParameter("text", "Testing Payohtee Notification");
            request.AddParameter("html",
                                  "<html>HTML version of the body</html>");
            //request.AddFile("attachment", Path.Combine("files", "test.jpg"));
            //request.AddFile("attachment", Path.Combine("files", "C:\\Users\\Shayne Marshall\\Desktop\\test.txt"));
            request.Method = Method.POST;
            return client.Execute(request);
        }

        // POST: api/email/complexmailit
        [Route("api/email/[action]")]
        [ActionName("mailit")]
        [HttpPost]
        public void SendEmailPackage()
        {

        }


    }
}