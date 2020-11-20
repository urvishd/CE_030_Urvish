using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MMT.Controllers
{
    [Authorize]
    public class CustomerBooking : Controller
    {
        private readonly PackageDbContext _context;

        public CustomerBooking(PackageDbContext context)
        {
            _context = context;
        }
        // GET: CustomerBooking
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bookings.ToListAsync());
        }

        // GET: CustomerBooking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerBooking/Create
       

        // POST: CustomerBooking/Create
       

        // GET: CustomerBooking/Edit/5
       

        // POST: CustomerBooking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerBooking/Delete/5
        public async Task<IActionResult> Cancel(int id)
        {
            var booking = await _context.Bookings
               .FirstOrDefaultAsync(m => m.BookingID == id);
            ViewBag.amt = booking.Amount;
            booking.status = "Cancelled";
            _context.Update(booking);
            await _context.SaveChangesAsync();
            return View();
        }

        // POST: CustomerBooking/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
