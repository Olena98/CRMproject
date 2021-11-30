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
        public int ProductNumber { get; set; }
        public bool Existence { get; set; }
        public Guid Id { get; set; }
        public List<ChangeEntry> ChangesEntries { get; set; }

        public override string ToString()
        {
            var result = "Product Id: " + Id.ToString() + "\n\t Product Number: " + ProductNumber.ToString() + "\n\t Description: " + Description + "\n\t Price: " + Price.ToString() +
                "\n\t Product Name: " + ProductName + "\n\t Existence: " + Existence.ToString();
            result += $"\n\tChange Entries Count: {ChangesEntries.Count}\n";
            foreach (var entry in ChangesEntries)
            {
                result += $"\t\t{entry.ProductName} - {entry.ProductNumber} - {entry.Price} - {entry.Existence}\n";
            }
            result = result.Remove(result.Length - 1);
            return result;
        }
        public class ChangeEntry 
        {
            public string ProductName { get; set; }         
            public decimal Price { get; set; }
            public int ProductNumber { get; set; }
            public bool Existence { get; set; }
        }

    }
}
