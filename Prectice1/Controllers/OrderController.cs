using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prectice1.CustomModels;
using Prectice1.Models;
namespace Prectice1.Controllers
{
    public class OrderController : Controller
    {
        private readonly foodieEntities1 _orderContext;
        public OrderController()
        {
            _orderContext = new foodieEntities1();
        }
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        
        public ViewResult Create(Order1 order)
        {
            
               
                //Order1 order1 = new Order1();
                PersonalInfo personalID = (PersonalInfo)Session["PersonalId"];
            if (personalID == null)
            {
                ViewBag.Message = "Please add data in Cart";
                return View();
            }
            var Total = (from e in _orderContext.carts
                             where e.PersonlId == personalID.PersonlId
                             select e.Total*e.Quantity).Sum();
              
                order.PersonlId = personalID.PersonlId;
                order.Total = Total;

                _orderContext.Order1.Add(order);
                _orderContext.SaveChanges();

            
           
            return View();

        }
       
       
    }
}