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
    public class PersoaneController : Controller
    {
        private readonly ProiectContext _context;

        public PersoaneController(ProiectContext context)
        {
            _context = context;
        }

        // GET: Persoane
        public async Task<IActionResult> Index()
        {
              return View(await _context.Persoana.ToListAsync());
        }

        // GET: Persoane/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Persoana == null)
            {
                return NotFound();
            }

            var persoana = await _context.Persoana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persoana == null)
            {
                return NotFound();
            }

            return View(persoana);
        }

        // GET: Persoane/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persoane/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Prenume,Sex")] Persoana persoana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persoana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(persoana);
        }

        // GET: Persoane/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Persoana == null)
            {
                return NotFound();
            }

            var persoana = await _context.Persoana.FindAsync(id);
            if (persoana == null)
            {
                return NotFound();
            }
            return View(persoana);
        }

        // POST: Persoane/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Prenume,Sex")] Persoana persoana)
        {
            if (id != persoana.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persoana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersoanaExists(persoana.Id))
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
            return View(persoana);
        }

        // GET: Persoane/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Persoana == null)
            {
                return NotFound();
            }

            var persoana = await _context.Persoana
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persoana == null)
            {
                return NotFound();
            }

            return View(persoana);
        }

        // POST: Persoane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Persoana == null)
            {
                return Problem("Entity set 'ProiectContext.Persoana'  is null.");
            }
            var persoana = await _context.Persoana.FindAsync(id);
            if (persoana != null)
            {
                _context.Persoana.Remove(persoana);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersoanaExists(int id)
        {
          return _context.Persoana.Any(e => e.Id == id);
        }
    }
}
