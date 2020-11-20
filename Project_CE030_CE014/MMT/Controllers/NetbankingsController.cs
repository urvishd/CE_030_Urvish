using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MMT;
using MMT.Models;

namespace MMT.Controllers
{
    public class NetbankingsController : Controller
    {
        private readonly PackageDbContext _context;

        public NetbankingsController(PackageDbContext context)
        {
            _context = context;
        }

        // GET: Netbankings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Netbankings.ToListAsync());
        }

        // GET: Netbankings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netbanking = await _context.Netbankings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (netbanking == null)
            {
                return NotFound();
            }

            return View(netbanking);
        }

        // GET: Netbankings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Netbankings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Username,Password,balance,Bank")] Netbanking netbanking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(netbanking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(netbanking);
        }

        // GET: Netbankings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netbanking = await _context.Netbankings.FindAsync(id);
            if (netbanking == null)
            {
                return NotFound();
            }
            return View(netbanking);
        }

        // POST: Netbankings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Username,Password,balance,Bank")] Netbanking netbanking)
        {
            if (id != netbanking.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(netbanking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NetbankingExists(netbanking.ID))
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
            return View(netbanking);
        }

        // GET: Netbankings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var netbanking = await _context.Netbankings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (netbanking == null)
            {
                return NotFound();
            }

            return View(netbanking);
        }

        // POST: Netbankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var netbanking = await _context.Netbankings.FindAsync(id);
            _context.Netbankings.Remove(netbanking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NetbankingExists(int id)
        {
            return _context.Netbankings.Any(e => e.ID == id);
        }
    }
}
