using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prectice1.Models;

namespace Prectice1.Services
{
    public class RestaurantService
    {
        private readonly foodieEntities1 _context;
        public RestaurantService()
        {
            _context = new foodieEntities1();
        }
        public RestaurantInfo create(RestaurantInfo restaurantInfo)
        {
           // foodieEntities1 context = new foodieEntities1();
            RestaurantInfo restaurent = new RestaurantInfo();
            restaurent.RestaurantName=restaurantInfo.RestaurantName;
            restaurent.Contact = restaurantInfo.Contact;
            restaurent.Description = restaurantInfo.Description;
            _context.RestaurantInfoes.Add(restaurent);
            _context.SaveChanges();
            return null;
          }

        
        public IEnumerable<RestaurantInfo> get()
        {
            return _context.RestaurantInfoes.ToList();
        }
        public RestaurantInfo getById(int id)
        {
            return _context.RestaurantInfoes.Where(c=>c.RestaurantID==id).FirstOrDefault();  
            
        }
        public RestaurantInfo edit(int id,RestaurantInfo restaurantInfo)
        {
            var restaurantEdit = _context.RestaurantInfoes.Where(c => c.RestaurantID == id).FirstOrDefault();
            if (restaurantEdit == null)
            {
                return null;
            }
            restaurantEdit.RestaurantName = restaurantInfo.RestaurantName;
            restaurantEdit.Contact = restaurantInfo.Contact;
            restaurantEdit.Description = restaurantInfo.Description;
            _context.SaveChanges();
            return restaurantEdit;  
        }
        public RestaurantInfo Delete(int id)
        {
            var RestaurantDelete = _context.RestaurantInfoes.Where(c=>c.RestaurantID==id).FirstOrDefault();
            _context.RestaurantInfoes.Remove(RestaurantDelete);
            _context.SaveChanges();
            return RestaurantDelete;

        }

    }
}