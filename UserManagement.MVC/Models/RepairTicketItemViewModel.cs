/* Name:    Jovany Romo
 * Date:    8/3/2021
 * Summary: Used for listing items that are saved in inventory when creating a repair ticket.
 */

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TheDeepOTools.Models
{
    public class RepairTicketItemViewModel : RepairTicket
    {
        public string SelectedItemId { get; set; }
        public IEnumerable<SelectListItem> ListItems { get; set; }
    }
}
