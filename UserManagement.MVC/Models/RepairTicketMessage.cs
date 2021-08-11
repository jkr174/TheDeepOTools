/* Name:    Jovany Romo
 * Date:    7/5/2021
 * Summary: 
 * 
 * Inputs:  
 *  
 * Outputs:    
 * 
 */

using System;
using System.ComponentModel.DataAnnotations;

namespace TheDeepOTools.Models
{
    public class RepairTicketMessage
    {
        [Key]
        public Guid Id { get; set; }
        public String Message { get; set; }
        public string Notes { get; set; }

        public Guid TicketId { get; set; }
        public RepairTicket Ticket { get; set; }
        public String OwnerId { get; set; }
        public string Owner { get; set; }
    }
}
