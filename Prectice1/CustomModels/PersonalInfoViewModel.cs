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
        [Required]
        public string PersonName { get; set; }
        [Required]
        public string Mobile_No { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public Nullable<int> Pincode { get; set; }
    }
}