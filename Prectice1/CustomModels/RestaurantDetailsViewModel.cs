using Prectice1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prectice1.CustomModels
{
    public class RestaurantDetailsViewModel
    {
/*        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }

*/     public RestaurantInfo RestaurantInfos { get; set; }
       /* public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }*/
       public IEnumerable<FoodCategory> FoodCategorys { get; set; }   
        public IEnumerable<Product> Products { get; set; }
       /* public HttpPostedFileBase ImageFile { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        //public Nullable<int> RestaurantID { get; set; }
        public IEnumerable<Product> Product { get; set; }*/   

    }
   
}