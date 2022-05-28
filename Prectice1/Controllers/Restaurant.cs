using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prectice1.Models;
using Prectice1.Services;

namespace Prectice1.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        
        private readonly RestaurantService _restaurentService;
        private readonly RestaurantDetailServices _restaurantDetail;
        // if we will not call it in constructor then it will  throw exception that the context is null
        public RestaurantController()
        {

            _restaurentService = new RestaurantService();
             _restaurantDetail = new RestaurantDetailServices();
        }

        public ActionResult Index()
        {
            var RestaurantList = _restaurentService.get();

            if(RestaurantList== null)
            {
                Console.WriteLine("Please add atleast one data");
            }
            return View(RestaurantList);
        }
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create( RestaurantInfo restaurantInfo)
        {
            try


            {
                // foodieEntities1 context = new foodieEntities1();
               var restaurantCreate = _restaurentService.create(restaurantInfo);
                /*  _context.RestaurantInfoes.Add(restaurant);
                  _context.SaveChanges();
  */
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Create", "RestaurantCategory");
        }

     
       
        public ActionResult Details(int id)
        {
            try
            {
                var restaurantDetails = _restaurantDetail.Details(id);
               

                if (restaurantDetails == null)
                    return HttpNotFound();
                return View(restaurantDetails);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return View();

            
        }
        public ViewResult Edit(int id)
        {
            var restaurantEdit=_restaurentService.getById(id);
            return View(restaurantEdit);
        }
        [HttpPost]
        public ActionResult Edit(int id ,RestaurantInfo restaurantInfo)
        {
            try
            {
                var restaurantEdit = _restaurentService.edit(id,restaurantInfo);
              
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
                var restaurantDelete =_restaurentService.Delete(id);
                if(restaurantDelete == null)
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