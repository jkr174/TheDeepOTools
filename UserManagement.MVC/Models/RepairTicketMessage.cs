/* Name:    Jovany Romo
 * Date:    7/5/2021
 * Summary: RepairTicketMessage Model class for the data to be used in a repair ticket.
 */

using System;
using System.ComponentModel.DataAnnotations;

namespace TheDeepOTools.Models
{
    public class RepairTicketMessage
    {
        [Key]
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Notes { get; set; }

        public Guid TicketId { get; set; }
        public RepairTicket Ticket { get; set; }
        public string OwnerId { get; set; }
        public string Owner { get; set; }
    }
}
