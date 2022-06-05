using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prectice1.CustomModels;
using Prectice1.Models;
namespace Prectice1.Services
{
    public class cartServices
    {
        private readonly cartViewModals _cartModels;
        private readonly foodieEntities1 _foodiesContext;
        public cartServices()
        {
            _cartModels = new cartViewModals(); 
            _foodiesContext = new foodieEntities1();   
        }
        public IQueryable<cart> Get()
        {
            var getCart = from e in _foodiesContext.carts
                          select e;
            return getCart;
        }
        public cart Create(cartViewModals cartView, int id )
        {
            cart Cart = new cart();
           var productId = (from e in _foodiesContext.Products
                           where e.ProductID==id
                            select e).FirstOrDefault();
              //var productPrice=_foodiesContext.Products.Where(x=>x.ProductID==).FirstOrDefault();
            var price= productId.Price; 
             Cart.Quantity = cartView.Quantity;
            Cart.ProductID = id;
            Cart.Total= Cart.Quantity * price;
            Cart.Date = DateTime.Now;
            return Cart;
        }
        public cart GetbyId(int id)
        {
            var cartGetbyid= (from e in _foodiesContext.carts
                             where e.CartId==id
                             select e).FirstOrDefault();    
            return cartGetbyid; 
        }
        public cart Delete(int id)
        {
            var getCartToDelete= (from e in _foodiesContext.carts   
                                  where (e.CartId==id)  
                                  select e).FirstOrDefault();
            _foodiesContext.carts.Remove(getCartToDelete);  
            return getCartToDelete;
        }
        public cart Update(cartViewModals cartViewModals, int id)
        {
            var getCartId = (from e in _foodiesContext.carts
                             where (e.PersonlId == id) 
                             select e).FirstOrDefault();
            getCartId.Quantity = cartViewModals.Quantity;
            var productPrice = _foodiesContext.Products.Where(x => x.ProductID == getCartId.ProductID).FirstOrDefault();
            var price = productPrice.Price;
            getCartId.Total = price * getCartId.Quantity;
            return getCartId;   
            
        }
        
    }
}