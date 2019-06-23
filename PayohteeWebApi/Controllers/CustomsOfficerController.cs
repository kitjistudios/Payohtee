using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Payohtee.Models.Banking;
using Payohtee.Models.Personnel.Customs;
using PayohteeWebApp.Data;
using PayohteeWebApp.Models.Banking;
using PayohteeWebApp.Models.Banking.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayohteeWebApi.Controllers
{
    [ApiController]
    public class CustomsOfficerController : ControllerBase
    {
        private readonly PayohteeDbContext _context;
        private readonly CustomsOfficer _customsofficer;
      

        public CustomsOfficerController(PayohteeDbContext context)
        {
            _context = context;
            _customsofficer = new CustomsOfficer();
         
        }

        // POST: api/customsofficer/register
        [Route("api/customsofficer/[action]")]
        [ActionName("register")]
        [HttpPost]
        public async Task<ActionResult<CustomsOfficer>> RegisterCustomsOfficer(CustomsOfficer customsofficer)
        {
            //Check model validity
            //If model is valid commit
            //If model is invalid return invalid attributes
            if (ModelState.IsValid)
            {
                if (customsofficer != null)
                {
                    customsofficer.Status = "Active";
                    _context.DbContextCustomsOfficer.Add(customsofficer);
                    if (customsofficer.BankAccounts.Count != 0)
                    {
                        foreach (var bankaccount in customsofficer.BankAccounts)
                        {
                            _context.DbContextCustomsBankAccount.Add(bankaccount);
                        }
                    }
                    //if (customsofficer.Coordinates.Count != 0)
                    //{
                    //    foreach (var coord in customsofficer.Coordinates)
                    //    {
                    //        _context.DbContextGeo.Add(coord);
                    //    }
                    //}
                }
                await _context.SaveChangesAsync();
                return Content("success");
            }       
            return Content(null);
        }

        // GET: api/customsofficer/fetchall
        [Route("api/customsofficer/[action]")]
        [ActionName("fetchall")]
        [HttpGet]
        public async Task<ActionResult<String>> GetCustomsOfficer()
        {
            var customsofficer = await _context.DbContextCustomsOfficer.Where(x => x.Status == "Active").ToListAsync();
            var bankaccount = await _context.DbContextCustomsBankAccount.Include(x => x.Employee).ToListAsync<CustomsBankAccount>();
            //var coord = await _context.DbContextGeo.Include(x => x.Company).ToListAsync<GeoLocate>();
            if (customsofficer.Count == 0)
            {
                return NotFound();
            }
            var setting = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string customsofficerjson = JsonConvert.SerializeObject(customsofficer, Formatting.Indented, setting);
            return Content( customsofficerjson);
        }

        // GET: api/customsofficer/fetch/id
        [Route("api/customsofficer/[action]/{id}")]
        [ActionName("fetch")]
        [HttpGet("{id}")]
        public async Task<ActionResult<String>> GetCustomsOfficer(int id)
        {
            var customsofficer = await _context.DbContextCustomsOfficer.Where(x => x.EmployeeId == id && x.Status == "Active").ToListAsync();
            var bankaccount = await _context.DbContextCustomsBankAccount.Include(x => x.Employee).ToListAsync<CustomsBankAccount>();
            //var coord = await _context.DbContextGeo.Include(x => x.customsofficer).ToListAsync<GeoLocate>();

            if (customsofficer.Count == 0)
            {
                return NotFound();
            }
            var setting = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string customsofficerjson = JsonConvert.SerializeObject(customsofficer, Formatting.Indented, setting);
            return customsofficerjson;
        }

        // GET: api/customsofficer/fetch/id
        [Route("api/customsofficer/[action]/{name}")]
        [ActionName("fetchname")]
        [HttpGet("{name}")]
        public async Task<ActionResult<String>> GetCustomsOfficer(string name)
        {
            var customsofficer = await _context.DbContextCustomsOfficer.Where(x => x.FirstName + " " + x.LastName == name && x.Status == "Active").ToListAsync();
            var bankaccount = await _context.DbContextCustomsBankAccount.Include(x => x.Employee).ToListAsync<CustomsBankAccount>();
            //var coord = await _context.DbContextGeo.Include(x => x.customsofficer).ToListAsync<GeoLocate>();
            if (customsofficer.Count == 0)
            {
                return NotFound();
            }
            var setting = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string customsofficerjson = JsonConvert.SerializeObject(customsofficer, Formatting.Indented, setting);
            return Content(customsofficerjson);
        }

        // GET: api/customsofficer/suggestive/<char>
        [Route("api/customsofficer/[action]/{charinput}")]
        [ActionName("suggestive")]
        [HttpGet]
        public async Task<List<string>> LookupCustomsOfficer(string charinput)
        {
            var customsofficer = new CustomsOfficer();
            List<string> result = await customsofficer.GetAsyncListEmployeeName(charinput);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        // POST: api/customsofficer/update/id
        [Route("api/customsofficer/[action]/{id}")]
        [ActionName("update")]
        [HttpPost("{id}")]
        public async Task<ActionResult<CustomsOfficer>> UpdateCustomsOfficer(int id, CustomsOfficer customsofficer)
        {
            if (ModelState.IsValid)
            {
                if (OfficerExists(id))
                {
                    customsofficer.EmployeeId = id;
                    customsofficer.Status = "Active";
                    //_context.Entry(customsofficer).State = EntityState.Modified;
                    _context.DbContextCustomsOfficer.Update(customsofficer);
                    await _context.SaveChangesAsync();
                    return Content("success");
                }
            }

            return Content("Customs officer unavailable or model invalid");
        }

        // GET: api/customsofficer/erase/id
        [Route("api/customsofficer/[action]/{id}")]
        [ActionName("erase")]
        [HttpPost("{id}")]
        public async Task<ActionResult<CustomsOfficer>> RemoveCustomsOfficer(int id)
        {
            var customsofficer = _context.DbContextCustomsOfficer.Where(x => x.EmployeeId == id && x.Status == "Active").FirstOrDefault<CustomsOfficer>();

            if (customsofficer != null)
            {
                customsofficer.Status = "Inactive";
                _context.DbContextCustomsOfficer.Update(customsofficer);
                await _context.SaveChangesAsync();
                return Content("success");
            }

            return Content("Customs officer unavailable or removed");
        }

        private bool OfficerExists(int id)
        {
            return _context.DbContextCustomsOfficer.Any(e => e.EmployeeId == id);
        }
    }
}