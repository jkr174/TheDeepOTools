/* Name:    Jovany Romo
 * Date:    7/5/2021
 * Summary: 
 * 
 * Inputs:  
 *  
 * Outputs:    
 * 
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
