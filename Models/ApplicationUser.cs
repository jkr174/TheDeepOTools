
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeepOWebApp.Models
{
    public class ApplicationUser
    {
        [Key]
        public UserState State { get; set; }
        public IEnumerable<RepairTicket> RepairTickets { get; set; }
        public IEnumerable<RepairTicketMessage> RepairMessages { get; set; }
    }
}
