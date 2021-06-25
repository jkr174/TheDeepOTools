using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheDeepOWebApp.Models
{
    public class Inventory
    {
        [Key]
        public int ItemID { get; set; }
        [Required(ErrorMessage = "Please enter an Item Identifier")]
        public string ItemIdentifier { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,
        ErrorMessage = "Please enter a positive price to charge per day")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }
        public string Subcategory { get; set; }
        [Required(ErrorMessage = "Please specify the On Hand quantity")]
        public int OnHandQty { get; set; }
        [Required(ErrorMessage = "Please specify the Out quantity")]
        public int OutQty { get; set; }
        [Required(ErrorMessage = "Please specify a Total quantity")]
        public int TotalQty { get; set; }
    }
}
