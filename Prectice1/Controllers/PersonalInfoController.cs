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
    public class PersonalInfoController : Controller
    {
        private readonly PersonalInfoService _personalInfoContext;
        private readonly foodieEntities1 foodieEntities1;    
        // GET: PersonalInfo
        public PersonalInfoController()
        {
            foodieEntities1 = new foodieEntities1();    
            _personalInfoContext = new PersonalInfoService();
        }
        public ActionResult Index()
        {
            var PersonalinfoList = _personalInfoContext.get();
            return View(PersonalinfoList);
        }
        public ActionResult Edit(int id)
        {
            try
            {
                var personalInfoEdit = _personalInfoContext.getById(id);
                return PartialView("PersonalInfoEditPartialView", personalInfoEdit);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return View();    
           
        }
        [HttpPost]
        public ActionResult Edit(PersonalInfo personalView, int id)
        {
            try
            {
                var PersonalEdit = _personalInfoContext.edit(personalView, id);
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
            return RedirectToAction("Index", "PersonalInfo");

        }
        [Authorize(Roles ="User")]
        public ViewResult Create()
        {
             return View(); 
        }
        [HttpPost]
        public ActionResult Create(PersonalInfoViewModel personalinfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var personalinfoCreate = _personalInfoContext.create(personalinfo);
                    foodieEntities1.PersonalInfoes.Add(personalinfoCreate);
                    foodieEntities1.SaveChanges();
                    Session["PersonalId"] = new PersonalInfo
                    {
                        PersonlId = personalinfoCreate.PersonlId

                    };
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ViewBag.Message = "Enter Valid Details";
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var deletePersonalInfo = _personalInfoContext.Delete(id);
                if(deletePersonalInfo==null)
                {
                    return null;
                }
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
            return RedirectToAction("Index","PersonalInfo");
        }

    }
}