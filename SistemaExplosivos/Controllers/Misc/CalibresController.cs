using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaExplosivos.Data;
using SistemaExplosivos.Entities.Miscelaneos;

namespace SistemaExplosivos.Controllers.Misc
{
    public class CalibresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalibresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Calibres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Calibres.ToListAsync());
        }

        // GET: Calibres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calibre = await _context.Calibres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calibre == null)
            {
                return NotFound();
            }

            return View(calibre);
        }

        // GET: Calibres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calibres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Id")] Calibre calibre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calibre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calibre);
        }

        // GET: Calibres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calibre = await _context.Calibres.FindAsync(id);
            if (calibre == null)
            {
                return NotFound();
            }
            return View(calibre);
        }

        // POST: Calibres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nombre,Id")] Calibre calibre)
        {
            if (id != calibre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calibre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalibreExists(calibre.Id))
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
            return View(calibre);
        }

        // GET: Calibres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calibre = await _context.Calibres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calibre == null)
            {
                return NotFound();
            }

            return View(calibre);
        }

        // POST: Calibres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calibre = await _context.Calibres.FindAsync(id);
            if (calibre != null)
            {
                _context.Calibres.Remove(calibre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalibreExists(int id)
        {
            return _context.Calibres.Any(e => e.Id == id);
        }
    }
}
