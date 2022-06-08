using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prectice1.Models;
using Prectice1.Services;
using Prectice1.CustomModels;
namespace Prectice1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Restaurant

        private readonly ProductServices _productServices;
        private readonly foodieEntities1 _productContext;
        // if we will not call it in constructor then it will  throw exception that the context is null
        public ProductController()
        {
            _productContext = new foodieEntities1();
            _productServices = new ProductServices();
        }

        public ActionResult Index()
        {
            var productList = _productServices.get();

            if (productList == null)
            {
                Console.WriteLine("Please add atleast one data");
            }
            return View(productList);
        }
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductViewModel product,HttpPostedFileBase ImageFile,int id)
        {
            try


            {
                if (ModelState.IsValid)
                {
                    var restaurantId = _productContext.FoodCategories.Where(x=>x.CategoryId==id).First();

                    var resId = restaurantId.RestaurantID;
                    RestaurantInfo restaurantInfo = (RestaurantInfo)Session["restaurantId"];
                    // foodieEntities1 context = new foodieEntities1();
                    FoodCategory foodCategory = (FoodCategory)Session["foodCategoryId"];
                    var productCreate = _productServices.create(product, ImageFile);
                    if (restaurantInfo==null)
                    {
                        
                        productCreate.CategoryId = id;
                        productCreate.RestaurantID = resId;
                        _productContext.Products.Add(productCreate);
                        _productContext.SaveChanges();
                        return RedirectToAction("Details", "Product");
                    }
                    else
                    {
                        productCreate.RestaurantID = restaurantId.RestaurantID;
                        _productContext.Products.Add(productCreate);
                        _productContext.SaveChanges();
                        return RedirectToAction("Create", "Product");
                    }
                    
                }
                else
                {
                    ViewBag.Message = "Please Enter Correct Details";
                }
               
                
 
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return View();
        }


        public ActionResult Details(int id)
        {
            try
            {
                var detailsRestaurant = (from e in _productContext.Products
                                        where e.RestaurantID == id
                                        select e).ToList();
                if (detailsRestaurant == null)
                    return HttpNotFound();
                return View(detailsRestaurant);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return View();


        }
        public ActionResult Edit(int id)
        {
            try
            {
                var restaurantEdit = _productServices.getById(id);
                return PartialView("EditProductPartialView", restaurantEdit);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return PartialView("EditProductPartialView");
        }
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                var restaurantEdit = _productServices.edit(product, id);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var restaurantDelete = _productServices.Delete(id);
                if (restaurantDelete == null)
                {
                    return null;

                }


            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
            }
            return RedirectToAction("Index","Restaurant");
        }
        


    }
}