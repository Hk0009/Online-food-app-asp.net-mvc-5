using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prectice1.CustomModels
{
    public class RestaurantInfoViewModel
    {
        public int RestaurantID { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Restaurant Name")]
        public string RestaurantName { get; set; }
        [Required]
        [Range(1,9, ErrorMessage = "Only positive number allowed")]
        public string Contact { get; set; }
        [Required]
        
        [Display(Name ="Description")]
        public string Description { get; set; }
    }
}