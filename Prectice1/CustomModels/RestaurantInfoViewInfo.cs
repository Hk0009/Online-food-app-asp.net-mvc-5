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
        [Required]
        public string RestaurantName { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
    }
}