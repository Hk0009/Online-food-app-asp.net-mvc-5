using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Prectice1.Models;
using Prectice1.Services;
using Prectice1.CustomModels;


namespace Prectice1.Controllers
{
    
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        
        private readonly RestaurantService _restaurentService;
        private readonly RestaurantDetailServices _restaurantDetail;
        private readonly foodieEntities1 _restaurantContext;
        private readonly extendedViewServices extendedViewServices;
        // if we will not call it in constructor then it will  throw exception that the context is null
        public RestaurantController()
        {

            _restaurentService = new RestaurantService();
             _restaurantDetail = new RestaurantDetailServices();
            _restaurantContext = new foodieEntities1();
            extendedViewServices = new extendedViewServices();
        }
        /*[Authorize(Roles ="admin")]*/
        public ActionResult Index()
        {
            /*var RestaurantList = _restaurentService.get();

            if(RestaurantList== null)
            {
                Console.WriteLine("Please add atleast one data");
            }
            return View(RestaurantList);*/

          var detailView = extendedViewServices.Detail();
            /*
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
        }*/
            return View(detailView);
        }
        [Authorize(Roles = "admin")]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create( RestaurantInfoViewInfo restaurantInfo)
        {
            try


            {
                //foodieEntities1 context = new foodieEntities1();
               var restaurantCreate = _restaurentService.create(restaurantInfo);
                _restaurantContext.RestaurantInfoes.Add(restaurantCreate);
                _restaurantContext.SaveChanges();
             
                
                /* var res= context.RestaurantInfoes.Add(restaurantInfo);
                context.SaveChanges();*/
                Session["restaurantId"] = new RestaurantInfo
              {
                  RestaurantID = restaurantCreate.RestaurantID

              };
                
  
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Create", "RestaurantCategory");
        }

/*        [Authorize(Roles = "admin")]
*/
        public ActionResult Details()
        {
            List<RestaurantDetailsViewModel> detailView = new List<RestaurantDetailsViewModel>();
            var o = _restaurantContext.RestaurantInfoes.OrderByDescending(a => a.RestaurantID);
            foreach(var i in o)
            {
                var od = _restaurantContext.FoodCategories.Where(a=>a.RestaurantID==i.RestaurantID).ToList();
                
                detailView.Add(new RestaurantDetailsViewModel { RestaurantInfos = i, FoodCategorys =od});
            }
                /*
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
            }*/
            return View(detailView);

            
        }
        public ActionResult Edit(int id)
        {
            var restaurantEdit=_restaurentService.getById(id);
            return PartialView("EditRestaurantPartialView",restaurantEdit);
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