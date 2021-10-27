using System;
using System.Collections.Generic;
using System.Text;

namespace CRMproject
{
    class Product
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductNumber { get; set; }
        public bool Existence { get; set; }
        public Guid Id { get; set; }
       
    }
}
