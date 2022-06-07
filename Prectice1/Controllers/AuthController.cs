using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prectice1.CustomModels;
using Prectice1.Models;
using Prectice1.Services;
using System.Web.Security;
namespace Prectice1.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        
        // GET: Auth
        private readonly LoginService loginService;
        private readonly foodieEntities1 foodieEntities1;
        public AuthController()
        {
            loginService = new LoginService();
            foodieEntities1 = new foodieEntities1();
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLogin login)
        {
            //Persistent cookies are stored on a user's device to hold usage information, settings, personalizations, or sign-on credentials
            bool isValid = foodieEntities1.Logins.Any(x => x.UserName == login.UserName && x.Password == login.Password);
            if(isValid)
            {
                FormsAuthentication.SetAuthCookie(login.UserName,false);
                return RedirectToAction("Index", "Restaurant");
            }
            ModelState.AddModelError("", "Invaid username and password");
            return RedirectToAction("Index", "Restaurant");

        }
        public ViewResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Login login)
        {
            /* using (var context = new foodieEntities1())
             {
                 context.Logins.Add(login);
                 context.SaveChanges();
             }*/
            try
            {
                var userSignup = loginService.SignUp(login);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Login","Auth");

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}