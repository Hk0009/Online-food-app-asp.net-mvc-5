using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prectice1.Models;
using Prectice1.Services;
using Prectice1.CustomModels;

namespace Prectice1.Services
{
    public class ProductServices
    {
        private readonly foodieEntities1 _context;
        public ProductServices()
        {
            _context = new foodieEntities1();
        } 
        public IEnumerable<Product> get()
        {
            return _context.Products.ToList();
        }
        public Product getById(int id)
        {
            var res=_context.Products.Where(c => c.ProductID == id).FirstOrDefault();
            return res;

        }
        public Product create(ProductViewModel product, HttpPostedFileBase ImageFile)
        {
            ImageUploadService imageUploadService = new ImageUploadService();
            string path = imageUploadService.uploadimage(ImageFile);
            Product products=new Product();
            
                            

           // products.ProductID = product.ProductID; 
            products.ProductName = product.ProductName; 
            products.Description = product.Description; 
            products.Price =product.Price;
            products.Quantity=product.Quantity;
            products.ImageUrl= path;
            products.Date= DateTime.Now; 
            //products.CategoryId=product.CategoryId;
           
           
            return products;
        }
        public Product edit(Product product, int id)
        {
            var editProduct=_context.Products.Where(c => c.ProductID == id).FirstOrDefault();   
            if (editProduct == null)
            {
                return null;
            }
            editProduct.ProductName = product.ProductName;
            editProduct.Description = product.Description;
            editProduct.Price = product.Price;
            editProduct.Quantity=product.Quantity;
            editProduct.ImageUrl=product.ImageUrl;
            editProduct.CategoryId = product.CategoryId;
            editProduct.Date = product.Date;
            _context.SaveChanges();
            return editProduct;
        }
        public Product Delete(int id)
        {
            var deleteProduct=_context.Products.Where(c => c.ProductID == id).FirstOrDefault(); 
            _context.Products.Remove(deleteProduct);
            _context.SaveChanges();
            return deleteProduct;   
        }
    }
}