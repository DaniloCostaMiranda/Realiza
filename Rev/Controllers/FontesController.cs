using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rev.Data;
using Rev.Models;

namespace Rev.Controllers
{
    public class FontesController : Controller
    {
        private readonly RevContext _context;

        public FontesController(RevContext context)
        {
            _context = context;
        }

        // GET: Fontes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fonte.ToListAsync());
        }

        // GET: Fontes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fonte = await _context.Fonte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fonte == null)
            {
                return NotFound();
            }

            return View(fonte);
        }

        // GET: Fontes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fontes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Fonte fonte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fonte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fonte);
        }

        // GET: Fontes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fonte = await _context.Fonte.FindAsync(id);
            if (fonte == null)
            {
                return NotFound();
            }
            return View(fonte);
        }

        // POST: Fontes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Fonte fonte)
        {
            if (id != fonte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fonte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FonteExists(fonte.Id))
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
            return View(fonte);
        }

        // GET: Fontes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fonte = await _context.Fonte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fonte == null)
            {
                return NotFound();
            }

            return View(fonte);
        }

        // POST: Fontes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fonte = await _context.Fonte.FindAsync(id);
            _context.Fonte.Remove(fonte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FonteExists(int id)
        {
            return _context.Fonte.Any(e => e.Id == id);
        }
    }
}
