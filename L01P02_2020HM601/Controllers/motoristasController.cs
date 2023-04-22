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
    public class motoristasController : Controller
    {
        private readonly RestauranteDBContext _context;

        public motoristasController(RestauranteDBContext context)
        {
            _context = context;
        }

        // GET: motoristas
        public async Task<IActionResult> Index()
        {
              return _context.Motoristas != null ? 
                          View(await _context.Motoristas.ToListAsync()) :
                          Problem("Entity set 'RestauranteDBContext.Motoristas'  is null.");
        }

        // GET: motoristas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Motoristas == null)
            {
                return NotFound();
            }

            var motoristas = await _context.Motoristas
                .FirstOrDefaultAsync(m => m.MotoristaId == id);
            if (motoristas == null)
            {
                return NotFound();
            }

            return View(motoristas);
        }

        // GET: motoristas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: motoristas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MotoristaId,NombreMotorista")] motoristas motoristas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motoristas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motoristas);
        }

        // GET: motoristas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Motoristas == null)
            {
                return NotFound();
            }

            var motoristas = await _context.Motoristas.FindAsync(id);
            if (motoristas == null)
            {
                return NotFound();
            }
            return View(motoristas);
        }

        // POST: motoristas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MotoristaId,NombreMotorista")] motoristas motoristas)
        {
            if (id != motoristas.MotoristaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motoristas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!motoristasExists(motoristas.MotoristaId))
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
            return View(motoristas);
        }

        // GET: motoristas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Motoristas == null)
            {
                return NotFound();
            }

            var motoristas = await _context.Motoristas
                .FirstOrDefaultAsync(m => m.MotoristaId == id);
            if (motoristas == null)
            {
                return NotFound();
            }

            return View(motoristas);
        }

        // POST: motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Motoristas == null)
            {
                return Problem("Entity set 'RestauranteDBContext.Motoristas'  is null.");
            }
            var motoristas = await _context.Motoristas.FindAsync(id);
            if (motoristas != null)
            {
                _context.Motoristas.Remove(motoristas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool motoristasExists(int id)
        {
          return (_context.Motoristas?.Any(e => e.MotoristaId == id)).GetValueOrDefault();
        }
    }
}
