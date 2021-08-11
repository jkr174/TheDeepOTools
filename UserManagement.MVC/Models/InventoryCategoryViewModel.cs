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
    public class InventoryCategoryViewModel
    {
        public List<Inventory> Inventories { get; set; }
        public SelectList Categories { get; set; }
        public string InventoryCategory { get; set; }
        public string SearchString { get; set; }
    }
}
