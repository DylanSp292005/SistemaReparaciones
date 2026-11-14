

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaReparaciones.Models;

namespace SistemaReparaciones.Controllers
{
    public class ReparacionesController : Controller
    {
        private readonly AplicacionDbContext _context;

        public ReparacionesController(AplicacionDbContext context)
        {
            _context = context;
        }

        private void CargarListas(
            int? clienteId = null,
            int? tecnicoId = null,
            int? electrodomesticoId = null)
        {
            ViewBag.ClienteId = new SelectList(
                _context.Clientes, "Id", "Nombre", clienteId);

            ViewBag.TecnicoId = new SelectList(
                _context.Tecnicos, "Id", "Nombre", tecnicoId);

            ViewBag.ElectrodomesticoId = new SelectList(
                _context.Electrodomesticos,
                "Id", "Modelo", electrodomesticoId);
        }

        public async Task<IActionResult> Index()
        {
            var reparaciones = _context.Reparaciones
                .Include(r => r.Cliente)
                .Include(r => r.Tecnico)
                .Include(r => r.Electrodomestico);

            return View(await reparaciones.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var reparacion = await _context.Reparaciones
                .Include(r => r.Cliente)
                .Include(r => r.Tecnico)
                .Include(r => r.Electrodomestico)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reparacion == null) return NotFound();

            return View(reparacion);
        }

        public IActionResult Create()
        {
            CargarListas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reparacion reparacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reparacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            CargarListas(
                reparacion.ClienteId,
                reparacion.TecnicoId,
                reparacion.ElectrodomesticoId);

            return View(reparacion);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var reparacion = await _context.Reparaciones.FindAsync(id);

            if (reparacion == null) return NotFound();

            CargarListas(
                reparacion.ClienteId,
                reparacion.TecnicoId,
                reparacion.ElectrodomesticoId);

            return View(reparacion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, Reparacion reparacion)
        {
            if (id != reparacion.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(reparacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            CargarListas(
                reparacion.ClienteId,
                reparacion.TecnicoId,
                reparacion.ElectrodomesticoId);

            return View(reparacion);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var reparacion = await _context.Reparaciones
                .Include(r => r.Cliente)
                .Include(r => r.Tecnico)
                .Include(r => r.Electrodomestico)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (reparacion == null) return NotFound();

            return View(reparacion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reparacion = await _context.Reparaciones.FindAsync(id);

            if (reparacion != null)
            {
                _context.Reparaciones.Remove(reparacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}