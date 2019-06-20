using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PayohteeWebApp.Data;
using PayohteeWebApp.Models.Settings.Roles.Customs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PayohteeWebApi.Controllers
{
    [ApiController]
    public class CustomsRateController : ControllerBase
    {
        private readonly PayohteeDbContext _context;

        public CustomsRateController(PayohteeDbContext context)
        {
            _context = context;
        }

        // GET: api/customsrate/fetchall
        [Route("api/customsrate/[action]")]
        [ActionName("fetchall")]
        [HttpGet]
        public async Task<ActionResult<String>> GetCustomsRates()
        {
            var rate = await _context.DbContextCustomsRates.ToListAsync();
            var role = await _context.DbContextCustomsRoles.Include(x => x.CustomsRates).ToListAsync<CustomsRoles>();
            var payrole = new CustomsRoles();
            if (role.Count == 0)
            {
                return NotFound();
            }

            payrole.RolesList = role;
            payrole.RateList = rate;
            payrole.PayRoleName = role[0].PayRoleName;
            payrole.ShortName = role[0].ShortName;
            payrole.RoleId = role[0].RoleId;
            //payrole.RateAmount = rate[0].RateAmount;

            var setting = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string payratejson = JsonConvert.SerializeObject(payrole, Formatting.Indented, setting);

            return Content(payratejson);
        }

        //GET: api/customsofficer/fetch/id
        [Route("api/customsrate/[action]/{id}")]
        [ActionName("fetch")]
        [HttpGet("{id}")]
        public async Task<ActionResult<String>> GetCustomsRates(int id)
        {
            if (RateExists(id))
            {
                var rate = await _context.DbContextCustomsRates.Where(x => x.RoleId == id).ToListAsync();
                var role = await _context.DbContextCustomsRoles.Include(x => x.CustomsRates).ToListAsync<CustomsRoles>();

                var payrole = new CustomsRoles();

                payrole.RolesList = role;
                payrole.RateList = rate;
                payrole.PayRoleName = role[0].PayRoleName;
                payrole.ShortName = role[0].ShortName;
                payrole.RoleId = role[0].RoleId;
                //payrole.RateAmount = rate[0].RateAmount;

                var setting = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
                string payratejson = JsonConvert.SerializeObject(payrole, Formatting.Indented, setting);

                return Content(payratejson);
            }
            return Content("rate unavailable");
        }

        // POST: api/company/register
        [Route("api/customsrate/[action]")]
        [ActionName("register")]
        [HttpPost]
        public async Task<ActionResult<CustomsRoles>> RegisterCompany(CustomsRoles customsrole)
        {
            if (ModelState.IsValid)
            {
                if (customsrole != null)
                {
                    _context.DbContextCustomsRoles.Add(customsrole);
                    if (customsrole.CustomsRates!= null)
                    {
                        //foreach (var rate in customsrole.RateList)
                        //{
                            _context.DbContextCustomsRates.Add(customsrole.CustomsRates);
                        //}
                    }

                }
                await _context.SaveChangesAsync();
                return Content("success");
            }
            return Content(null);
        }

        private bool RateExists(int id)
        {
            return _context.DbContextCustomsRates.Any(e => e.RoleId == id);
        }

    }
}
