using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prectice1.CustomModels
{
    public class cartViewModals
    {
        public int CartId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> PersonlId { get; set; }
        public Nullable<int> Total { get; set; }
    }
}