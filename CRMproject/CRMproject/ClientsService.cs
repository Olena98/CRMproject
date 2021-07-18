using System;
using System.Collections.Generic;
using System.Text;

namespace CRMproject
{
    class ClientsService
    {
        public static Client AddNewClient()
        {
            Client client = new Client();

            Console.WriteLine("Enter your name:");
            client.Name = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            client.LastName = Console.ReadLine();
            Console.WriteLine("Enter your  surname:");
            client.Surname = Console.ReadLine();
            Console.WriteLine("Enter your email:");
            client.Email = Console.ReadLine();
            Console.WriteLine("Enter your phone number:");
            client.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Your guid Id");                             
            client.Id = Guid.NewGuid();
            Console.WriteLine(client.Id);
            
            return client; 
        }
    }
}
