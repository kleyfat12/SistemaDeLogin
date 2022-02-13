using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeLogin.Models;
using SistemaDeLogin.MyDbContext;

namespace SistemaDeLogin.Controllers
{
    [Authorize]
    public class TareasController : Controller
    {
        private readonly MyContext _context;
        public TareasController(MyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tareas.Where(t => t.UserName == User.Identity.Name).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tareas
                .FirstOrDefaultAsync(m => m.TareaID == id);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TareaID,Descripcion,Realizada")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                tarea.UserName = User.Identity.Name;
                _context.Add(tarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarea);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TareaID,Descripcion,Realizada")] Tarea tarea)
        {
            if (id != tarea.TareaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tarea.UserName = User.Identity.Name;
                    _context.Update(tarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TareaExists(tarea.TareaID))
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
            return View(tarea);
        }

        // GET: Tareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarea = await _context.Tareas
                .FirstOrDefaultAsync(m => m.TareaID == id);
            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TareaExists(int id)
        {
            return _context.Tareas.Any(e => e.TareaID == id);
        }
    }
}
