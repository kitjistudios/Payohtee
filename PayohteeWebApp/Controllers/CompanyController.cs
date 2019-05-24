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

        // GET: Companies
        public IActionResult Index(Company company)
        {
            return View(company);
        }

        // GET: Companies/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var company = await _context.DbContextCompany
        //        .FirstOrDefaultAsync(m => m.CompanyId == id);
        //    if (company == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(company);
        //}

        // GET: Companies/Details/companyname
        //public async Task<IActionResult> Details(string name)
        //{
        //    if (name == null)
        //    {
        //        return NotFound();
        //    }

        //    var company = await _context.DbContextCompany
        //        .FirstOrDefaultAsync(m => m.CompanyName == name);
        //    if (company == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(company);
        //}

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyId,PayohteeId,CompanyName,CompanyAlias,CompanyTaxId,CompanyIndustry,Address1,Address2,Address3,Address4,Parish,Country,PostalCode,CompanyPhoneNumber,FaxNumber,CompanyEmail,Status")] Company company)
        {
            //loop through list of contacts and add to collection of contact in company model
            //check to see if model is valid
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.DbContextCompany.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,PayohteeId,CompanyName,CompanyAlias,CompanyTaxId,CompanyIndustry,Address1,Address2,Address3,Address4,Parish,Country,PostalCode,CompanyPhoneNumber,FaxNumber,CompanyEmail,Status")] Company company)
        {
            if (id != company.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CompanyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.DbContextCompany
                .FirstOrDefaultAsync(m => m.CompanyId == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.DbContextCompany.FindAsync(id);
            _context.DbContextCompany.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.DbContextCompany.Any(e => e.CompanyId == id);
        }

        [HttpGet]
        public ActionResult Lookup(string charinput)
        {
            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurllocal);
            var request = payohteerest.PayohteeRestRequest("/company/suggestive/" + charinput);
            request.Method = Method.GET;
            IRestResponse Iresponse = client.Execute(request);
            var response = Iresponse.Content;
            var result = JsonConvert.DeserializeObject<List<String>>(response);
            return Json(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string companyjson)
        {
            Company company = JsonConvert.DeserializeObject<Company>(companyjson);
            company.Status = "Active";
            companyjson = JsonConvert.SerializeObject(company);

            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurllocal);
            var request = payohteerest.PayohteeRestRequest("/company/register/");

            request.Method = Method.POST;
            request.AddParameter("application/json; charset=utf-8", companyjson, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            IRestResponse Iresponse = client.Execute(request);
            var response = Iresponse.Content;

            return View(companyjson);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurllocal);
            var request = payohteerest.PayohteeRestRequest("/company/fetch/" + id);

            request.Method = Method.POST;

            request.RequestFormat = DataFormat.Json;
            IRestResponse Iresponse = client.Execute(request);
            var response = Iresponse.Content;
            var companyjson = JsonConvert.SerializeObject(response);
            return View(companyjson);
        }

        [HttpPost]
        public ActionResult Update(int? id, string companyjson)
        {
            Company company = JsonConvert.DeserializeObject<Company>(companyjson);
            companyjson = JsonConvert.SerializeObject(company);

            var payohteerest = new PayohteeRest();
            var client = payohteerest.PayohteeRestClient(Resources.baseurllocal);
            var request = payohteerest.PayohteeRestRequest("/company/update/");

            request.Method = Method.POST;
            request.AddParameter("application/json; charset=utf-8", companyjson, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            IRestResponse Iresponse = client.Execute(request);
            var response = Iresponse.Content;

            return View(companyjson);
        }

    }
}
