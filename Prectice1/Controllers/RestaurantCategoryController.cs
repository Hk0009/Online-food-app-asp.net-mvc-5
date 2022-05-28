using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prectice1.Services;
using Prectice1.Models;
using System.IO;

namespace Prectice1.Controllers
{
    public class RestaurantCategoryController : Controller
    {
        // GET: RestaurantCategory
        private readonly RestaurantCategoryServices _restaurantCategoryService;
        public RestaurantCategoryController()
        {
            _restaurantCategoryService = new RestaurantCategoryServices();    
        }
        public ActionResult Index()
        {
            var RestaurantCategoryList = _restaurantCategoryService.get();
            return View(RestaurantCategoryList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FoodCategory foodCategory,HttpPostedFileBase ImageFile)
        {
            try
            {
               

                var createFoodCategory = _restaurantCategoryService.create(foodCategory, ImageFile);
               

                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           return RedirectToAction("Create","Product");
        }
      
        public ViewResult Edit(int id)
        {
            try
            {
                var restaurantEdit = _restaurantCategoryService.getId(id);
                return View(restaurantEdit);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return View();  
            
        }
        [HttpPost]
        public ActionResult Edit(FoodCategory foodCategory, int id)
        {
            try
            {
                var restaurantCategoryEdit = _restaurantCategoryService.edit(id, foodCategory);
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            try
            {
                var restaurentCategoryDetails = _restaurantCategoryService.getId(id);
                if(restaurentCategoryDetails == null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return View();  
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var restaurantCategoryEdit = _restaurantCategoryService.delete(id);
                if(restaurantCategoryEdit==null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");

        }
        
    }
}