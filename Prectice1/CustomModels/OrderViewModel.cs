using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prectice1.CustomModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> PersonlId { get; set; }
        public Nullable<int> Total { get; set; }
    }
}