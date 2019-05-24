using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payohtee.Models.Customer;
using PayohteeWebApp.Data;
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
                    _context.DbContextCompany.Add(company);
                    if (company.Contacts.Count != 0)
                    {
                        foreach (var item in company.Contacts)
                        {
                            _context.DbContextContacts.Add(item);
                        }
                    }
                }
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction(nameof(Company), new { id = company.CompanyId }, company);
        }

        // GET: api/company/fetchall
        [Route("api/company/[action]")]
        [ActionName("fetchall")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return await _context.DbContextCompany.Where(x => x.Status == "Active").ToListAsync();
        }

        // GET: api/company/fetch/id
        [Route("api/company/[action]/{id}")]
        [ActionName("fetch")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {

            var company = await _context.DbContextCompany.FindAsync(id);
            var contact = _context.DbContextContacts.Where(t => t.Company.CompanyId == company.CompanyId).Include(x => x.Company).ToList<Contact>();

            if (company == null)
            {
                return NotFound();
            }

            //company.Contacts = contact;
            return company;
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
                if (company != null)
                {
                    _context.DbContextCompany.Update(company);
                }
            }
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Company), new { id = company.CompanyId }, company);
        }

        // GET: api/company/erase/id
        [Route("api/company/[action]/{id}")]
        [ActionName("erase")]
        [HttpPost("{id}")]
        public async Task<ActionResult<Company>> RemoveCompany(int id)
        {
            var company = await _context.DbContextCompany.FindAsync(id);
            company.Status = "Inactive";
            if (ModelState.IsValid)
            {
                if (company != null)
                {
                    _context.DbContextCompany.Update(company);
                }
            }
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Company), new { id = company.CompanyId }, company);
        }

    }
}