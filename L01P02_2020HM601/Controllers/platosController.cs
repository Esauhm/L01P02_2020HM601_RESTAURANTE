using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L01P02_2020HM601.Models;

namespace L01P02_2020HM601.Controllers
{
    public class platosController : Controller
    {
        private readonly RestauranteDBContext _context;

        public platosController(RestauranteDBContext context)
        {
            _context = context;
        }

        // GET: platos
        public async Task<IActionResult> Index()
        {
              return _context.Platos != null ? 
                          View(await _context.Platos.ToListAsync()) :
                          Problem("Entity set 'RestauranteDBContext.Platos'  is null.");
        }

        // GET: platos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Platos == null)
            {
                return NotFound();
            }

            var platos = await _context.Platos
                .FirstOrDefaultAsync(m => m.PlatoId == id);
            if (platos == null)
            {
                return NotFound();
            }

            return View(platos);
        }

        // GET: platos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: platos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlatoId,NombrePlato,Precio")] platos platos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(platos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(platos);
        }

        // GET: platos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Platos == null)
            {
                return NotFound();
            }

            var platos = await _context.Platos.FindAsync(id);
            if (platos == null)
            {
                return NotFound();
            }
            return View(platos);
        }

        // POST: platos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlatoId,NombrePlato,Precio")] platos platos)
        {
            if (id != platos.PlatoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(platos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!platosExists(platos.PlatoId))
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
            return View(platos);
        }

        // GET: platos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Platos == null)
            {
                return NotFound();
            }

            var platos = await _context.Platos
                .FirstOrDefaultAsync(m => m.PlatoId == id);
            if (platos == null)
            {
                return NotFound();
            }

            return View(platos);
        }

        // POST: platos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Platos == null)
            {
                return Problem("Entity set 'RestauranteDBContext.Platos'  is null.");
            }
            var platos = await _context.Platos.FindAsync(id);
            if (platos != null)
            {
                _context.Platos.Remove(platos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool platosExists(int id)
        {
          return (_context.Platos?.Any(e => e.PlatoId == id)).GetValueOrDefault();
        }
    }
}
