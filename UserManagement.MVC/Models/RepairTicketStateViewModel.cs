using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeepOTools.Models
{
    public class RepairTicketStateViewModel
    {
        public List<RepairTicket> RepairTickets { get; set; }
        public string RepairTicketState { get; set; }
        public string SearchString { get; set; }
        public SelectList TicketState { get; internal set; }
    }
}
