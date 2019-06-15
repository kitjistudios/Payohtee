using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Payohtee.Models.Personnel.Customs;
using PayohteeWebApp.Data;
using PayohteeWebApp.Properties;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayohteeWebApp.Controllers
{
    public class CustomsOfficerController : Controller, IPayohteeController
    {
        private readonly PayohteeDbContext _context;

        public CustomsOfficerController(PayohteeDbContext context)
        {
            _context = context;
        }


        // GET: CustomsOfficer/Create
        public IActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> Register(string customsofficerjson)
        {
            CustomsOfficer customsofficer = JsonConvert.DeserializeObject<CustomsOfficer>(customsofficerjson);

            customsofficerjson = JsonConvert.SerializeObject(customsofficer);

            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurllocal);
            var request = payohteerest.PayohteeRestRequest("/customsofficer/register/", null);

            request.Method = Method.POST;
            request.AddParameter("application/json; charset=utf-8", customsofficerjson, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            IRestResponse Iresponse = client.Execute(request);
            var response = Iresponse.Content;
            //Invalid model 
            //Success
            return Content(response);
        }

        public async Task<ViewResult> Index(string name)
        {
            var customsofficer = await _context.DbContextCustomsOfficer.Where(x => x.FirstName + " " + x.LastName == name).FirstOrDefaultAsync<CustomsOfficer>();
            var model = customsofficer;
            return View(model);
        }

        public async Task<IActionResult> DetailsName(string name)
        {
            //This is going to get its credentials from the appsettings Json file
            //Configured in the Startup file
            var company = await _context.DbContextCustomsOfficer.Where(x => x.FirstName + " " + x.LastName == name).FirstOrDefaultAsync<CustomsOfficer>();
            var model = company;
            return View(model);
        }

        public async Task<ActionResult> Details(int? id)
        {
            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurlremote);
            var request = payohteerest.PayohteeRestRequest("/customsofficer/fetch/", id.ToString());

            request.Method = Method.POST;

            request.RequestFormat = DataFormat.Json;
            IRestResponse Iresponse = client.Execute(request);
            var response = Iresponse.Content;
            var customsofficerjson = JsonConvert.SerializeObject(response);
            return View(customsofficerjson);
        }

        public async Task<ActionResult> Lookup(string charinput)
        {
            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurlremote);
            var request = payohteerest.PayohteeRestRequest("/customsofficer/suggestive/", charinput);
            request.Method = Method.GET;
            IRestResponse Iresponse = client.Execute(request);
            var response = Iresponse.Content;
            var result = JsonConvert.DeserializeObject<List<String>>(response);
            return Json(result);
        }

        public async Task<ActionResult> Update(int id, string customsofficerjson)
        {
            CustomsOfficer customsofficer = JsonConvert.DeserializeObject<CustomsOfficer>(value: customsofficerjson);
            customsofficer.EmployeeId = id;
            customsofficerjson = JsonConvert.SerializeObject(customsofficer);

            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurlremote);
            var request = payohteerest.PayohteeRestRequest("/customsofficer/update/" + id, null);

            request.Method = Method.POST;
            request.AddParameter("application/json; charset=utf-8", customsofficerjson, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            IRestResponse Iresponse = client.Execute(request);
            var response = Iresponse.Content;

            return Content(response);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurlremote);
            var request = payohteerest.PayohteeRestRequest("/customsofficer/erase/" + id, null);

            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;
            IRestResponse Iresponse = client.Execute(request);
            var response = Iresponse.Content;

            return View();
        }

        public bool EmployeeExists(int id)
        {
            throw new NotImplementedException();
        }


    }
}
