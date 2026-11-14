

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaReparaciones.Models;

namespace SistemaReparaciones.Controllers
{
    public class TecnicosController : Controller
    {
        private readonly AplicacionDbContext _context;

        public TecnicosController(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tecnicos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var tecnico = await _context.Tecnicos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (tecnico == null) return NotFound();

            return View(tecnico);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tecnico);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tecnico = await _context.Tecnicos.FindAsync(id);

            if (tecnico == null) return NotFound();

            return View(tecnico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tecnico tecnico)
        {
            if (id != tecnico.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(tecnico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tecnico);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tecnico = await _context.Tecnicos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (tecnico == null) return NotFound();

            return View(tecnico);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tecnico = await _context.Tecnicos.FindAsync(id);

            if (tecnico != null)
            {
                _context.Tecnicos.Remove(tecnico);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

