using System;

using System.Web;
using System.Web.Mvc;
using Prectice1.Services;
using Prectice1.Models;
using Prectice1.CustomModels;


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
        public ActionResult Create(FoodCategoryViewModel foodCategory,HttpPostedFileBase ImageFile)
        {
            try
            {
                RestaurantInfo restaurantId = (RestaurantInfo)Session["restaurantId"];

                var createFoodCategory = _restaurantCategoryService.create(foodCategory, ImageFile);
                //createFoodCategory.RestaurantID=restaurantId.RestaurantID;
                createFoodCategory.RestaurantID=restaurantId.RestaurantID;  
                _categoryContext.FoodCategories.Add(createFoodCategory);
                _categoryContext.SaveChanges();
                Session["foodCategoryId"] = new FoodCategory
                {
                    CategoryId = createFoodCategory.CategoryId

                };




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