using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prectice1.Services;
using Prectice1.Models;
using Prectice1.CustomModels;

namespace Prectice1.Services
{
    public class RestaurantDetailServices
    {
        private readonly RestaurantService restaurantService;
        private readonly RestaurantCategoryServices restaurantCategoryService;
        private readonly ProductServices productServices;
        public RestaurantDetailServices()
        {
            restaurantService = new RestaurantService();
            restaurantCategoryService= new RestaurantCategoryServices();
            productServices = new ProductServices();    
        }
        public object Details(int id)
        {
            var restauranat = restaurantService.getById(id);
            
            var categoryRestaurnat = restaurantCategoryService.get().Where(c => c.RestaurantID == id).FirstOrDefault();
            var product=productServices.get();
            RestaurantDetailsViewModel restaurantDetails = new RestaurantDetailsViewModel();
            restaurantDetails.RestaurantID = id;
            restaurantDetails.RestaurantName = restaurantDetails.RestaurantName;
            restaurantDetails.Contact = restaurantDetails.Contact;
            restaurantDetails.Description = restaurantDetails.Description;
            categoryRestaurnat.CategoryId = restaurantDetails.CategoryId;
            categoryRestaurnat.CategoryName = restaurantDetails.CategoryName;
            categoryRestaurnat.Date = restaurantDetails.Date;
            categoryRestaurnat.ImageUrl = restaurantDetails.ImageUrl;
            var productDetails = productServices.get().Where(c => c.CategoryId == categoryRestaurnat.CategoryId).FirstOrDefault();



            return null;

        }
    }
}