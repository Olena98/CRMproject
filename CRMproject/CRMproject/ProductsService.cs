using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMproject
{
    class ProductsService
    {
        public static void AddNewProduct(Product products) 
        {
            ProductsDataBase.AddNewProduct(products);
        }

        public static List<Product> GetProductsByName(string name) 
        {
            name = name.ToUpper();
            return ProductsDataBase.Products.Where(p => p.ProductName.ToUpper().Contains(name)).ToList();
        }
        public static List<Product> GetProductsByDescription(string description) 
        {
            description = description.ToUpper();
            return ProductsDataBase.Products.Where(p => p.Description.ToUpper().Contains(description)).ToList();
        }
        public static List<Product> GetProductsByPrice(string price) 
        {
            return ProductsDataBase.Products.Where(p => p.Price.ToUpper().Contains(price)).ToList();
        }
        public static List<Product> GetProductsByNumber(string number) 
        {
            return ProductsDataBase.Products.Where(p => p.ProductNumber.ToUpper().Contains(number)).ToList();
        }
        public static List<Product> GetProductsByExistence(bool existence) 
        {
            
            return ProductsDataBase.Products.Where(p => p.Existence.ToString().Contains(existence.ToString())).ToList();
        }
        public static List<Product> GetProductsById(Guid guid) 
        {
            return ProductsDataBase.Products.Where(p => p.Id.ToString().Contains(guid.ToString())).ToList();
        }
    }
}
