using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prectice1.CustomModels
{
    public class FoodCategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please Enter Data")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
     
        [Display(Name = "Upload Image")]
        public string ImageUrl { get; set; }

        public Nullable<System.DateTime> Date { get; set; }

        public Nullable<int> RestaurantID { get; set; }

        
    }
}