using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Controllers
{
    public class SarciniController : Controller
    {
        private readonly ProiectContext _context;

        public SarciniController(ProiectContext context)
        {
            _context = context;
        }

        // GET: Sarcini
        public async Task<IActionResult> Index()
        {
            var proiectContext = _context.Sarcina.Include(s => s.persoanaObj);
            return View(await proiectContext.ToListAsync());
        }

        // GET: Sarcini/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sarcina == null)
            {
                return NotFound();
            }

            var sarcina = await _context.Sarcina
                .Include(s => s.persoanaObj)
                .FirstOrDefaultAsync(m => m.id == id);
            if (sarcina == null)
            {
                return NotFound();
            }

            return View(sarcina);
        }

        // GET: Sarcini/Create
        public IActionResult Create()
        {
            ViewData["PersoanaId"] = new SelectList(_context.Persoana, "Id", "Nume");
            return View();
        }

        // POST: Sarcini/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Denumire,Descriere,Prioritate,TipSarcina,OreEstimate,PersoanaId")] Sarcina sarcina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sarcina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersoanaId"] = new SelectList(_context.Persoana, "Id", "Nume", sarcina.PersoanaId);
            return View(sarcina);
        }

        // GET: Sarcini/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sarcina == null)
            {
                return NotFound();
            }

            var sarcina = await _context.Sarcina.FindAsync(id);
            if (sarcina == null)
            {
                return NotFound();
            }
            ViewData["PersoanaId"] = new SelectList(_context.Persoana, "Id", "Nume", sarcina.PersoanaId);
            return View(sarcina);
        }

        // POST: Sarcini/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Denumire,Descriere,Prioritate,TipSarcina,OreEstimate,PersoanaId")] Sarcina sarcina)
        {
            if (id != sarcina.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sarcina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SarcinaExists(sarcina.id))
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
            ViewData["PersoanaId"] = new SelectList(_context.Persoana, "Id", "Nume", sarcina.PersoanaId);
            return View(sarcina);
        }

        // GET: Sarcini/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sarcina == null)
            {
                return NotFound();
            }

            var sarcina = await _context.Sarcina
                .Include(s => s.persoanaObj)
                .FirstOrDefaultAsync(m => m.id == id);
            if (sarcina == null)
            {
                return NotFound();
            }

            return View(sarcina);
        }

        // POST: Sarcini/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sarcina == null)
            {
                return Problem("Entity set 'ProiectContext.Sarcina'  is null.");
            }
            var sarcina = await _context.Sarcina.FindAsync(id);
            if (sarcina != null)
            {
                _context.Sarcina.Remove(sarcina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SarcinaExists(int id)
        {
          return _context.Sarcina.Any(e => e.id == id);
        }
    }
}
