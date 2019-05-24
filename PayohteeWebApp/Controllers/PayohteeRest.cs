using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayohteeWebApp.Controllers
{
    public class PayohteeRest
    {
        public RestClient PayohteeRestClient(string url)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(url)
            };

            return client;
        }

        public RestRequest PayohteeRestRequest(string resource)
        {
            var request = new RestRequest
            {
                Resource = "/company/register/",
                Method = Method.POST
            };
            return request;
        }
    }
}
