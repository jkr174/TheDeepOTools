using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDeepOWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using TheDeepOWebApp.Data;

namespace TheDeepOWebApp.Controllers
{
    public class BackUpAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BackUpAdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ViewResult Index() => View(_context.Inventory);

        public ViewResult Edit(int itemId) =>
            View(_context.Inventory
                .FirstOrDefault(i => i.ItemID == itemId));

        [HttpPost]
        public IActionResult Edit(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.SaveChanges();
                TempData["message"] = $"{inventory.ItemIdentifier} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                //Something went wrong
                return View(inventory);
            }
        }
        public ViewResult Create() => View("Edit", new Inventory());
    }
}
