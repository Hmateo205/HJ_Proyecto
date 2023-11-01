using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HJ_Proyecto.Data;
using HJ_Proyecto.Models;

namespace HJ_Proyecto.Controllers
{
    public class IngresarsController : Controller
    {
        private readonly HJ_ProyectoContext _context;

        public IngresarsController(HJ_ProyectoContext context)
        {
            _context = context;
        }

        // GET: Ingresars
        public async Task<IActionResult> Index()
        {
              return _context.Ingresar != null ? 
                          View(await _context.Ingresar.ToListAsync()) :
                          Problem("Entity set 'HJ_ProyectoContext.Ingresar'  is null.");
        }

        // GET: Ingresars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ingresar == null)
            {
                return NotFound();
            }

            var ingresar = await _context.Ingresar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingresar == null)
            {
                return NotFound();
            }

            return View(ingresar);
        }

        // GET: Ingresars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingresars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Email")] Ingresar ingresar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingresar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingresar);
        }

        // GET: Ingresars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ingresar == null)
            {
                return NotFound();
            }

            var ingresar = await _context.Ingresar.FindAsync(id);
            if (ingresar == null)
            {
                return NotFound();
            }
            return View(ingresar);
        }

        // POST: Ingresars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Email")] Ingresar ingresar)
        {
            if (id != ingresar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingresar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngresarExists(ingresar.Id))
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
            return View(ingresar);
        }

        // GET: Ingresars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ingresar == null)
            {
                return NotFound();
            }

            var ingresar = await _context.Ingresar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingresar == null)
            {
                return NotFound();
            }

            return View(ingresar);
        }

        // POST: Ingresars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ingresar == null)
            {
                return Problem("Entity set 'HJ_ProyectoContext.Ingresar'  is null.");
            }
            var ingresar = await _context.Ingresar.FindAsync(id);
            if (ingresar != null)
            {
                _context.Ingresar.Remove(ingresar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngresarExists(int id)
        {
          return (_context.Ingresar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
