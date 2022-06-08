using System;

using System.Web;
using System.Web.Mvc;
using Prectice1.Services;
using Prectice1.Models;
using Prectice1.CustomModels;
using System.Linq;

namespace Prectice1.Controllers
{
    public class RestaurantCategoryController : Controller
    {
        // GET: RestaurantCategory
        private readonly RestaurantCategoryServices _restaurantCategoryService;
        private readonly foodieEntities1 _categoryContext;  
        public RestaurantCategoryController()
        {
            _restaurantCategoryService = new RestaurantCategoryServices();
            _categoryContext = new foodieEntities1();
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
        public ActionResult Create(FoodCategoryViewModel foodCategory,HttpPostedFileBase ImageFile, int id=0)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RestaurantInfo restaurantId = (RestaurantInfo)Session["restaurantId"];

                    var createFoodCategory = _restaurantCategoryService.create(foodCategory, ImageFile);
                    //createFoodCategory.RestaurantID=restaurantId.RestaurantID;
                   
                    if(restaurantId == null)
                    {
                        createFoodCategory.RestaurantID = id;
                        var ID = createFoodCategory.CategoryId;
                        _categoryContext.FoodCategories.Add(createFoodCategory);
                        _categoryContext.SaveChanges();
                        return RedirectToAction("Details", "RestaurantCategory", new {id=id});
                    }
                    else
                    {
                        createFoodCategory.RestaurantID = restaurantId.RestaurantID;
                        Session["foodCategoryId"] = new FoodCategory
                        {
                            CategoryId = createFoodCategory.CategoryId

                        };
                        _categoryContext.FoodCategories.Add(createFoodCategory);
                        _categoryContext.SaveChanges();
                        return RedirectToAction("Create", "Product");
                    }
                   
                   
                }
                else
                {
                    ViewBag.Message = "Please Enter Correct Details";
                    return View();
                }




            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           return RedirectToAction("Index","Restaurant");
        }
      
        public ActionResult Edit(int id)
        {
            try
            {
                var restaurantEdit = _restaurantCategoryService.getId(id);
                return PartialView("EditCategoryPartialView", restaurantEdit);
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
          
            return RedirectToAction("Details", new{id=id});
        }

        public ActionResult Details(int id)
        
        {
            try
            {
               
                var restaurentCategoryDetails = _categoryContext.FoodCategories.Where(x=>x.RestaurantID==id).ToList();
                
                if (restaurentCategoryDetails == null)
                {
                    return null;
                }
                return View(restaurentCategoryDetails);
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