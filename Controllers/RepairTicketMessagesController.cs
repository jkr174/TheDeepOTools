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
    public class RepairTicketMessagesController : Controller
    {
        private readonly TheDeepOToolsContext _context;

        public RepairTicketMessagesController(TheDeepOToolsContext context)
        {
            _context = context;
        }

        // GET: RepairTicketMessages
        public async Task<IActionResult> Index()
        {
            var theDeepOToolsContext = _context.RepairTicketMessage.Include(r => r.Owner).Include(r => r.Ticket);
            return View(await theDeepOToolsContext.ToListAsync());
        }

        // GET: RepairTicketMessages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTicketMessage = await _context.RepairTicketMessage
                .Include(r => r.Owner)
                .Include(r => r.Ticket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairTicketMessage == null)
            {
                return NotFound();
            }

            return View(repairTicketMessage);
        }

        // GET: RepairTicketMessages/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            ViewData["TicketId"] = new SelectList(_context.RepairTicket, "Id", "Id");
            return View();
        }

        // POST: RepairTicketMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Message,TicketId,OwnerId")] RepairTicketMessage repairTicketMessage)
        {
            if (ModelState.IsValid)
            {
                repairTicketMessage.Id = Guid.NewGuid();
                _context.Add(repairTicketMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", repairTicketMessage.OwnerId);
            ViewData["TicketId"] = new SelectList(_context.RepairTicket, "Id", "Id", repairTicketMessage.TicketId);
            return View(repairTicketMessage);
        }

        // GET: RepairTicketMessages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTicketMessage = await _context.RepairTicketMessage.FindAsync(id);
            if (repairTicketMessage == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", repairTicketMessage.OwnerId);
            ViewData["TicketId"] = new SelectList(_context.RepairTicket, "Id", "Id", repairTicketMessage.TicketId);
            return View(repairTicketMessage);
        }

        // POST: RepairTicketMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Message,TicketId,OwnerId")] RepairTicketMessage repairTicketMessage)
        {
            if (id != repairTicketMessage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repairTicketMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairTicketMessageExists(repairTicketMessage.Id))
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
            ViewData["OwnerId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", repairTicketMessage.OwnerId);
            ViewData["TicketId"] = new SelectList(_context.RepairTicket, "Id", "Id", repairTicketMessage.TicketId);
            return View(repairTicketMessage);
        }

        // GET: RepairTicketMessages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairTicketMessage = await _context.RepairTicketMessage
                .Include(r => r.Owner)
                .Include(r => r.Ticket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairTicketMessage == null)
            {
                return NotFound();
            }

            return View(repairTicketMessage);
        }

        // POST: RepairTicketMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var repairTicketMessage = await _context.RepairTicketMessage.FindAsync(id);
            _context.RepairTicketMessage.Remove(repairTicketMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairTicketMessageExists(Guid id)
        {
            return _context.RepairTicketMessage.Any(e => e.Id == id);
        }
    }
}
