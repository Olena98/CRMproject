using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CRMproject
{
    static class UniqueNumericNumberHelper
    {
        public static int GetUniqueProductNumericNumber()
        {
            var random = new Random();
            int randomNumber = random.Next(0, 20000000);
            if (ProductService.GetProductsByNumber(randomNumber).Count == 0)
            {
                Console.WriteLine("Your new products number: " + randomNumber);
            }

            return randomNumber;
        }
    }
}
