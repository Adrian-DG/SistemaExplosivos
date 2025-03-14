using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaExplosivos.Data;
using SistemaExplosivos.Entities.Organizacion;

namespace SistemaExplosivos.Controllers.Organizacion
{
    public class TitularesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TitularesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Titulares
        public async Task<IActionResult> Index()
        {
            return View(await _context.Titulares.ToListAsync());
        }

        // GET: Titulares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titular = await _context.Titulares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (titular == null)
            {
                return NotFound();
            }

            return View(titular);
        }

        // GET: Titulares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titulares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cedula,Nombre,Apellido,Telefono,Id")] Titular titular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(titular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(titular);
        }

        // GET: Titulares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titular = await _context.Titulares.FindAsync(id);
            if (titular == null)
            {
                return NotFound();
            }
            return View(titular);
        }

        // POST: Titulares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cedula,Nombre,Apellido,Telefono,Id")] Titular titular)
        {
            if (id != titular.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(titular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitularExists(titular.Id))
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
            return View(titular);
        }

        // GET: Titulares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titular = await _context.Titulares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (titular == null)
            {
                return NotFound();
            }

            return View(titular);
        }

        // POST: Titulares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var titular = await _context.Titulares.FindAsync(id);
            if (titular != null)
            {
                _context.Titulares.Remove(titular);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitularExists(int id)
        {
            return _context.Titulares.Any(e => e.Id == id);
        }
    }
}
