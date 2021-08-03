using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeepOTools.Models
{
    public class InventoryRepairViewModel : RepairTicket
    {
        public List<Inventory> Inventories { get; set; }
        public SelectList Categories { get; set; }
        public string InventoryCategory { get; set; }
        public string SearchString { get; set; }
    }
}
