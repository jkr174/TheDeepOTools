/* Name:    Jovany Romo
 * Date:    7/5/2021
 * Summary: Repair Ticket Controller used to load the repair ticket section of the web application
 * 
 * Input:   When the user loads into the Section of the website
 * Output:  Returns the appropiate Views for Repair Tickets
 */

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
        /// <summary>
        /// The method of how to load the Index page of Inventory. 
        /// </summary>
        /// <param name="searchString">
        /// The search string that the user types in the search bar.
        /// </param>
        /// <param name="ticketState">
        /// The selected ticket state the user chooses.
        /// </param>
        /// <returns>
        /// Returns a view of the Repair Tickets depending on if the user 
        /// chooses to search for something via a search string or a ticket state.
        /// </returns>
        [Authorize(Roles = "FloorAssociate")]
        [Authorize(Roles = "RepairTech")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Index(string ticketState, string searchString)
        {
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
        /// <summary>
        /// Used to get a detailed view of a ticket.
        /// </summary>
        /// <param name="id">Repair Ticket ID</param>
        /// <returns>
        /// Returns a view of the ticket's details.
        /// </returns>
        [Authorize(Roles = "FloorAssociate")]
        [Authorize(Roles = "RepairTech")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
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
        /// <summary>
        /// GET Method to craete an item
        /// </summary>
        /// <returns>
        /// Returns a new ViewModel of Repair Tickets to receive a list of items in inventory
        /// </returns>
        [Authorize(Roles = "FloorAssociate")]
        [Authorize(Roles = "RepairTech")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        [Authorize(Roles = "FloorAssoicate")]
        public IActionResult Create()
        {
            var itemList = new RepairTicketItemViewModel
            {
                ListItems = GetItems()
            };

            return View(itemList);
        }

        /// <summary>
        /// Method to get a list of items that are in inventory.
        /// </summary>
        /// <returns>
        /// Returns a list of items that are in inventory.
        /// </returns>
        [Authorize(Roles = "FloorAssociate")]
        [Authorize(Roles = "RepairTech")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        private IEnumerable<SelectListItem> GetItems()
        {
            List<SelectListItem> items = _context.Inventory
                .OrderBy(n => n.ItemIdentifier)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.ItemIdentifier,
                    Text = n.ItemIdentifier
                }).ToList();

            return new SelectList(items, "Value", "Text");
        }

        // POST: RepairTickets/Create
        /// <summary>
        /// POST Method of creating a new repair ticekt.
        /// </summary>
        /// <param name="repairTicket">Repair Ticket Model</param>
        /// <returns>
        /// Creates a new ticket and returns the user to the Index View.
        /// </returns>
        [Authorize(Roles = "FloorAssociate")]
        [Authorize(Roles = "RepairTech")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
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
        /// <summary>
        /// GET Method of editing an item.
        /// </summary>
        /// <param name="id">Repair Ticket ID</param>
        /// <returns>
        /// If the repair ticket is found,
        /// the repair ticket is sent to the POST method.
        /// </returns>
        [Authorize(Roles = "FloorAssociate")]
        [Authorize(Roles = "RepairTech")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
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
        /// <summary>
        /// POST Method for editing a repair ticket.
        /// </summary>
        /// <param name="id">Repair Ticket ID</param>
        /// <param name="repairTicket">Repair Ticket Model</param>
        /// <returns>
        /// If the repair ticket is found,
        /// Saves the new information in the database.
        /// </returns>
        [Authorize(Roles = "FloorAssociate")]
        [Authorize(Roles = "RepairTech")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
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
        /// <summary>
        /// GET Method of deleting a repair ticket.
        /// </summary>
        /// <param name="id">Repair Ticket ID</param>
        /// <returns>
        /// If the repair ticket id is found,
        /// It gets sent to the Delete POST method.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
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
        /// <summary>
        /// POST Method of deleting a Repair Ticket
        /// </summary>
        /// <param name="id">Repair Ticket ID</param>
        /// <returns>
        /// If the repair ticket is found, then it is deleted from the database.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
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
