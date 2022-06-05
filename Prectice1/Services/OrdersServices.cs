using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prectice1.Models;
using Prectice1.CustomModels;

namespace Prectice1.Services
{
    public class OrdersServices
    {
        private readonly foodieEntities1 orderContext;
        public OrdersServices(foodieEntities1 _orderContext)
        {
            orderContext = _orderContext;   
        }   
       public IQueryable<Order1> Get()
        {
            var getOrder= from e in orderContext.Order1
                          select e;
            return getOrder;
            
        }
        public Order1 GetById(int id)
        {
            var orderGetById= (from e in orderContext.Order1
                              where e.OrderId == id
                              select e).FirstOrDefault();
            return orderGetById;
        }
      
        
    }
}