using System;
using System.Collections.Generic;


namespace CRMproject
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter your  surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your phone number:");
            string pnonenumber = Console.ReadLine();
            Guid g = Guid.NewGuid();
            Console.WriteLine(g);
            List<Client> people = new List<Client>(3);
            people.Add(new Client() { Name = "aaa", LastName = "bbb", Surname = "ссс", Email = "ddd@", PhoneNumber = "+000"});
            people.Add(new Client() { Name = "eee", LastName = "fff", Surname = "ggg", Email = "hhh@", PhoneNumber = "+111" });

            foreach (Client p in people)
            {
                Console.WriteLine(p.Name);
            }

        }
       
    }
}


