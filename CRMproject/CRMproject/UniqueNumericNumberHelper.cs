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
            List<int> list = new List<int>();
            var random = new Random();

            int randomNumber = random.Next(0, 20000000);
            if (!list.Contains(randomNumber)) 
            {
                list.Add(randomNumber);
            }
            
            Console.WriteLine("Your new products number: " + randomNumber);

            return randomNumber;
        }
    }
}
