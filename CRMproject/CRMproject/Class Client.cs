using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CRMproject
{
  

    class Client
  
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public Guid Id { get; set; }
    }

    


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
           
        }
    }
}
