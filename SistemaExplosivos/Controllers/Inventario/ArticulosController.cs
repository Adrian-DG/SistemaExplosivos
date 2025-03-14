using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaExplosivos.Data;
using SistemaExplosivos.Entities.Inventario;

namespace SistemaExplosivos.Controllers.Inventario
{
    public class ArticulosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticulosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articulos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Articulos.Include(a => a.Calibre).Include(a => a.Marca).Include(a => a.Modelo).Include(a => a.SubTipo).Include(a => a.Tipo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Articulos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.Calibre)
                .Include(a => a.Marca)
                .Include(a => a.Modelo)
                .Include(a => a.SubTipo)
                .Include(a => a.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET: Articulos/Create
        public IActionResult Create()
        {
            ViewData["CalibreId"] = new SelectList(_context.Calibres, "Id", "Id");
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id");
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Id");
            ViewData["SubTipoId"] = new SelectList(_context.SubTipos, "Id", "Id");
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Id");
            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoId,SubTipoId,CalibreId,MarcaId,ModeloId,UsuarioId,FechaCreacion,FechaModificacion,Id")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CalibreId"] = new SelectList(_context.Calibres, "Id", "Id", articulo.CalibreId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", articulo.MarcaId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Id", articulo.ModeloId);
            ViewData["SubTipoId"] = new SelectList(_context.SubTipos, "Id", "Id", articulo.SubTipoId);
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Id", articulo.TipoId);
            return View(articulo);
        }

        // GET: Articulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            ViewData["CalibreId"] = new SelectList(_context.Calibres, "Id", "Id", articulo.CalibreId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", articulo.MarcaId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Id", articulo.ModeloId);
            ViewData["SubTipoId"] = new SelectList(_context.SubTipos, "Id", "Id", articulo.SubTipoId);
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Id", articulo.TipoId);
            return View(articulo);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoId,SubTipoId,CalibreId,MarcaId,ModeloId,UsuarioId,FechaCreacion,FechaModificacion,Id")] Articulo articulo)
        {
            if (id != articulo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticuloExists(articulo.Id))
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
            ViewData["CalibreId"] = new SelectList(_context.Calibres, "Id", "Id", articulo.CalibreId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Id", articulo.MarcaId);
            ViewData["ModeloId"] = new SelectList(_context.Modelos, "Id", "Id", articulo.ModeloId);
            ViewData["SubTipoId"] = new SelectList(_context.SubTipos, "Id", "Id", articulo.SubTipoId);
            ViewData["TipoId"] = new SelectList(_context.Tipos, "Id", "Id", articulo.TipoId);
            return View(articulo);
        }

        // GET: Articulos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.Calibre)
                .Include(a => a.Marca)
                .Include(a => a.Modelo)
                .Include(a => a.SubTipo)
                .Include(a => a.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.Id == id);
        }
    }
}
