using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeepOWebApp.Models
{
    public class InventoryCategoryViewModel
    {
        public List<Inventory> Inventories { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Subcategories { get; set; }
        public string InventoryCategory { get; set; }
        public string InventorySubcategory { get; set; }
        public string SearchString { get; set; }
    }
}
