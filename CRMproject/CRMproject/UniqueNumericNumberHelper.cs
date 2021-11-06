using System;
using System.Collections.Generic;
using System.Text;

namespace CRMproject
{
    static class UniqueNumericNumberHelper
    {
        public static int GetUniqueProductNumericNumber()
        {
            var random = new Random();
            int randomNumber = random.Next(0, 2000000);
           
                Console.WriteLine("Your new products number: " + randomNumber);
            
            return randomNumber;
        }
    }
}
