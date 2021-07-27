using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDeepOWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using TheDeepOWebApp.Data;
using TheDeepOTools.Models;
using TheDeepOTools.Data;

namespace TheDeepOTools.Controllers
{
    public class BackUpAdminController : Controller
    {
        private readonly TheDeepOToolsContext _context;

        public BackUpAdminController(TheDeepOToolsContext context)
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
