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
        //This Act
        public ViewResult Create(Order1 order)
        {
            
               
                //Order1 order1 = new Order1();
                PersonalInfo personalID = (PersonalInfo)Session["PersonalId"];
            if (personalID == null)
            {
                ViewBag.Message = "Please add Personal Information for Cart";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {

                    var Total = (from e in _orderContext.carts
                                 where e.PersonlId == personalID.PersonlId
                                 select e.Total * e.Quantity).Sum();
                    if (Total == null)
                    {
                        ViewBag.Message = "Please add approprite Data";
                        return View();
                    }

                    order.PersonlId = personalID.PersonlId;
                    order.Total = Total;
                    order.Date = DateTime.Now;
                    _orderContext.Order1.Add(order);
                    _orderContext.SaveChanges();
                    _orderContext.Order1.Find();
                    ViewBag.Message = "Order Placed Sucessfully"; 
                }
                else
                {
                    ViewBag.Message = "Please Enter Currect values";
                }

            }

            
           
            return View();

        }
       
       
    }
}