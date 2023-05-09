using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XSJC.AppMVC.Models;

namespace XSJC.AppMVC.Controllers
{
    public class BicicletasController : Controller
    {
        private readonly XjscContext _context;

        public BicicletasController(XjscContext context)
        {
            _context = context;
        }

        // GET: Bicicletas
        public async Task<IActionResult> Index()
        {
              return _context.Bicicletas != null ? 
                          View(await _context.Bicicletas.ToListAsync()) :
                          Problem("Entity set 'XjscContext.Bicicletas'  is null.");
        }

        // GET: Bicicletas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bicicletas == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicletas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }

        // GET: Bicicletas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bicicletas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Tipo,DescripcionDelProblema")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bicicleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bicicleta);
        }

        // GET: Bicicletas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bicicletas == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicletas.FindAsync(id);
            if (bicicleta == null)
            {
                return NotFound();
            }
            return View(bicicleta);
        }

        // POST: Bicicletas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Tipo,DescripcionDelProblema")] Bicicleta bicicleta)
        {
            if (id != bicicleta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bicicleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BicicletaExists(bicicleta.Id))
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
            return View(bicicleta);
        }

        // GET: Bicicletas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bicicletas == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicletas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }

        // POST: Bicicletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bicicletas == null)
            {
                return Problem("Entity set 'XjscContext.Bicicletas'  is null.");
            }
            var bicicleta = await _context.Bicicletas.FindAsync(id);
            if (bicicleta != null)
            {
                _context.Bicicletas.Remove(bicicleta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BicicletaExists(int id)
        {
          return (_context.Bicicletas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
