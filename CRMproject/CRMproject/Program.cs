using System;
using System.Collections.Generic;

namespace CRMproject
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase.Initialize();
            UserMenu();
        }

        public static void UserMenu()
        {
            var returnUserMenu = true;
            while (returnUserMenu)
            {
                Console.WriteLine("\t1.Add new client\n\t2.Search client\n\t3.Edit client");
                Console.WriteLine("\t4.Add product\n\t5.Product list");
                Console.WriteLine("Enter the item number");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.WriteLine("You have chosen add of a new client");
                        AddNewClient();
                        Console.WriteLine("Return menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "2":
                        Console.WriteLine("You have chosen by search of a client");
                        SearchClient();
                        Console.WriteLine("Return menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "3":
                        Console.WriteLine("You have chosen edit of a client");
                        EditClient();
                        Console.WriteLine("Return menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "4":
                        Console.WriteLine("You have chosen add products");
                        AddProduct();
                        Console.WriteLine("Return menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "5":
                        Console.WriteLine("You have chosen a product list");
                        ProductList();
                        Console.WriteLine("Return menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                }
            }

            static void AddNewClient()
            {
                var continueEnteringNewUser = true;


                while (continueEnteringNewUser)
                {
                    var client = new Client();
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

                    ClientsService.AddNewClient(client);

                    Console.WriteLine("Continue entering new users? (Y - to yes):");
                    continueEnteringNewUser = Console.ReadLine().ToLower() == "y";
                }
            }

            static void SearchClient()
            {
                Console.WriteLine($"Please, enter name to search for a client");               
                string nameOfClient = Console.ReadLine();
                var result = ClientsService.GetClientsByName(nameOfClient);
                if (result.Count == 0) 
                {
                    Console.WriteLine("Don`t find users");
                }
                else if(result.Count != 0) 
                {
                    Console.WriteLine("Count of users: "+ result.Count);

                    foreach (Client c in result)
                    {
                        Console.WriteLine(c.Name);
                        Console.WriteLine(c.LastName);
                        Console.WriteLine(c.Surname);
                        Console.WriteLine(c.PhoneNumber);
                        Console.WriteLine(c.Email);
                        Console.WriteLine(c.Id);
                        Console.WriteLine();
                    }
                }
            }

            static void EditClient()
            {
                Console.WriteLine("Please, enter the data to change the client");
                Console.ReadLine();
            }
            static void AddProduct()
            {
                Console.WriteLine("Please, enter new product");
                Console.ReadLine();

            }
            static void ProductList()
            {
                Console.WriteLine("Here you can view a list of your products");
                Console.ReadLine();
            }
        }
    }
}