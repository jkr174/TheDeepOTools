using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheDeepOTools.Data;
using TheDeepOTools.Models;

namespace TheDeepOTools.Controllers
{
    public class MaintaincesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaintaincesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Maintainces
        public async Task<IActionResult> Index()
        {
            return View(await _context.Maintaince.ToListAsync());
        }

        // GET: Maintainces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintaince = await _context.Maintaince
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (maintaince == null)
            {
                return NotFound();
            }

            return View(maintaince);
        }

        // GET: Maintainces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Maintainces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemID,ItemIdentifier,ItemName,Description,Category,Subcategory,ServiceHrs,TotalHrs,StartTime,StopTime,IsInService,NeedsMaintaince")] Maintaince maintaince)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maintaince);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maintaince);
        }

        // GET: Maintainces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintaince = await _context.Maintaince.FindAsync(id);
            if (maintaince == null)
            {
                return NotFound();
            }
            return View(maintaince);
        }

        // POST: Maintainces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemID,ItemIdentifier,ItemName,Description,Category,Subcategory,ServiceHrs,TotalHrs,StartTime,StopTime,IsInService,NeedsMaintaince")] Maintaince maintaince)
        {
            if (id != maintaince.ItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maintaince);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintainceExists(maintaince.ItemID))
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
            return View(maintaince);
        }

        // GET: Maintainces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintaince = await _context.Maintaince
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (maintaince == null)
            {
                return NotFound();
            }

            return View(maintaince);
        }

        // POST: Maintainces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maintaince = await _context.Maintaince.FindAsync(id);
            _context.Maintaince.Remove(maintaince);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaintainceExists(int id)
        {
            return _context.Maintaince.Any(e => e.ItemID == id);
        }
    }
}
