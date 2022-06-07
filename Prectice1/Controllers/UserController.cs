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
    public class UserController : Controller
    {
        // GET: User
        private readonly foodieEntities1 _userContext;
        private readonly RestaurantService _restaurantServices;
        private readonly cartServices _cartServices;

        public UserController()
        {
            _userContext = new foodieEntities1();
            _restaurantServices = new RestaurantService();
            _cartServices = new cartServices();
        }

        public ActionResult Index()
        {
            var restaurantGet = _restaurantServices.get();
            return View(restaurantGet);
        }
        public ActionResult RestaurantProduct(int id)
        {

            var res = _userContext.Products.Where(x => x.RestaurantID == id).ToList();

            return View(res);
 
        }
       
      

    }
}