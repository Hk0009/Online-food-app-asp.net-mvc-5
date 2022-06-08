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
        [DataType(DataType.Text)]
        [StringLength(60,ErrorMessage ="Must Not Exceed 60 characters")]
        public string PersonName { get; set; }
        [Required(ErrorMessage = "Mobile No is Required")]
        [Display(Name = "Mobile Number")]
        [Phone(ErrorMessage = "Please check if you have Entered any alphabetic character")]

        public string Mobile_No { get; set; }
        [Required(ErrorMessage = "Alternate Number is Required")]
        [Display(Name = "Alternate Number")]
        [Phone(ErrorMessage = "Please check if you have Entered any alphabetic character")]

        public string Contact { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        [Display(Name = "Address")]

        public string Adress { get; set; }

        
        public Nullable<int> Pincode { get; set; }
    }
}