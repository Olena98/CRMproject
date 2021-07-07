using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace CRMproject
{
    class Program 
    {

        static void Main(string[] args)
        {
            var continueEnteringNewUser = true;

            while (continueEnteringNewUser)
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

                DataBase.SaveClient(client);

                Console.WriteLine("Continue entering new users? (Y - to yes):");
                continueEnteringNewUser = Console.ReadLine().ToLower() == "y";
              
                Console.ReadLine();

            }
        }
    }

}

