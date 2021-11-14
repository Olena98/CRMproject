using System;

namespace CRMproject
{
    static class UniqueNumericNumberHelper
    {
        public static int GetUniqueProductNumericNumber()
        {
            var random = new Random();
            int randomNumber = random.Next(0, 20000000); 
            while(ProductService.GetProductsByNumber(randomNumber).Count > 0)
            {
                randomNumber = random.Next(0, 20000000);
                Console.WriteLine("Your new number:" + randomNumber);
            }
            return randomNumber;
        }

        public static int GetUniqueOrderNumericNumber() 
        {
            var random = new Random();
            int randomNumber = random.Next(0, 20000000); 
            while (OrderService.GetOrdersByNumber(randomNumber).Count > 0)
            {
                randomNumber = random.Next(0, 20000000);
                Console.WriteLine("Your new number: " + randomNumber);
            }
            return randomNumber;
        }
    }
}
