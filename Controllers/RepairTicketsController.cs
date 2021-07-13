using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheDeepOWebApp.Data;
using TheDeepOWebApp.Models;

namespace TheDeepOWebApp.Controllers
{
    public class RepairTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepairTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RepairTickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.RepairTickets.ToListAsync());
        }

        // GET: RepairTickets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTicket = await _context.RepairTickets
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
            return View();
        }

        // POST: RepairTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,State,OwnerId")] RepairTicket repairTicket)
        {
            if (ModelState.IsValid)
            {
                repairTicket.Id = Guid.NewGuid();
                _context.Add(repairTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repairTicket);
        }

        // GET: RepairTickets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTicket = await _context.RepairTickets.FindAsync(id);
            if (repairTicket == null)
            {
                return NotFound();
            }
            return View(repairTicket);
        }

        // POST: RepairTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,State,OwnerId")] RepairTicket repairTicket)
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
            return View(repairTicket);
        }

        // GET: RepairTickets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTicket = await _context.RepairTickets
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
            var repairTicket = await _context.RepairTickets.FindAsync(id);
            _context.RepairTickets.Remove(repairTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairTicketExists(Guid id)
        {
            return _context.RepairTickets.Any(e => e.Id == id);
        }
    }
}
