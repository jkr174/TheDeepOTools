using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeepOWebApp.Models
{
    public class RepairTicketStateViewModel
    {
        public List<RepairTicket> RepairTickets { get; set; }
        public SelectList States { get; set; }
        public string RepairTicketState { get; set; }
        public string SearchString { get; set; }
    }
}
