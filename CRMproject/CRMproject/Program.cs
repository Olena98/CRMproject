using System;

namespace CRMproject
{
    class Program
    {
        static void Main(string[] args)
        {
            var continueEnteringNewUsers = true;

            while(continueEnteringNewUsers)
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
                client.Id = Guid.NewGuid();

                DataBase.Clients.Add(client);

                Console.WriteLine("Continue entering new users? (Y - to yes):");
                continueEnteringNewUsers = Console.ReadLine().ToLower() == "y";
            }

            Console.WriteLine($"Count of users: {DataBase.Clients.Count}");
        }
    }
}


