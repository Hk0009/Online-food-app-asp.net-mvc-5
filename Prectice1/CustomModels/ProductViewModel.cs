using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prectice1.CustomModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage ="Please Enter Product Name")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Price")]
        public Nullable<int> Price { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public Nullable<int> Quantity { get; set; }
       
        public string ImageUrl { get; set; }
        
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> RestaurantId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}