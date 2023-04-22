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
    public class pedidosController : Controller
    {
        private readonly RestauranteDBContext _context;

        public pedidosController(RestauranteDBContext context)
        {
            _context = context;
        }

        // GET: pedidos
        public async Task<IActionResult> Index()
        {
              return _context.Pedidos != null ? 
                          View(await _context.Pedidos.ToListAsync()) :
                          Problem("Entity set 'RestauranteDBContext.Pedidos'  is null.");
        }

        // GET: pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedidos = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedidos == null)
            {
                return NotFound();
            }

            return View(pedidos);
        }

        // GET: pedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,MotoristaId,ClienteId,PlatoId,Cantidad,Precio")] pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedidos);
        }

        // GET: pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedidos = await _context.Pedidos.FindAsync(id);
            if (pedidos == null)
            {
                return NotFound();
            }
            return View(pedidos);
        }

        // POST: pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,MotoristaId,ClienteId,PlatoId,Cantidad,Precio")] pedidos pedidos)
        {
            if (id != pedidos.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!pedidosExists(pedidos.PedidoId))
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
            return View(pedidos);
        }

        // GET: pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedidos = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedidos == null)
            {
                return NotFound();
            }

            return View(pedidos);
        }

        // POST: pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedidos == null)
            {
                return Problem("Entity set 'RestauranteDBContext.Pedidos'  is null.");
            }
            var pedidos = await _context.Pedidos.FindAsync(id);
            if (pedidos != null)
            {
                _context.Pedidos.Remove(pedidos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool pedidosExists(int id)
        {
          return (_context.Pedidos?.Any(e => e.PedidoId == id)).GetValueOrDefault();
        }
    }
}
