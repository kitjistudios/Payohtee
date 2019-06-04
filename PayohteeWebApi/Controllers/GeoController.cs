using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Payohtee.Models.GeoTracking;
using PayohteeWebApi.Properties;
using PayohteeWebApp.Data;
using RestSharp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PayohteeWebApi.Controllers
{
    [ApiController]
    public class GeoController : ControllerBase
    {
        private readonly PayohteeDbContext _context;
        private readonly GeoLocate _geolocate;

        public GeoController(PayohteeDbContext context)
        {
            _context = context;
        }

        [Route("api/geo/[action]")]
        [ActionName("pinpoint")]
        [HttpPost]
        public ActionResult<GeoLocate> GetLocation()
        {
            //var client = new RestClient("https://www.googleapis.com/geolocation/v1/geolocate");
            var client = new RestClient(Resources.GeoLocationBaseUrl);

            var request = new RestRequest
            {
                Method = Method.POST
            };
            request.AddParameter("key", Resources.GoogleMapsApiKey, ParameterType.QueryString);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return Content(content);
        }

        // POST: api/geo/register
        [Route("api/geo/[action]")]
        [ActionName("register")]
        [HttpPost]
        public async Task<ActionResult<GeoLocate>> RegisterCoord(GeoLocate geolocate)
        {
            if (ModelState.IsValid)
            {
                if (geolocate != null)
                {
                    _context.DbContextGPS.Add(geolocate);
                    await _context.SaveChangesAsync();
                }
                return Content("Success");
            }
            return Content("Invalid model");
        }

        // GET: api/geo/fetchall
        [Route("api/geo/[action]")]
        [ActionName("fetchall")]
        [HttpGet]
        public async Task<ActionResult<String>> GetCoords()
        {
            var coords = await _context.DbContextGPS.ToListAsync();

            if (coords.Count == 0)
            {
                return NotFound();
            }
            var setting = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string coordjson = JsonConvert.SerializeObject(coords, Formatting.Indented, setting);
            return coordjson;
        }

        // GET: api/company/fetch/id
        [Route("api/geo/[action]/{id}")]
        [ActionName("fetch")]
        [HttpGet("{id}")]
        public async Task<ActionResult<String>> GetCoord(int id)
        {
            var geo = await _context.DbContextGPS.Where(t => t.Company.CompanyId == id).ToListAsync<GeoLocate>();
            //var contact = await _context.DbContextContacts.Where(t => t.Company.CompanyName == name).Include(x => x.Company).ToListAsync<Contact>();
            //var company = await _context.DbContextCompany.Where(t => t.CompanyId == id).Include(x => x.Company).ToListAsync<Company>();
            if (geo.Count == 0)
            {
                return Content("Company unavailable");
            }
            var setting = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };
            string geojson = JsonConvert.SerializeObject(geo, Formatting.Indented, setting);
            return geojson;
        }

        // POST: api/company/update/id
        [Route("api/geo/[action]/{id}")]
        [ActionName("update")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoord(int id, GeoLocate geoLocate)
        {
            if (ModelState.IsValid)
            {
                if (!GeoCoordExists(id))
                {
                    //company.CompanyId = id;
                    //company.Status = "Active";
                    //_context.Entry(company).State = EntityState.Modified;
                    _context.DbContextGPS.Update(geoLocate);
                    await _context.SaveChangesAsync();
                    return Content("Coords updated");
                }
                else
                {
                    //company.Status = "Active";
                    //_context.Entry(company).State = EntityState.Modified;
                    _context.DbContextGPS.Update(geoLocate);
                    await _context.SaveChangesAsync();
                    return Content("Coords updated");
                }
            }

            return Content("Coords unavailable or model invalid");
            //if (id != geoLocate.GPSId)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(geoLocate).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!GeoLocateExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // DELETE: api/Geo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeoLocate>> DeleteGeoLocate(int id)
        {
            var geoLocate = await _context.DbContextGPS.FindAsync(id);
            if (geoLocate == null)
            {
                return NotFound();
            }

            _context.DbContextGPS.Remove(geoLocate);
            await _context.SaveChangesAsync();

            return geoLocate;
        }

        private bool GeoCoordExists(int id)
        {
            return _context.DbContextGPS.Where(t => t.Company.CompanyId == id).Include(x => x.Company).Any<GeoLocate>();
            //return _context.DbContextGPS.Any(e => e.GPSId == id);
        }
    }
}
