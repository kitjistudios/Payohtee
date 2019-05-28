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
    public class GPSCoordinatesController : Controller
    {
        private readonly PayohteeDbContext _context;

        public GPSCoordinatesController(PayohteeDbContext context)
        {
            _context = context;
        }

        // GET: GPSCoordinates
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: GPSCoordinates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gPSCoordinates = await _context.DbContextGPS
                .FirstOrDefaultAsync(m => m.GPSId == id);
            if (gPSCoordinates == null)
            {
                return NotFound();
            }

            return View(gPSCoordinates);
        }

        // GET: GPSCoordinates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GPSCoordinates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GPSId,Time")] GPSCoordinates gPSCoordinates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gPSCoordinates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gPSCoordinates);
        }

        // GET: GPSCoordinates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gPSCoordinates = await _context.DbContextGPS.FindAsync(id);
            if (gPSCoordinates == null)
            {
                return NotFound();
            }
            return View(gPSCoordinates);
        }

        // POST: GPSCoordinates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GPSId,Time")] GPSCoordinates gPSCoordinates)
        {
            if (id != gPSCoordinates.GPSId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gPSCoordinates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GPSCoordinatesExists(gPSCoordinates.GPSId))
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
            return View(gPSCoordinates);
        }

        // GET: GPSCoordinates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gPSCoordinates = await _context.DbContextGPS
                .FirstOrDefaultAsync(m => m.GPSId == id);
            if (gPSCoordinates == null)
            {
                return NotFound();
            }

            return View(gPSCoordinates);
        }

        // POST: GPSCoordinates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gPSCoordinates = await _context.DbContextGPS.FindAsync(id);
            _context.DbContextGPS.Remove(gPSCoordinates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GPSCoordinatesExists(int id)
        {
            return _context.DbContextGPS.Any(e => e.GPSId == id);
        }
    }
}
