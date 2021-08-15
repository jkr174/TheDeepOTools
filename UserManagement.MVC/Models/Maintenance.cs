/* Name:    Jovany Romo
 * Date:    8/10/2021
 * Summary: Maintenance Model class for the data of an maintence ticket. 
 */

using System;
using System.ComponentModel.DataAnnotations;

namespace TheDeepOTools.Models
{
    public class Maintenance
    {
        [Key]
        public int ItemID { get; set; }
        [Required(ErrorMessage = "Please enter an Item Identifier")]
        public string ItemIdentifier { get; set; }
        public string Description { get; set; } 
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public TimeSpan? ServiceHrs { get; set; }
        public TimeSpan? TotalHrs { get; set; }
        public TimeSpan? ReqMaintenanceHrs { get; set; }
        public TimeSpan? HrsSinceLastService { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? StopTime { get; set; }
        public bool IsInService { get; set; }
        public bool NeedsMaintaince { get; set; }
    }
}
