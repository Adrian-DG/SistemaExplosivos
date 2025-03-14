using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaExplosivos.Data;
using SistemaExplosivos.Entities.Miscelaneos;

namespace SistemaExplosivos.Controllers.Misc;

    public class SubTiposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubTiposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubTipoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubTipos.Include(s => s.Tipo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SubTipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTipo = await _context.SubTipos
                .Include(s => s.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subTipo == null)
            {
                return NotFound();
            }

            return View(subTipo);
        }

        // GET: SubTipoes/Create
        public IActionResult Create()
        {
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Id");
            return View();
        }

        // POST: SubTipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoId,Nombre,Id")] SubTipo subTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Id", subTipo.TipoId);
            return View(subTipo);
        }

        // GET: SubTipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTipo = await _context.SubTipos.FindAsync(id);
            if (subTipo == null)
            {
                return NotFound();
            }
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Id", subTipo.TipoId);
            return View(subTipo);
        }

        // POST: SubTipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoId,Nombre,Id")] SubTipo subTipo)
        {
            if (id != subTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubTipoExists(subTipo.Id))
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
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Id", subTipo.TipoId);
            return View(subTipo);
        }

        // GET: SubTipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subTipo = await _context.SubTipos
                .Include(s => s.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subTipo == null)
            {
                return NotFound();
            }

            return View(subTipo);
        }

        // POST: SubTipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subTipo = await _context.SubTipos.FindAsync(id);
            if (subTipo != null)
            {
                _context.SubTipos.Remove(subTipo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubTipoExists(int id)
        {
            return _context.SubTipos.Any(e => e.Id == id);
        }
    }
