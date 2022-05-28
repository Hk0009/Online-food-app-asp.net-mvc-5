using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prectice1.Models;
using Prectice1.Services;

namespace Prectice1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Restaurant

        private readonly ProductServices _productServices;
        // if we will not call it in constructor then it will  throw exception that the context is null
        public ProductController()
        {

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
        public ActionResult Create(Product product,HttpPostedFileBase ImageFile)
        {
            try


            {
                // foodieEntities1 context = new foodieEntities1();
                var productCreate = _productServices.create(product, ImageFile);
                /*  _context.RestaurantInfoes.Add(restaurant);
                  _context.SaveChanges();
  */
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index", "Restaurant");
        }


        public ActionResult Details(int id)
        {
            try
            {
                var detailsRestaurant = _productServices.getById(id);
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
        public ViewResult Edit(int id)
        {
            var restaurantEdit = _productServices.getById(id);
            return View(restaurantEdit);
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
            return RedirectToAction("Index");
        }


    }
}