using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prularia.Models;
using Prularia.Models.EntityFrameworkModels;

namespace Prularia.Controllers
{
    public class AdressensController : Controller
    {
        private readonly PrulariaContext _context;

        public AdressensController(PrulariaContext context)
        {
            _context = context;
        }

        // GET: Adressens
        public async Task<IActionResult> Index()
        {
            var prulariaContext = _context.Adressens.Include(a => a.Plaats);
            return View(await prulariaContext.ToListAsync());
        }

        // GET: Adressens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adressen = await _context.Adressens
                .Include(a => a.Plaats)
                .FirstOrDefaultAsync(m => m.AdresId == id);
            if (adressen == null)
            {
                return NotFound();
            }

            return View(adressen);
        }

        // GET: Adressens/Create
        public IActionResult Create()
        {
            ViewData["PlaatsId"] = new SelectList(_context.Plaatsens, "PlaatsId", "PlaatsId");
            return View();
        }

        // POST: Adressens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdresId,Straat,HuisNummer,Bus,PlaatsId,Actief")] Adressen adressen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adressen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlaatsId"] = new SelectList(_context.Plaatsens, "PlaatsId", "PlaatsId", adressen.PlaatsId);
            return View(adressen);
        }

        // GET: Adressens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adressen = await _context.Adressens.FindAsync(id);
            if (adressen == null)
            {
                return NotFound();
            }
            ViewData["PlaatsId"] = new SelectList(_context.Plaatsens, "PlaatsId", "PlaatsId", adressen.PlaatsId);
            return View(adressen);
        }

        // POST: Adressens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdresId,Straat,HuisNummer,Bus,PlaatsId,Actief")] Adressen adressen)
        {
            if (id != adressen.AdresId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adressen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdressenExists(adressen.AdresId))
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
            ViewData["PlaatsId"] = new SelectList(_context.Plaatsens, "PlaatsId", "PlaatsId", adressen.PlaatsId);
            return View(adressen);
        }

        // GET: Adressens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adressen = await _context.Adressens
                .Include(a => a.Plaats)
                .FirstOrDefaultAsync(m => m.AdresId == id);
            if (adressen == null)
            {
                return NotFound();
            }

            return View(adressen);
        }

        // POST: Adressens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adressen = await _context.Adressens.FindAsync(id);
            if (adressen != null)
            {
                _context.Adressens.Remove(adressen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdressenExists(int id)
        {
            return _context.Adressens.Any(e => e.AdresId == id);
        }
    }
}
