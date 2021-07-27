using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TheDeepOTools.Areas.Identity.Data;

namespace TheDeepOTools.Models
{
    public class RepairTicketMessage
    {
        [Key]
        public Guid Id { get; set; }
        public String Message { get; set; }

        public Guid TicketId { get; set; }
        public RepairTicket Ticket { get; set; }
        public String OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}
