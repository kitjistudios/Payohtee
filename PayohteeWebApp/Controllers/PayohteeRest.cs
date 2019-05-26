using RestSharp;
using System;

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

        public RestRequest PayohteeRestRequest(string resource, string prms)
        {
            var request = new RestRequest
            {
                Resource = resource + prms
            };
            return request;
        }
    }
}
