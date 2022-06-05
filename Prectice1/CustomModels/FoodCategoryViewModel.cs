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
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public Nullable<System.DateTime> Date { get; set; }

        public Nullable<int> RestaurantID { get; set; }

        
    }
}