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
        public object Details()
        {
            List<RestaurantDetailsViewModel> viewModelRestaurantDetails = new List<RestaurantDetailsViewModel>();
            try
            {
                
               /* var restauranat = restaurantService.get();
                
                var categoryRestaurnat = restaurantCategoryService.get().Where(c => c.RestaurantID == id).FirstOrDefault();
                var product = productServices.getById(id);*/


              /*  RestaurantDetailsViewModel restaurantDetails = new RestaurantDetailsViewModel();
                viewModelRestaurantDetails.RestaurantInfo.RestaurantID = id;
                viewModelRestaurantDetails.RestaurantInfo.RestaurantName = restauranat.RestaurantName;
                viewModelRestaurantDetails.RestaurantInfo.Contact = restauranat.Contact;
                viewModelRestaurantDetails.RestaurantInfo.Description = restauranat.Description;
                viewModelRestaurantDetails.FoodCategory.CategoryId = categoryRestaurnat.CategoryId;
                viewModelRestaurantDetails.FoodCategory.CategoryName = categoryRestaurnat.CategoryName;
                viewModelRestaurantDetails.FoodCategory.Date = categoryRestaurnat.Date;
                viewModelRestaurantDetails.FoodCategory.ImageUrl = categoryRestaurnat.ImageUrl;
                viewModelRestaurantDetails.Product = productServices.get().Where(c => c.CategoryId == categoryRestaurnat.CategoryId).ToList();*/
                
                
            }
            catch (Exception xy)
            {

                Console.WriteLine(xy.Message);
            }


            return viewModelRestaurantDetails;

        }
    }
}