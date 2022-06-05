using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prectice1.Services;
using Prectice1.CustomModels;
using Prectice1.Models;
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
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(cartViewModals cartviewModel,int id)
        {
            var cartCreate = _cartServices.Create(cartviewModel,id);
            PersonalInfo personalID = (PersonalInfo)Session["PersonalId"];
            cartCreate.PersonlId = personalID.PersonlId;
            foodieEntities1.carts.Add(cartCreate);
            foodieEntities1.SaveChanges();
            return RedirectToAction("Index","Product");
        }
       
        
        
       
    }
}