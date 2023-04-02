using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EVProjectDup.Data;
using EVProjectDup.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Authorization;
using EVP.Utility;
using System.Data;

namespace EVProjectDup.Controllers
{
    public class StationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stations
        //public async Task<IActionResult> Index( string query)
        //{
            /*  return _context.stations != null ? 
                          View(await _context.stations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.stations'  is null.");*/
           
        //}
         public async Task<IActionResult> Index(string searchString)
        {
            if (_context.stations == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var stations = from m in _context.stations
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                stations = stations.Where(s => s.Adress.Contains(searchString));
            }

            return View(await stations.ToListAsync());
        }


        [Authorize]

        // GET: Stations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.stations == null)
            {
                return NotFound();
            }

            var station = await _context.stations
                .FirstOrDefaultAsync(m => m.CSId == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        [Authorize (Roles = SD.Role_Admin)]
        // GET: Stations/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CSId,CSEmail,CSPhoneNumber,CSName,CSDescription,City,PinCode,Adress,NoOfPorts,imagurl,AdressLink,status,Price")] Station station)
        {
            if (ModelState.IsValid)
            {
                _context.Add(station);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(station);
        }

        [Authorize(Roles = SD.Role_Admin +","+SD.Role_User_Sta)]
        // GET: Stations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.stations == null)
            {
                return NotFound();
            }

            var station = await _context.stations.FindAsync(id);
            if (station == null)
            {
                return NotFound();
            }
            return View(station);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CSId,CSEmail,CSPhoneNumber,CSName,CSDescription,City,PinCode,Adress,NoOfPorts,imagurl,AdressLink,status,Price")] Station station)
        {
            if (id != station.CSId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(station);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationExists(station.CSId))
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
            return View(station);
        }

        [Authorize(Roles = SD.Role_Admin)]
        // GET: Stations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.stations == null)
            {
                return NotFound();
            }

            var station = await _context.stations
                .FirstOrDefaultAsync(m => m.CSId == id);
            if (station == null)
            {
                return NotFound();
            }

            return View(station);
        }

        // POST: Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.stations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.stations'  is null.");
            }
            var station = await _context.stations.FindAsync(id);
            if (station != null)
            {
                _context.stations.Remove(station);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StationExists(int id)
        {
          return (_context.stations?.Any(e => e.CSId == id)).GetValueOrDefault();
        }
    }
}
