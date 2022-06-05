using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prectice1.CustomModels;
using Prectice1.Models;
namespace Prectice1.Services
{
    public class extendedViewServices
    {
        private readonly foodieEntities1 _contextfoodieEntities1;
        public extendedViewServices()
        {
            _contextfoodieEntities1 = new foodieEntities1();
        }
        public IEnumerable<RestaurantDetailsViewModel> Detail()
        {
            List<RestaurantDetailsViewModel> details = new List<RestaurantDetailsViewModel>();
            var orderBydescendingRestaurant = _contextfoodieEntities1.RestaurantInfoes.OrderBy(x => x.RestaurantID);
            foreach(var i in orderBydescendingRestaurant)
            {
                var restaurantCategory=_contextfoodieEntities1.FoodCategories.Where(x=>x.RestaurantID==i.RestaurantID).ToList();
                foreach(var product in restaurantCategory)
                {
                    var categoryProduct = _contextfoodieEntities1.Products.Where(x => x.CategoryId == product.CategoryId).ToList();
                    details.Add(new RestaurantDetailsViewModel { RestaurantInfos = i, FoodCategorys = restaurantCategory, Products = categoryProduct });
                }
               
            }
            return details;
        }
    }
}