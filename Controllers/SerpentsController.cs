using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myown.Models;
using myown.Context;

namespace myown.Controllers
{
    public class SerpentsController : Controller
    {
        private readonly SerpentContext _context;

        public SerpentsController(SerpentContext context)
        {
            _context = context;
        }

        // GET: Serpents
        public async Task<IActionResult> Index()
        {
            // int len = _context.Serpent.Count();
            // for (int i = 1; i <= len; i++)
            // {
            //     var serp = await _context.Serpent
            //     .FirstOrDefaultAsync(m => m.Id == i);
            //     string popName = serp.PopularName;
            //     serp.PopularName = char.ToUpper(popName[0]) + popName.Substring(1);
            //     _context.Update(serp);
            // }
            return View(await _context.Serpent.OrderBy(s => s.PopularName).ToListAsync());
        }

        // GET: Serpents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Serpent == null)
            {
                return NotFound();
            }

            var serpent = await _context.Serpent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serpent == null)
            {
                return NotFound();
            }

            return View(serpent);
        }

        // GET: Serpents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Serpents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PopularName,CientificName,FamilyType")] Serpent serpent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serpent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serpent);
        }
        
        // GET: Serpents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Serpent == null)
            {
                return NotFound();
            }

            var serpent = await _context.Serpent.FindAsync(id);
            if (serpent == null)
            {
                return NotFound();
            }
            return View(serpent);
        }

        // POST: Serpents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PopularName,CientificName,FamilyType")] Serpent serpent)
        {
            if (id != serpent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serpent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SerpentExists(serpent.Id))
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
            return View(serpent);
        }

        // GET: Serpents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Serpent == null)
            {
                return NotFound();
            }

            var serpent = await _context.Serpent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serpent == null)
            {
                return NotFound();
            }

            return View(serpent);
        }

        // POST: Serpents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Serpent == null)
            {
                return Problem("Entity set 'SerpentContext.Serpent'  is null.");
            }
            var serpent = await _context.Serpent.FindAsync(id);
            if (serpent != null)
            {
                _context.Serpent.Remove(serpent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SerpentExists(int id)
        {
          return _context.Serpent.Any(e => e.Id == id);
        }
    }
}
