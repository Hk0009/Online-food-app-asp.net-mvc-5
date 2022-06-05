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
        public ViewResult Create()
        {
             return View(); 
        }
        [HttpPost]
        public ActionResult Create(PersonalInfoViewModel personalinfo)
        {
            try
            {
                var personalinfoCreate = _personalInfoContext.create(personalinfo);
                foodieEntities1.PersonalInfoes.Add(personalinfoCreate);
                foodieEntities1.SaveChanges();
                Session["PersonalId"] = new PersonalInfo
                {
                    PersonlId = personalinfoCreate.PersonlId

                };
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index","Product");
        }

    }
}