using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prectice1.Services;
using Prectice1.CustomModels;
using Prectice1.Models;
using System.Web.Routing;

namespace Prectice1.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private readonly cartServices _cartServices;
        private readonly foodieEntities1 foodieEntities1;
        public CartController()
        {
            _cartServices = new cartServices();
            foodieEntities1 = new foodieEntities1();
        }
        public ActionResult Index()
        {
            var ListCart = _cartServices.Get();
            return View(ListCart);
        }
       
       
        public ActionResult Create(int id,int pid)
        {
            try
            {


                
                    var cartCreate = _cartServices.Create( pid);
                    PersonalInfo personalID = (PersonalInfo)Session["PersonalId"];
                if (personalID == null)
                {
                   
                    return RedirectToAction("Create", "PersonalInfo");
                }
                cartCreate.PersonlId = personalID.PersonlId;
                
                    foodieEntities1.carts.Add(cartCreate);
                    foodieEntities1.SaveChanges();

                return RedirectToAction("RestaurantProduct","User", new { id = id });  
               
                
                   
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }
       
        
        
       
    }
}