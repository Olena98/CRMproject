using System;
using System.Collections.Generic;
using System.Text;

namespace CRMproject
{
    class Products
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int ProductNumber { get; set; }
        public bool Existense { get; set; }
        public Guid Id { get; set; }

        public Products(string productName, string description, int price, int productNumber, bool existense, Guid guid) 
        {
            ProductName = productName;
            Description = description;
            Price = price;
            ProductNumber = productNumber;
            Existense = existense;
            Id = guid;

            Console.WriteLine("Product name: " + productName + "Description: " + description + "Price: " + price + "Product number: " + productNumber
                + "Existense: " + existense + "Id: " + guid);
        }
    }
}
