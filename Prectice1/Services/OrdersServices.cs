using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prectice1.Models;

namespace Prectice1.Services
{
    public class OrdersServices
    {
        private readonly foodieEntities1 orderContext;
        public OrdersServices(foodieEntities1 _orderContext)
        {
            orderContext = _orderContext;   
        }   
        public Order create(Order _order)
        {
            Order order = new Order();
            order.Quantity = _order.Quantity;
            return order;
        }
        public Order GetById(int id)
        {
            return orderContext.Orders.Where(c => c.OrderId == id).FirstOrDefault();
        }
        public IEnumerable<Order> Get()
        {
            return orderContext.Orders.ToList();
        }
        public Order Delete(int id)
        {
            var deleteOrder= orderContext.Orders.Where(c => c.OrderId == id).FirstOrDefault();  
            orderContext.Orders.Remove(deleteOrder);
            orderContext.SaveChanges(); 
            return deleteOrder;
        }
        public Order edit(int id ,Order order)
        {
            var editOrder = orderContext.Orders.Where(c => c.OrderId == id).FirstOrDefault();
            editOrder.Quantity = order.Quantity;
            editOrder.Date = order.Date;
            return editOrder;   
        }
    }
}