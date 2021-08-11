/* Name:    Jovany Romo
 * Date:    7/5/2021
 * Summary: 
 * 
 * Inputs:  
 *  
 * Outputs:    
 * 
 */

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TheDeepOTools.Models
{
    public class InventoryRepairViewModel : RepairTicket
    {
        public string SelectedItemId { get; set; }
        public IEnumerable<SelectListItem> ListItems { get; set; }
        public string ItemIdentifier { get; set; }
    }
}
