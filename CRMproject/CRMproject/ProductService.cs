using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMproject
{
    class ProductService
    {
        public static void AddNewProduct(Products products) 
        {
            ProductsDataBase.AddNewProduct(products);
        }

        public static List<Products> GetProductsByName(string name) 
        {
            name = name.ToUpper();
            return ProductsDataBase.Product.Where(p => p.ProductName.ToUpper().Contains(name)).ToList();
        }
    }
}
