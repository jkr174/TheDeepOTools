/* Name:    Jovany Romo
 * Date:    8/10/2021
 * Summary: Maintenance Model class for the data of an maintence ticket. 
 */

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TheDeepOTools.Models
{
    public class MaintenanceInventoryViewModel : Maintenance
    {
        public string SelectedItemId { get; set; }
        public IEnumerable<SelectListItem> ListItems { get; set; }
    }
}
