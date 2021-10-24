using System;
using System.Collections.Generic;
using System.Text;

namespace CRMproject
{
    class ProductService
    {
        public static void AddNewProduct(Products products) 
        {
            ProductsDataBase.AddNewProduct(products);
        }
    }
}
