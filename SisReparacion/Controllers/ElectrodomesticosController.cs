

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaReparaciones.Models;

namespace SistemaReparaciones.Controllers
{
    public class ElectrodomesticosController : Controller
    {
        private readonly AplicacionDbContext _context;

        public ElectrodomesticosController(
            AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Electrodomesticos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var electrodomestico = await _context.Electrodomesticos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (electrodomestico == null) return NotFound();

            return View(electrodomestico);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            Electrodomestico electrodomestico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(electrodomestico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(electrodomestico);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var electrodomestico =
                await _context.Electrodomesticos.FindAsync(id);

            if (electrodomestico == null) return NotFound();

            return View(electrodomestico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, Electrodomestico electrodomestico)
        {
            if (id != electrodomestico.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(electrodomestico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(electrodomestico);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var electrodomestico =
                await _context.Electrodomesticos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (electrodomestico == null) return NotFound();

            return View(electrodomestico);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var electrodomestico =
                await _context.Electrodomesticos.FindAsync(id);

            if (electrodomestico != null)
            {
                _context.Electrodomesticos.Remove(electrodomestico);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}