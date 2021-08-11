/* Name:    Jovany Romo
 * Date:    6/3/2021
 * Summary: Inventory Controller used to load the inventory section of the web application
 * 
 * Input:   When the user loads into the Inventory Section of the website
 * Output:  Returns the appropiate Views for Inventory
 */

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
    public class InventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inventories
        /// <summary>
        /// The method of how to load the Index page of Inventory. 
        /// </summary>
        /// <param name="searchString">
        /// The search string that the user types in the search bar.
        /// </param>
        /// <param name="inventoryCategory">
        /// The selected category the user chooses.
        /// </param>
        /// <returns>
        /// Returns a view of the inventory depending on if the user 
        /// chooses to search for something via a search string or a category.
        /// </returns>
        [Authorize(Roles ="FloorAssociate")]
        [Authorize(Roles ="RepairTech")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Index(string searchString, string inventoryCategory)
        {
            IQueryable<string> genreQuery = from i in _context.Inventory
                                            orderby i.Category
                                            select i.Category;

            var inventories = from i in _context.Inventory
                         select i;

            if (!string.IsNullOrEmpty(searchString))
            {
                inventories = inventories.Where(
                    s => s.ItemIdentifier.Contains(searchString)
                    || s.ItemName.Contains(searchString)
                    || s.Category.Contains(searchString)
                    || s.Subcategory.Contains(searchString)
                    );
            }

            if (!string.IsNullOrEmpty(inventoryCategory))
            {
                inventories = inventories.Where(x => x.Category == inventoryCategory);
            }

            var inventyoryCategoryVM = new InventoryCategoryViewModel
            {
                Categories = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Inventories = await inventories.ToListAsync()
            };

            return View(inventyoryCategoryVM);
        }

        // GET: Inventories/Details/5
        /// <summary>
        /// Used to get a detailed view of an item.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns a view of the item's details.
        /// </returns>
        [Authorize(Roles = "FloorAssociate")]
        [Authorize(Roles = "RepairTech")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventories/Create
        /// <summary>
        /// Method of allowing the user to add a new item into the inventory database.
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns>
        /// Assuming the user does not input invalid information,
        /// It finally adds the item to the database and returns the Index View.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create([Bind("ItemID,ItemIdentifier,ItemName,Description,Price,Category,Subcategory,OnHandQty,OutQty,TotalQty")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        /// <summary>
        /// The GET method for editing an item.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// If the item is found,
        /// it returns the item to the POST method.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        /// <summary>
        /// Method of allowing a user to edit information about an item.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="inventory"></param>
        /// <returns>
        /// If the item is found,
        /// It saves the new information about the item in the database.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemID,ItemIdentifier,ItemName,Description,Price,Category,Subcategory,OnHandQty,OutQty,TotalQty")] Inventory inventory)
        {
            if (id != inventory.ItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.ItemID))
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
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        /// <summary>
        /// The GET method of deleting an item.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// If the item is found,
        /// It sends the item to the POST method.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventory
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        /// <summary>
        /// POST method of deleting an item from the inventory database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Deletes the item from inventory and returns the Index View.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Manager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.ItemID == id);
        }
    }
}
