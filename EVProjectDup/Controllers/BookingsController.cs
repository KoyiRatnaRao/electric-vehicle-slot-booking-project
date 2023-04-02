using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EVProjectDup.Data;
using EVProjectDup.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using static System.Collections.Specialized.BitVector32;
using Microsoft.AspNetCore.Authorization;
using EVP.Utility;

namespace EVProjectDup.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        //  private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BookingsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            //   _userManager = userManager;

        }

        // GET: Bookings
        [Authorize]
        public async Task<IActionResult> Index()
        {
            /* return _context.bookings != null ? 
                         View(await _context.bookings.ToListAsync()) :
                         Problem("Entity set 'ApplicationDbContext.bookings'  is null.");*/
            var S = _context.stations.FirstOrDefault(b => b.CSEmail ==User.Identity.Name);
            var B = _context.bookings.FirstOrDefault(b => b.UserName == User.Identity.Name);
            ViewBag.station = S;
            ViewBag.bookings = B;
            return _context.bookings != null ?
                          View(await _context.bookings.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.bookings'  is null.");

        }

        // GET: Bookings/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.bookings
                .FirstOrDefaultAsync(m => m.BId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        [Authorize]
        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
             {
                 return NotFound();
             }

             var station = await _context.stations.FindAsync(id);
             var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
             var userDetailes = _context.applicationUsers.FirstOrDefault(u => u.Id == userId);

            if (station == null)
             {
                 return NotFound();
             }
             ViewBag.station = station;
             ViewBag.userId = userId;
             ViewBag.userd = userDetailes;
             return View();

        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BId,CSId,PortNumber,StartTime,EndTime,VehicleName,VehicleNumber,UserId,UserName,PhoneNumber")] Booking booking)
        {
            var existingBooking = await _context.bookings
       .Where(b =>
           b.CSId == booking.CSId &&
           b.PortNumber == booking.PortNumber &&
           b.StartTime < booking.EndTime &&
           b.EndTime > booking.StartTime)
       .FirstOrDefaultAsync();

            if (existingBooking != null)
            {
                ModelState.AddModelError("", "This time slot is already booked.");
            }
            if (ModelState.IsValid)
             {
                 _context.Add(booking);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(booking);

        }

        // GET: Bookings/Edit/5
        [Authorize (Roles = SD.Role_Admin)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BId,CSId,PortNumber,StartTime,EndTime,VehicleName,VehicleNumber,UserId,UserName,PhoneNumber")] Booking booking)
        {
            if (id != booking.BId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BId))
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
            return View(booking);
        }

        // GET: Bookings/Delete/5
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_User_Sta +","+ SD.Role_User_Indi)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.bookings
                .FirstOrDefaultAsync(m => m.BId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.bookings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.bookings'  is null.");
            }
            var booking = await _context.bookings.FindAsync(id);
            if (booking != null)
            {
                _context.bookings.Remove(booking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
          return (_context.bookings?.Any(e => e.BId == id)).GetValueOrDefault();
        }
    }
}
