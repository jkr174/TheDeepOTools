/* Name:    Jovany Romo
 * Date:    6/3/2021
 * Summary: Inventory Model class for the data of an inventory item. 
 */

using System;
using System.ComponentModel.DataAnnotations;

namespace TheDeepOTools.Models
{
    public class Maintaince
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
        public DateTime TotalHrs { get; set; }

    }
}
