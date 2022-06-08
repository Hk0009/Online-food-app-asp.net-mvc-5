using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prectice1.Models;
using Prectice1.CustomModels;
namespace Prectice1.Services
{
    public class LoginService
    {
        private readonly foodieEntities1 _foodieEntities1;
        public LoginService()
        {
            _foodieEntities1 = new foodieEntities1();
        }
        public Login login(UserLogin login)
        {
           

            return null;
        }
        public Login SignUp(UserLogin SignUp)
        {
            Login signup = new Login();
            try
            {
               
                

                signup.UserName = SignUp.UserName;
                signup.Password = SignUp.Password;

                _foodieEntities1.Logins.Add(signup);
                _foodieEntities1.SaveChanges();
                return signup;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return signup;
            
        }
    }
}