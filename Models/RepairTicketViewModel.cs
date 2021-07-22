using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeepOWebApp.Models
{
    public class RepairTicketViewModel
    {
        public List<RepairTicket> RepairTickets { get; set; }
        public SelectList state { get; set; }
        public string repairState { get; set; }
        public string SearchString { get; set; }
    }
}
