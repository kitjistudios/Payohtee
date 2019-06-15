using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Payohtee.Models.Personnel.Customs;
using PayohteeWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayohteeWebApi.Controllers
{

    public class CustomsOfficerController : ControllerBase
    {
        private readonly PayohteeDbContext _context;
        private readonly CustomsOfficer _customsofficer;
        private readonly List<KeyValuePair<String, String>> _keyvalerror;

        public CustomsOfficerController(PayohteeDbContext context)
        {
            _context = context;
            _customsofficer = new CustomsOfficer();
            _keyvalerror = new List<KeyValuePair<String, String>>();
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
                    //if (customsofficer.BankAccounts.Count != 0)
                    //{
                    //    foreach (var contact in customsofficer.BankDetails)
                    //    {
                    //        _context.DbContextContacts.Add(contact);
                    //    }
                    //}
                    //if (customsofficer.Coordinates.Count != 0)
                    //{
                    //    foreach (var coord in customsofficer.Coordinates)
                    //    {
                    //        _context.DbContextGeo.Add(coord);
                    //    }
                    //}
                }
                await _context.SaveChangesAsync();
                return Content("Success");
            }
            else
            {            
                foreach (var keyval in ModelState.Keys)
                {
                    var modelstate = ModelState[keyval];
                    foreach (var err in modelstate.Errors)
                    {
                        var key = keyval;
                        var errormessage = err.ErrorMessage;
                        _keyvalerror.Add(new KeyValuePair<string, string>(key, errormessage));

                    }
                }
            }
            var keyvalerrorlist = _keyvalerror.ToList();
            var keyvaljson = JsonConvert.SerializeObject(keyvalerrorlist);

            return Content(keyvaljson);
        }

        // GET: api/customsofficer/fetchall
        [Route("api/customsofficer/[action]")]
        [ActionName("fetchall")]
        [HttpGet]
        public async Task<ActionResult<String>> GetCustomsOfficer()
        {
            var customsofficer = await _context.DbContextCustomsOfficer.Where(x => x.Status == "Active").ToListAsync();
            //var contact = await _context.DbContextContacts.Include(x => x.Company).ToListAsync<Contact>();
            //var coord = await _context.DbContextGeo.Include(x => x.Company).ToListAsync<GeoLocate>();
            if (customsofficer.Count == 0)
            {
                return NotFound();
            }
            var setting = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string customsofficerjson = JsonConvert.SerializeObject(customsofficer, Formatting.Indented, setting);
            return customsofficerjson;
        }

        // GET: api/customsofficer/fetch/id
        [Route("api/customsofficer/[action]/{id}")]
        [ActionName("fetch")]
        [HttpGet("{id}")]
        public async Task<ActionResult<String>> GetCustomsOfficer(int id)
        {
            var customsofficer = await _context.DbContextCustomsOfficer.Where(x => x.EmployeeId == id && x.Status == "Active").ToListAsync();
            //var contact = await _context.DbContextContacts.Where(t => t.customsofficer.customsofficerId == id).Include(x => x.customsofficer).ToListAsync<Contact>();
            //var coord = await _context.DbContextGeo.Include(x => x.customsofficer).ToListAsync<GeoLocate>();

            if (customsofficer.Count == 0)
            {
                return Content("Customs officer unavailable");
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
            //var contact = await _context.DbContextContacts.Where(t => t.customsofficer.customsofficerName == name).Include(x => x.customsofficer).ToListAsync<Contact>();
            //var coord = await _context.DbContextGeo.Include(x => x.customsofficer).ToListAsync<GeoLocate>();
            if (customsofficer.Count == 0)
            {
                return Content("Customs officer unavailable");
            }
            var setting = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string customsofficerjson = JsonConvert.SerializeObject(customsofficer, Formatting.Indented, setting);
            return customsofficerjson;
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
                if (customsofficer.EmployeeId == 0)
                {
                    customsofficer.EmployeeId = id;
                    customsofficer.Status = "Active";
                    //_context.Entry(customsofficer).State = EntityState.Modified;
                    _context.DbContextCustomsOfficer.Update(customsofficer);
                    await _context.SaveChangesAsync();
                    return Content("Customs officer updated");
                }
                else
                {
                    customsofficer.Status = "Active";
                    //_context.Entry(customsofficer).State = EntityState.Modified;
                    _context.DbContextCustomsOfficer.Update(customsofficer);
                    await _context.SaveChangesAsync();
                    return Content("Customs officer updated");
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
                return Content("Customs officer removed");
            }

            return Content("Customs officer unavailable or removed");
        }
    }
}