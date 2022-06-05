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
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Nullable<int> Price { get; set; }
        [Required]
        public Nullable<int> Quantity { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public Nullable<int> CategoryId { get; set; }

        public Nullable<System.DateTime> Date { get; set; }
    }
}