using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prectice1.Models;
using Prectice1.Services;
using Prectice1.Controllers;
using System.IO;

namespace Prectice1.Services

{
    public class RestaurantCategoryServices
    {
        private readonly foodieEntities1 _context;
        public RestaurantCategoryServices()
        {
            _context = new foodieEntities1();
        }
        public FoodCategory create(FoodCategory foodCategory,HttpPostedFileBase ImageFile)
        {
            ImageUploadService imageUploadService = new ImageUploadService();

            string path = imageUploadService.uploadimage(ImageFile);
            FoodCategory foodCategories = new FoodCategory();
            foodCategories.CategoryName = foodCategory.CategoryName;
            foodCategories.ImageUrl = path;
            foodCategories.Date = foodCategory.Date;
            foodCategories.RestaurantID = foodCategory.RestaurantID;
            _context.FoodCategories.Add(foodCategories);
            _context.SaveChanges();
            return null;
  
        }
       

        public IEnumerable<FoodCategory> get()
        {
            return _context.FoodCategories.ToList();
        }
        public FoodCategory getId(int id)
        {
            return _context.FoodCategories.Where(c=>c.CategoryId==id).FirstOrDefault();

        }
        public FoodCategory edit(int id, FoodCategory foodCategory)
        {
            var foodCategoryEdit=_context.FoodCategories.Where(c=>c.CategoryId==id).FirstOrDefault();
            foodCategoryEdit.CategoryName=foodCategory.CategoryName;
            foodCategoryEdit.ImageUrl=foodCategory.ImageUrl;
            foodCategoryEdit.Date=foodCategory.Date;
            _context.SaveChanges();
            return foodCategoryEdit;

        }
        public FoodCategory delete(int id)
        {
            var RestaurantCategory=_context.FoodCategories.Where(c=>c.RestaurantID==id).FirstOrDefault();
            _context.FoodCategories.Remove(RestaurantCategory);
            _context.SaveChanges();
            return RestaurantCategory;
        }
    }
}