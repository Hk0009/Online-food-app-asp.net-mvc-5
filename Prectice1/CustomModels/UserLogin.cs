using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Prectice1.CustomModels
{
    public class UserLogin
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter User Name")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [NotMapped]
        [Required]
        [Display(Name ="Confirm Password")]
        [CompareAttribute("Password",ErrorMessage ="Password DoesNot match")]
        public string ConfirmPassword { get; set; }
    }
}