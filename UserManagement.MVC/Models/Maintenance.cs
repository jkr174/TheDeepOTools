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
        [Required(ErrorMessage = "Please enter a product name")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public DateTime ServiceHrs { get; set; }
        public DateTime TotalHrs { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public bool IsInService { get; set; }
        public bool NeedsMaintaince { get; set; }
    }
}
