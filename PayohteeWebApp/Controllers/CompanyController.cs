using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Payohtee.Models.Customer;
using PayohteeWebApp.Controllers;
using PayohteeWebApp.Data;
using PayohteeWebApp.Properties;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayohteeWebApp
{
    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        private readonly PayohteeDbContext _context;

        public CompanyController(PayohteeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Success()
        {
            return View();
        }

        // GET: Companies/Create
        [HttpGet]
        public IActionResult Create()
        {
            var model = new Company();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(string companyjson)
        {
            Company company = JsonConvert.DeserializeObject<Company>(companyjson);

            companyjson = JsonConvert.SerializeObject(company);

            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurlremote);
            var request = payohteerest.PayohteeRestRequest("/company/register/", null);

            request.Method = Method.POST;
            request.AddParameter("application/json; charset=utf-8", companyjson, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            IRestResponse Iresponse = client.Execute(request);
            var response = Iresponse.Content;
            //Invalid model 
            //Success
            return Content(response);

        }

        [HttpGet]
        public async Task<ViewResult> Index(string companyname)
        {
            //var company = await _context.DbContextCompany.FindAsync(5);
            var company = await _context.DbContextCompany.Where(x => x.CompanyName == companyname).FirstOrDefaultAsync<Company>();
            var model = company;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsName(string companyname)
        {
            //This is going to get its credentials from the appsettings Json file
            //Configured in the Startup file
            var company = await _context.DbContextCompany.Where(x => x.CompanyName == companyname).FirstOrDefaultAsync<Company>();
            var model = company;
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurlremote);
            var request = payohteerest.PayohteeRestRequest("/company/fetch/", id.ToString());

            request.Method = Method.POST;

            request.RequestFormat = DataFormat.Json;
            IRestResponse Iresponse = await client.ExecuteTaskAsync(request);
            var response = Iresponse.Content;
            var companyjson = JsonConvert.SerializeObject(response);
            return View(companyjson);
        }

        [HttpGet]
        public async Task<ActionResult> Lookup(string charinput)
        {
            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurlremote);
            var request = payohteerest.PayohteeRestRequest("/company/suggestive/", charinput);
            request.Method = Method.GET;
            IRestResponse Iresponse = await client.ExecuteTaskAsync(request);
            var response = Iresponse.Content;
            var result = JsonConvert.DeserializeObject<List<String>>(response);
            return Json(result);
        }

        [HttpPost]
        public async Task<ActionResult> Update(int id, string companyjson)
        {
            Company company = JsonConvert.DeserializeObject<Company>(companyjson);
            company.CompanyId = id;
            companyjson = JsonConvert.SerializeObject(company);

            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurlremote);
            var request = payohteerest.PayohteeRestRequest("/company/update/" + id, null);

            request.Method = Method.POST;
            request.AddParameter("application/json; charset=utf-8", companyjson, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            IRestResponse Iresponse = await client.ExecuteTaskAsync(request);
            var response = Iresponse.Content;

            return View(companyjson);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurlremote);
            var request = payohteerest.PayohteeRestRequest("/company/erase/" + id, null);

            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;
            IRestResponse Iresponse = await client.ExecuteTaskAsync(request);
            var response = Iresponse.Content;

            return View();
        }

        public bool CompanyExists(int id)
        {
            throw new NotImplementedException();
        }

    }
}
