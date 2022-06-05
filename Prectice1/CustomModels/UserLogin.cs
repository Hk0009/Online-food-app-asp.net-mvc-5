using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prectice1.CustomModels
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }    
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}