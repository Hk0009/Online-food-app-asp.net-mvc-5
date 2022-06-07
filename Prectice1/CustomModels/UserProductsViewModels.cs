using Prectice1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prectice1.CustomModels
{
    public class UserProductsViewModels
    {
        /*public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> CRestaurantID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string PDescription { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string PImageUrl { get; set; }
        public Nullable<int> PCategoryId { get; set; }
        public Nullable<System.DateTime> PDate { get; set; }
        public Nullable<int> PRestaurantID { get; set; }*/

        /* public HttpPostedFileBase ImageFile { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        //public Nullable<int> RestaurantID { get; set; }
        public IEnumerable<Product> Product { get; set; }*//*
    }*/
        public Product product { get; set; }  
        public FoodCategory FoodCategory { get; set; }  

    }
   


}