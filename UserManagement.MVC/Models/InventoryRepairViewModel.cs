using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeepOTools.Models
{
    public class InventoryRepairViewModel : RepairTicket
    {
        public string SelectedItemId { get; set; }
        public IEnumerable<SelectListItem> ListItems { get; set; }
        public string ItemIdentifier { get; set; }
    }
}
