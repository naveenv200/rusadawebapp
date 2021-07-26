using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RusadaAssignment.Data;
using RusadaAssignment.Models;

namespace RusadaAssignment.Controllers
{
    public class RusadaWebAppsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RusadaWebAppsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RusadaWebApps
        public async Task<IActionResult> Index()
        {
            return View(await _context.RusadaWebApp.ToListAsync());
        }

        // GET: RusadaWebApps/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // GET: RusadaWebApps/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPharse)
        {
            return View("Index",await _context.RusadaWebApp.Where(a => a.Make.Contains(SearchPharse) || 
            a.Model.Contains(SearchPharse) || a.Registration.Contains(SearchPharse)).ToListAsync()); ;
        }

        // GET: RusadaWebApps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rusadaWebApp = await _context.RusadaWebApp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rusadaWebApp == null)
            {
                return NotFound();
            }

            return View(rusadaWebApp);
        }

        // GET: RusadaWebApps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RusadaWebApps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Make,Model,Registration,Location,dateTime")] RusadaWebApp rusadaWebApp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rusadaWebApp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rusadaWebApp);
        }

        // GET: RusadaWebApps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rusadaWebApp = await _context.RusadaWebApp.FindAsync(id);
            if (rusadaWebApp == null)
            {
                return NotFound();
            }
            return View(rusadaWebApp);
        }

        // POST: RusadaWebApps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,Registration,Location,dateTime")] RusadaWebApp rusadaWebApp)
        {
            if (id != rusadaWebApp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rusadaWebApp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RusadaWebAppExists(rusadaWebApp.Id))
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
            return View(rusadaWebApp);
        }

        // GET: RusadaWebApps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rusadaWebApp = await _context.RusadaWebApp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rusadaWebApp == null)
            {
                return NotFound();
            }

            return View(rusadaWebApp);
        }

        // POST: RusadaWebApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rusadaWebApp = await _context.RusadaWebApp.FindAsync(id);
            _context.RusadaWebApp.Remove(rusadaWebApp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RusadaWebAppExists(int id)
        {
            return _context.RusadaWebApp.Any(e => e.Id == id);
        }
    }
}
