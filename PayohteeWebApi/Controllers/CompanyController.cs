using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Payohtee.Models.Customer;
using Payohtee.Models.GeoTracking;
using PayohteeWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayohteeApi.Controllers
{

    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly PayohteeDbContext _context;
        private readonly Company _company;

        public CompanyController(PayohteeDbContext context)
        {
            _context = context;
            _company = new Company();
        }

        // POST: api/company/register
        [Route("api/company/[action]")]
        [ActionName("register")]
        [HttpPost]
        public async Task<ActionResult<Company>> RegisterCompany(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company != null)
                {
                    company.Status = "Active";
                    _context.DbContextCompany.Add(company);
                    if (company.Contacts.Count != 0)
                    {
                        foreach (var contact in company.Contacts)
                        {
                            _context.DbContextContacts.Add(contact);
                        }
                    }
                    if (company.Coordinates.Count != 0)
                    {
                        foreach (var coord in company.Coordinates)
                        {
                            _context.DbContextGeo.Add(coord);
                        }
                    }
                }
                await _context.SaveChangesAsync();
                return Content("Success");
            }

            return Content("Invalid model");
        }

        // GET: api/company/fetchall
        [Route("api/company/[action]")]
        [ActionName("fetchall")]
        [HttpGet]
        public async Task<ActionResult<String>> GetCompanies()
        {
            var company = await _context.DbContextCompany.Where(x => x.Status == "Active").ToListAsync();
            var contact = await _context.DbContextContacts.Include(x => x.Company).ToListAsync<Contact>();
            var coord = await _context.DbContextGeo.Include(x => x.Company).ToListAsync<GeoLocate>();
            if (company.Count == 0)
            {
                return NotFound();
            }
            var setting = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string companyjson = JsonConvert.SerializeObject(company, Formatting.Indented, setting);
            return companyjson;
        }

        // GET: api/company/fetch/id
        [Route("api/company/[action]/{id}")]
        [ActionName("fetch")]
        [HttpGet("{id}")]
        public async Task<ActionResult<String>> GetCompany(int id)
        {
            var company = await _context.DbContextCompany.Where(x => x.CompanyId == id && x.Status == "Active").ToListAsync();
            var contact = await _context.DbContextContacts.Where(t => t.Company.CompanyId == id).Include(x => x.Company).ToListAsync<Contact>();
            var coord = await _context.DbContextGeo.Include(x => x.Company).ToListAsync<GeoLocate>();

            if (company.Count == 0)
            {
                return Content("Company unavailable");
            }
            var setting = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string companyjson = JsonConvert.SerializeObject(company, Formatting.Indented, setting);
            return companyjson;
        }

        // GET: api/company/fetch/id
        [Route("api/company/[action]/{name}")]
        [ActionName("fetchname")]
        [HttpGet("{name}")]
        public async Task<ActionResult<String>> GetCompany(string name)
        {
            var company = await _context.DbContextCompany.Where(x => x.CompanyName == name && x.Status == "Active").ToListAsync();
            var contact = await _context.DbContextContacts.Where(t => t.Company.CompanyName == name).Include(x => x.Company).ToListAsync<Contact>();
            var coord = await _context.DbContextGeo.Include(x => x.Company).ToListAsync<GeoLocate>();
            if (company.Count == 0)
            {
                return Content("Company unavailable");
            }
            var setting = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string companyjson = JsonConvert.SerializeObject(company, Formatting.Indented, setting);
            return companyjson;
        }

        // GET: api/company/suggestive/<char>
        [Route("api/company/[action]/{charinput}")]
        [ActionName("suggestive")]
        [HttpGet]
        public async Task<List<string>> LookupCompany(string charinput)
        {
            var company = new Company();
            List<string> result = await company.GetAsyncListCompanyName(charinput);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        // POST: api/company/update/id
        [Route("api/company/[action]/{id}")]
        [ActionName("update")]
        [HttpPost("{id}")]
        public async Task<ActionResult<Company>> UpdateCompany(int id, Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.CompanyId == 0)
                {
                    company.CompanyId = id;
                    company.Status = "Active";
                    //_context.Entry(company).State = EntityState.Modified;
                    _context.DbContextCompany.Update(company);
                    await _context.SaveChangesAsync();
                    return Content("Company updated");
                }
                else
                {
                    company.Status = "Active";
                    //_context.Entry(company).State = EntityState.Modified;
                    _context.DbContextCompany.Update(company);
                    await _context.SaveChangesAsync();
                    return Content("Company updated");
                }
            }

            return Content("Company unavailable or model invalid");
        }

        // GET: api/company/erase/id
        [Route("api/company/[action]/{id}")]
        [ActionName("erase")]
        [HttpPost("{id}")]
        public async Task<ActionResult<Company>> RemoveCompany(int id)
        {
            var company = _context.DbContextCompany.Where(x => x.CompanyId == id && x.Status == "Active").FirstOrDefault<Company>();

            if (company != null)
            {
                company.Status = "Inactive";
                _context.DbContextCompany.Update(company);
                await _context.SaveChangesAsync();
                return Content("Company removed");
            }

            return Content("Company unavailable or removed");
        }

    }
}