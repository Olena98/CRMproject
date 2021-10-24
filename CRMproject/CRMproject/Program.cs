using System;
using System.Collections.Generic;

namespace CRMproject
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase.Initialize();
            ProductsDataBase.Initialize();
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
                        EditClient(DataBase.Clients);
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
            var searchofclient = true;
            while (searchofclient)
            {
                Console.WriteLine("\t1.Search client by name\n\t2.Search client by email\n\t3.Search client by phone number" +
                     "\n\t4.Search client by id");
                Console.WriteLine("Enter the item number: ");
                string itemNumber = Console.ReadLine();
                switch (itemNumber)
                {
                    case "1":
                        Console.WriteLine($"Please, enter name to search for a client");
                        string nameOfClient = Console.ReadLine();
                        var result = ClientsService.GetClientsByName(nameOfClient);
                        OutputUsersList(result);
                        Console.WriteLine("Return menu? (Y - to yes):");
                        searchofclient = Console.ReadLine().ToLower() == "y";
                        break;
                    case "2":
                        Console.WriteLine($"Please, enter email to search for a client");
                        string emailOfClient = Console.ReadLine();
                        var resultEmail = ClientsService.GetClientsByEmail(emailOfClient);
                        OutputUsersList(resultEmail);
                        Console.WriteLine("Return menu? (Y - to yes):");
                        searchofclient = Console.ReadLine().ToLower() == "y";
                        break;
                    case "3":
                        Console.WriteLine($"Please, enter phone number to search for a client");
                        string phoneOfClient = Console.ReadLine();
                        var resultPhone = ClientsService.GetClientsByPhone(phoneOfClient);
                        OutputUsersList(resultPhone);
                        Console.WriteLine("Return menu? (Y - to yes):");
                        searchofclient = Console.ReadLine().ToLower() == "y";
                        break;
                    case "4":
                        Console.WriteLine($"Please, enter your id to search for a client");
                        Guid guidOfClient = Guid.Parse(Console.ReadLine());
                        var resultId = ClientsService.GetClientsById(guidOfClient);
                        OutputUsersList(resultId);
                        Console.WriteLine("Return menu? (Y - to yes):");
                        searchofclient = Console.ReadLine().ToLower() == "y";
                        break;
                }
            }
        }

        static void OutputUsersList(List<Client> clients)
        {
            if (clients.Count == 0)
            {
                Console.WriteLine("No results");
            }
            else
            {
                Console.WriteLine("Count of users: " + clients.Count);

                foreach (Client c in clients)
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

        static void EditClient(List<Client>clients)
        {
            string clientsEdit = Console.ReadLine();
            var result = clients.ToString().Insert(0, clientsEdit);
            Console.WriteLine(result);
        }

        static void AddProduct()
        {
            var addProduct = true;
            while (addProduct)
            {
                var products = new Products();
                Console.WriteLine("Please, enter product name: ");
                products.ProductName = Console.ReadLine();
                Console.WriteLine("Please, enter product description: ");
                products.Description = Console.ReadLine();
                Console.WriteLine("Please, enter product price: ");
                products.Price.ToString(Console.ReadLine());
                Console.WriteLine("Please, enter product number: ");
                products.ProductNumber.ToString(Console.ReadLine());
                Console.WriteLine("Please, indicate product availability, enter true or false: ");
                products.Existence = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine("Products guid id: ");
                products.Id = Guid.NewGuid();
                Console.WriteLine(products.Id);

                ProductService.AddNewProduct(products);

                Console.WriteLine("Continue entering new users? (Y - to yes):");
                addProduct = Console.ReadLine().ToLower() == "y";
            }
        }

        static void ProductList()
        {            
            ProductsDataBase.AddProductsList();
           
        }       
    }
}

