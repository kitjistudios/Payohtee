using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payohtee.Models.Customer;
using PayohteeWebApp.Data;
using System.Collections.Generic;
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

        // GET: api/company/fetchall
        [Route("api/company/[action]")]
        [ActionName("fetchall")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return await _context.DbContextCompany.ToListAsync();
        }

        // GET: api/company/fetch/id
        [Route("api/company/[action]/{id}")]
        [ActionName("fetch")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _context.DbContextCompany.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // GET: api/company/suggestive/<char>
        [Route("api/company/[action]/{charinput}")]
        [ActionName("suggestive")]
        [HttpGet]
        public ActionResult<List<string>> GetLookup(string charinput)
        {
            var result = new Company().GetAsyncListCompanyName(charinput);
            if (result == null)
            {
                return NotFound();
            }

            return result;
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
    }
}