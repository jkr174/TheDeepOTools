using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheDeepOTools.Areas.Identity.Data;
using TheDeepOTools.Data;
using TheDeepOTools.Models;

namespace TheDeepOTools.Controllers
{
    public class RepairTicketsController : Controller
    {
        private readonly TheDeepOToolsContext _context;

        public RepairTicketsController(TheDeepOToolsContext context)
        {
            _context = context;
        }

        // GET: RepairTickets
        public async Task<IActionResult> Index()
        {
            var theDeepOToolsContext = _context.RepairTicket.Include(r => r.Owner);
            return View(await theDeepOToolsContext.ToListAsync());
        }

        // GET: RepairTickets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTicket = await _context.RepairTicket
                .Include(r => r.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairTicket == null)
            {
                return NotFound();
            }

            return View(repairTicket);
        }

        // GET: RepairTickets/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            return View();
        }

        // POST: RepairTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,TicketState,OwnerId")] RepairTicket repairTicket)
        {
            if (ModelState.IsValid)
            {
                repairTicket.Id = Guid.NewGuid();
                _context.Add(repairTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", repairTicket.OwnerId);
            return View(repairTicket);
        }

        // GET: RepairTickets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTicket = await _context.RepairTicket.FindAsync(id);
            if (repairTicket == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", repairTicket.OwnerId);
            return View(repairTicket);
        }

        // POST: RepairTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,TicketState,OwnerId")] RepairTicket repairTicket)
        {
            if (id != repairTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repairTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairTicketExists(repairTicket.Id))
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
            ViewData["OwnerId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", repairTicket.OwnerId);
            return View(repairTicket);
        }

        // GET: RepairTickets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTicket = await _context.RepairTicket
                .Include(r => r.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairTicket == null)
            {
                return NotFound();
            }

            return View(repairTicket);
        }

        // POST: RepairTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var repairTicket = await _context.RepairTicket.FindAsync(id);
            _context.RepairTicket.Remove(repairTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairTicketExists(Guid id)
        {
            return _context.RepairTicket.Any(e => e.Id == id);
        }
    }
}
