/* Name:    Jovany Romo
 * Date:    7/5/2021
 * Summary: Used for search functionality in the index view of the web application.
 */

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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
