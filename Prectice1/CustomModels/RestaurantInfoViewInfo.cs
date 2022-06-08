using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prectice1.CustomModels
{
    public class RestaurantInfoViewInfo
    {
        public int RestaurantID { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Restaurant Name")]
        public string RestaurantName { get; set; }

        [Required(ErrorMessage = "Please enter Valid Phone number")]
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage ="Pease Enter Only integer values")]
        public string Contact { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}