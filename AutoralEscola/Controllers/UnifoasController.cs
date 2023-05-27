using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escolar.Data;

namespace AutoralEscola.Controllers
{
    public class UnifoasController : Controller
    {
        private readonly EscolarContext _context;

        public UnifoasController(EscolarContext context)
        {
            _context = context;
        }

        // GET: Unifoas
        public async Task<IActionResult> Index()
        {
              return _context.Unifoa != null ? 
                          View(await _context.Unifoa.ToListAsync()) :
                          Problem("Entity set 'EscolarContext.Unifoa'  is null.");
        }

        // GET: Unifoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Unifoa == null)
            {
                return NotFound();
            }

            var unifoa = await _context.Unifoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unifoa == null)
            {
                return NotFound();
            }

            return View(unifoa);
        }

        // GET: Unifoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unifoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Content,MatriculaId,AlunoId")] Unifoa unifoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unifoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unifoa);
        }

        // GET: Unifoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Unifoa == null)
            {
                return NotFound();
            }

            var unifoa = await _context.Unifoa.FindAsync(id);
            if (unifoa == null)
            {
                return NotFound();
            }
            return View(unifoa);
        }

        // POST: Unifoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Content,MatriculaId,AlunoId")] Unifoa unifoa)
        {
            if (id != unifoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unifoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnifoaExists(unifoa.Id))
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
            return View(unifoa);
        }

        // GET: Unifoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Unifoa == null)
            {
                return NotFound();
            }

            var unifoa = await _context.Unifoa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unifoa == null)
            {
                return NotFound();
            }

            return View(unifoa);
        }

        // POST: Unifoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Unifoa == null)
            {
                return Problem("Entity set 'EscolarContext.Unifoa'  is null.");
            }
            var unifoa = await _context.Unifoa.FindAsync(id);
            if (unifoa != null)
            {
                _context.Unifoa.Remove(unifoa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnifoaExists(int id)
        {
          return (_context.Unifoa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
