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
        [Required(ErrorMessage = "Name")]

        public string RestaurantName { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Description { get; set; }
    }
}