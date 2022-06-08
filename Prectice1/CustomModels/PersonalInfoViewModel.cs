using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prectice1.CustomModels
{
    public class PersonalInfoViewModel
    {
        
        public int PersonlId { get; set; }
        [Required(ErrorMessage ="Person Name is Required")]
        [Display(Name = "Person Name")]
        [StringLength(60)]
        public string PersonName { get; set; }
        [Required(ErrorMessage = "Mobile No is Required")]
        [Display(Name = "Mobile Number")]
        [Phone(ErrorMessage = "Please check if you have Entered any alphabetic character")]

        public string Mobile_No { get; set; }
        [Required(ErrorMessage = "Alternate Number is Required")]
        [Display(Name = "Alternate Number")]
        [Phone(ErrorMessage ="Please check if you have Entered any alphabetic character")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        [Display(Name = "Address")]

        public string Adress { get; set; }
        [Required(ErrorMessage = "Pin Code is Required")]
        [Display(Name = "PIN Code")]
        [StringLength(6,MinimumLength=2,ErrorMessage ="Min 6 numbers are required")]
        [RegularExpression("[^0-9]", ErrorMessage = "Pin Code must be numeric")]
        public Nullable<int> Pincode { get; set; }
    }
}