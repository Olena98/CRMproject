using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMproject
{
    class ProductService
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
        public static List<Product> GetProductsByPrice(decimal price) 
        {
            return ProductsDataBase.Products.Where(p => p.Price.ToString().ToUpper().Contains(price.ToString())).ToList();
        }
        public static List<Product> GetProductsByNumber(int number) 
        {
            return ProductsDataBase.Products.Where(p => p.ProductNumber.ToString().ToUpper().Contains(number.ToString())).ToList();
        }
        public static List<Product> GetProductsByExistence(bool existence) 
        {
            
            return ProductsDataBase.Products.Where(p => p.Existence == existence).ToList();
        }
        public static List<Product> GetProductsById(Guid guid) 
        {
            return ProductsDataBase.Products.Where(p => p.Id == guid).ToList();
        }
    }
}
