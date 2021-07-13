using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeepOWebApp.Models
{
    public class RepairTicket
    {
        [Key]
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public TicketState State { get; set; }
        public String OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }

        public IEnumerable<RepairTicketMessage> Messages { get; set; }
    }
}
