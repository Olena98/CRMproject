﻿using System;
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
        public static List<Products> GetProductsByDescription(string description) 
        {
            description = description.ToUpper();
            return ProductsDataBase.Product.Where(p => p.Description.ToUpper().Contains(description)).ToList();
        }
        public static List<Products> GetProductsByPrice(string price) 
        {
            return ProductsDataBase.Product.Where(p => p.Price.ToUpper().Contains(price)).ToList();
        }
        public static List<Products> GetProductsByNumber(string number) 
        {
            return ProductsDataBase.Product.Where(p => p.ProductNumber.ToUpper().Contains(number)).ToList();
        }
        public static List<Products> GetProductsByExistence(bool existence) 
        {
            
            return ProductsDataBase.Product.Where(p => p.Existence.ToString().Contains(existence.ToString())).ToList();
        }
        public static List<Products> GetProductsById(Guid guid) 
        {
            return ProductsDataBase.Product.Where(p => p.Id.ToString().Contains(guid.ToString())).ToList();
        }
    }
}
