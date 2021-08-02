using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheDeepOTools.Data;
using TheDeepOTools.Models;

namespace TheDeepOTools.Controllers
{
    public class RepairTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepairTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RepairTickets
        public async Task<IActionResult> Index(string ticketState, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> stateQuery = from r in _context.RepairTicket
                                            orderby r.TicketState
                                            select r.TicketState;

            var repairTickets = from r in _context.RepairTicket
                                select r;

            if (!string.IsNullOrEmpty(searchString))
            {
                repairTickets = repairTickets.Where(
                    s => s.Title.Contains(searchString)
                    || s.TicketState.Contains(searchString)
                    || s.Owner.Contains(searchString)
                    || s.OwnerId.Contains(searchString)
                    );
            }

            if (!string.IsNullOrEmpty(ticketState))
            {
                repairTickets = repairTickets.Where(
                    x => x.TicketState == ticketState
                    );
            }

            var repairTicketVM = new RepairTicketStateViewModel
            {
                TicketState = new SelectList(await stateQuery.Distinct().ToListAsync()),
                RepairTickets = await repairTickets.ToListAsync()
            };

            return View(repairTicketVM);
        }

        // GET: RepairTickets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTicket = await _context.RepairTicket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairTicket == null)
            {
                return NotFound();
            }

            return View(repairTicket);
        }

        // GET: RepairTickets/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: RepairTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,TicketState,OwnerId,Owner")] RepairTicket repairTicket)
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
        [Authorize(Roles = "Admin")]
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
            return View(repairTicket);
        }

        // POST: RepairTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,TicketState,OwnerId,Owner")] RepairTicket repairTicket)
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTicket = await _context.RepairTicket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairTicket == null)
            {
                return NotFound();
            }

            return View(repairTicket);
        }

        // POST: RepairTickets/Delete/5
        [Authorize(Roles = "Admin")]
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
