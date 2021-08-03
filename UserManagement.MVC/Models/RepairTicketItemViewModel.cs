using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TheDeepOTools.Models
{
    public class RepairTicketItemViewModel : RepairTicket
    {
        public string SelectedItemId { get; set; }
        public IEnumerable<SelectListItem> ListItems { get; set; }
    }
}
