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
    
    public class AllPackage : Controller
    {
        public string SessionAmt1 = "_Amt1";
        // GET: AllPackage
        private readonly PackageDbContext _context;

        public AllPackage(PackageDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Packages.ToListAsync());
        }

        // GET: AllPackage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AllPackage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllPackage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AllPackage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        public async Task<IActionResult> Viewpackage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packages = await _context.Packages
                .FirstOrDefaultAsync(m => m.PackagesID == id);
            if (packages == null)
            {
                return NotFound();
            }
            TempData["amount1"] = packages.Amount;
            TempData["packagename"] = packages.Name;
            TempData["packageid"] = packages.PackagesID;
            HttpContext.Session.SetInt32(SessionAmt1, packages.Amount);
            return View(packages);
        }

        
        [Authorize]
        public IActionResult Checkout()
        {
           // int amt =Int32.Parse(ViewBag.Amount);
           
            return View();
        }

        // POST: AllPackage/Edit/5
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

        // GET: AllPackage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AllPackage/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
