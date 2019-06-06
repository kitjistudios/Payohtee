using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Payohtee.Models.GeoTracking;
using PayohteeWebApp.Data;

namespace PayohteeWebApp.Controllers
{
    public class GeoController : Controller
    {
        private readonly PayohteeDbContext _context;

        public GeoController(PayohteeDbContext context)
        {
            _context = context;
        }

        // GET: GeoLocates
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tester()
        {

            return View();
        }

        // GET: GeoLocates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geoLocate = await _context.DbContextGPS
                .FirstOrDefaultAsync(m => m.GPSId == id);
            if (geoLocate == null)
            {
                return NotFound();
            }

            return View(geoLocate);
        }

        // GET: GeoLocates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeoLocates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GPSId,Latitude,Longitude,Lat,Long")] GeoLocate geoLocate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(geoLocate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(geoLocate);
        }

        // GET: GeoLocates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geoLocate = await _context.DbContextGPS.FindAsync(id);
            if (geoLocate == null)
            {
                return NotFound();
            }
            return View(geoLocate);
        }

        // POST: GeoLocates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GPSId,Latitude,Longitude,Lat,Long")] GeoLocate geoLocate)
        {
            if (id != geoLocate.GPSId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(geoLocate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeoLocateExists(geoLocate.GPSId))
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
            return View(geoLocate);
        }

        // GET: GeoLocates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geoLocate = await _context.DbContextGPS
                .FirstOrDefaultAsync(m => m.GPSId == id);
            if (geoLocate == null)
            {
                return NotFound();
            }

            return View(geoLocate);
        }

        // POST: GeoLocates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var geoLocate = await _context.DbContextGPS.FindAsync(id);
            _context.DbContextGPS.Remove(geoLocate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeoLocateExists(int id)
        {
            return _context.DbContextGPS.Any(e => e.GPSId == id);
        }
    }
}
