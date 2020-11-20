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
    public class DcardsController : Controller
    {
        private readonly PackageDbContext _context;

        public DcardsController(PackageDbContext context)
        {
            _context = context;
        }

        // GET: Dcards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cards.ToListAsync());
        }

        // GET: Dcards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dcard = await _context.Cards
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dcard == null)
            {
                return NotFound();
            }

            return View(dcard);
        }

        // GET: Dcards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dcards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CardNumber,month,year,CVV,mailid,balance")] Dcard dcard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dcard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dcard);
        }

        // GET: Dcards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dcard = await _context.Cards.FindAsync(id);
            if (dcard == null)
            {
                return NotFound();
            }
            return View(dcard);
        }

        // POST: Dcards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CardNumber,month,year,CVV,mailid,balance")] Dcard dcard)
        {
            if (id != dcard.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dcard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DcardExists(dcard.ID))
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
            return View(dcard);
        }

        // GET: Dcards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dcard = await _context.Cards
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dcard == null)
            {
                return NotFound();
            }

            return View(dcard);
        }

        // POST: Dcards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dcard = await _context.Cards.FindAsync(id);
            _context.Cards.Remove(dcard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DcardExists(int id)
        {
            return _context.Cards.Any(e => e.ID == id);
        }
    }
}
