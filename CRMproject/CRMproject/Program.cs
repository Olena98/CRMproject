﻿using System;
using System.Collections.Generic;

namespace CRMproject
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientsDataBase.Initialize();
            ProductsDataBase.Initialize();
            OrdersDataBase.Initialize();
            UserMenu();
        }

        public static void UserMenu()
        {
            var returnUserMenu = true;
            while (returnUserMenu)
            {
                Console.WriteLine("Main menu\n\t1.Add new client\n\t2.Search client\n\t3.Edit client");
                Console.WriteLine("\t4.Add product\n\t5.Search product\n\t6.Add order\n\t7.Search order\n\t8.Change order\n\t9.Clear all");
                Console.WriteLine("Enter the item number");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.WriteLine("You have chosen add of a new client");
                        AddNewClient();
                        Console.WriteLine("Return to main menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "2":
                        Console.WriteLine("You have chosen by search of a client");
                        SearchClient();
                        Console.WriteLine("Return to main menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "3":
                        Console.WriteLine("You have chosen edit of a client");
                        EditClient(ClientsDataBase.Clients);
                        Console.WriteLine("Return to main menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "4":
                        Console.WriteLine("You have chosen add products");
                        AddProduct();
                        Console.WriteLine("Return to main menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "5":
                        Console.WriteLine("You have chosen by search product");
                        SearchProduct();
                        Console.WriteLine("Return to main menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "6":
                        Console.WriteLine("You have chosen by add order");
                        AddOrder();
                        Console.WriteLine("Return to main menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "7":
                        Console.WriteLine("You have chosen by search order");
                        SearchOrder();
                        Console.WriteLine("Return to main menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "8":
                        Console.WriteLine("You have chosen by search order");
                        ChangeOrder();
                        Console.WriteLine("Return to main menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "9":
                        Console.WriteLine("You have chosen by search product");
                        Console.Clear();
                        Console.WriteLine("Return to main menu? (Y - to yes):");
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
                Console.WriteLine("Clients search menu\n\t1.Search client by name\n\t2.Search client by email\n\t3.Search client by phone number" +
                     "\n\t4.Search client by id\n\t5.Exit");
                Console.WriteLine("Enter the item number: ");
                string itemNumber = Console.ReadLine();
                switch (itemNumber)
                {
                    case "1":
                        Console.WriteLine($"Please, enter name to search for a client");
                        string nameOfClient = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(nameOfClient))
                        {
                            Console.Write("Incorrect input");
                        }
                        else
                        {
                            var result = ClientsService.GetClientsByName(nameOfClient);
                            OutputUsersList(result);
                        }                        
                        Console.WriteLine("Return to clients search menu? (Y - to yes):");
                        searchofclient = Console.ReadLine().ToLower() == "y";
                        break;
                    case "2":
                        Console.WriteLine($"Please, enter email to search for a client");
                        string emailOfClient = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(emailOfClient))
                        {
                            Console.Write("Incorrect input");
                        }
                        else
                        {
                            var resultEmail = ClientsService.GetClientsByEmail(emailOfClient);
                            OutputUsersList(resultEmail);
                        }                        
                        Console.WriteLine("Return to clients search menu? (Y - to yes):");
                        searchofclient = Console.ReadLine().ToLower() == "y";
                        break;
                    case "3":
                        Console.WriteLine($"Please, enter phone number to search for a client");
                        string phoneOfClient = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(phoneOfClient))
                        {
                            Console.Write("Incorrect input");
                        }
                        else
                        {
                            var resultPhone = ClientsService.GetClientsByPhone(phoneOfClient);
                            OutputUsersList(resultPhone);
                        }
                        Console.WriteLine("Return to clients search menu? (Y - to yes):");
                        searchofclient = Console.ReadLine().ToLower() == "y";
                        break;
                    case "4":
                        Console.WriteLine($"Please, enter your id to search for a client");
                        Guid guidOfClient = Guid.Parse(Console.ReadLine());
                        var resultId = ClientsService.GetClientsById(guidOfClient);
                        OutputUsersList(resultId);
                        Console.WriteLine("Return to clients search menu? (Y - to yes):");
                        searchofclient = Console.ReadLine().ToLower() == "y";
                        break;
                    case "5":
                        Console.WriteLine("Return to clients search menu? (Y - to yes):");
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
                    Console.WriteLine("Name: " + c.Name);
                    Console.WriteLine("Last name: " + c.LastName);
                    Console.WriteLine("Surname: " + c.Surname);
                    Console.WriteLine("Phone number: " + c.PhoneNumber);
                    Console.WriteLine("Email: " + c.Email);
                    Console.WriteLine("Id: " + c.Id);
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
                var products = new Product();

                Console.WriteLine("Please, enter product name: ");
                products.ProductName = Console.ReadLine();

                Console.WriteLine("Please, enter product description: ");
                products.Description = Console.ReadLine();

                Console.WriteLine("Please, enter product price: ");
                decimal price;
                while(!decimal.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("Incorrect input. Please try again");
                }
                products.Price = price;

                Console.WriteLine("Please, enter product number: ");
                int number;                                 
                    if (!int.TryParse(Console.ReadLine(), out number))
                    {                       
                        products.ProductNumber = UniqueNumericNumberHelper.GetUniqueProductNumericNumber();
                    }
                    else
                    {
                        products.ProductNumber = number;
                    }
                
               
                Console.WriteLine("Please, indicate product availability, enter true or false: ");
                bool existence;
                while (!bool.TryParse(Console.ReadLine(), out existence)) 
                {
                    Console.WriteLine("Incorrect input. Please try again");
                }                
                products.Existence = existence; 
                Console.WriteLine("Products guid id: ");
                products.Id = Guid.NewGuid();
                Console.WriteLine(products.Id);

                ProductService.AddNewProduct(products);

                Console.WriteLine("Continue entering new products? (Y - to yes):");
                addProduct = Console.ReadLine().ToLower() == "y";
            }
        }

        static void SearchProduct()
        {
            var searchproduct = true;
            while (searchproduct) 
            {
                Console.WriteLine("Products search\n\t1.Search product by name\n\t2.Search product by description\n\t3.Search product by price" +
                        "\n\t4.Search product by number\n\t5.Search product by existence\n\t6.Search product by id\n\t7.Exit");
                Console.WriteLine("Enter the item number: ");
                string itemNumber = Console.ReadLine();
                switch (itemNumber)
                {
                    case "1":
                        Console.WriteLine($"Please, enter name to search for a product");
                        string nameOfProduct = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(nameOfProduct))
                        {
                            Console.Write("Incorrect input");
                        }
                        else
                        {
                            var result = ProductService.GetProductsByName(nameOfProduct);
                            OutputProductList(result);
                        }                        
                        Console.WriteLine("Return to products search menu? (Y - to yes):");
                        searchproduct = Console.ReadLine().ToLower() == "y";
                        break;
                    case "2":
                        Console.WriteLine($"Please, enter description to search for a product");
                        string descriptionOfProduct = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(descriptionOfProduct))
                        {
                            Console.Write("Incorrect input");
                        }
                        else
                        {
                            var resultDescription = ProductService.GetProductsByDescription(descriptionOfProduct);
                            OutputProductList(resultDescription);
                        }                        
                        Console.WriteLine("Return to products search menu? (Y - to yes):");
                        searchproduct = Console.ReadLine().ToLower() == "y";
                        break;
                    case "3":
                        Console.WriteLine($"Please, enter price to search for a product");
                        decimal price;
                        bool  priceOfProduct = decimal.TryParse(Console.ReadLine(), out price);
                        var resultPrice = ProductService.GetProductsByPrice(price);
                        OutputProductList(resultPrice);
                        Console.WriteLine("Return to products search menu? (Y - to yes):");
                        searchproduct = Console.ReadLine().ToLower() == "y";
                        break;
                    case "4":
                        Console.WriteLine($"Please, enter number to search for a product");
                        int number;
                        bool numberOfProduct = int.TryParse(Console.ReadLine(), out number);                         
                        var resultNumber = ProductService.GetProductsByNumber(number);
                        OutputProductList(resultNumber);
                        Console.WriteLine("Return to products search menu? (Y - to yes):");
                        searchproduct = Console.ReadLine().ToLower() == "y";
                        break;
                    case "5":
                        Console.WriteLine($"Please, enter existence to search for a product (true or false)");
                        bool existence;
                        bool existenceOfProduct = bool.TryParse(Console.ReadLine(), out existence);
                        var resultExistence = ProductService.GetProductsByExistence(existence);                       
                        OutputProductList(resultExistence);
                        Console.WriteLine("Return to products search menu? (Y - to yes):");
                        searchproduct = Console.ReadLine().ToLower() == "y";
                        break;
                    case "6":
                        Console.WriteLine($"Please, enter description to search for a product");
                        Guid guidOfProduct = Guid.Parse(Console.ReadLine());
                        var resultGuid = ProductService.GetProductsById(guidOfProduct);
                        OutputProductList(resultGuid);
                        Console.WriteLine("Return to products search menu? (Y - to yes):");
                        searchproduct = Console.ReadLine().ToLower() == "y";
                        break;
                    case "7":
                        Console.WriteLine("Return to products search menu? (Y - to yes):");
                        searchproduct = Console.ReadLine().ToLower() == "y";
                        break;
                }
            }           
        }

        static void AddOrder() 
        {
            var addOrder = true;
            while (addOrder) 
            {
                var orders = new Order();
               
                              
                Console.WriteLine("You order date: ");
                orders.OrderDate = DateTime.Now;
                Console.WriteLine(orders.OrderDate);

                Console.WriteLine("Please, enter order number: ");
                int number;
                if (!int.TryParse(Console.ReadLine(), out number))
                {
                    orders.OrderNumber = UniqueNumericNumberHelper.GetUniqueOrderNumericNumber();
                }
                else
                {
                    orders.OrderNumber = number;
                }
                Console.WriteLine("Please, enter order status, for example: new, paid, is making up, sent, completed, canceled: ");
                Order.OrderStatus.New.ToString(Console.ReadLine());

                Console.WriteLine("Please, enter client phone number: ");               
                orders.ClientPhone = Console.ReadLine();

                Console.WriteLine("Orders guid id: ");
                orders.OrderId = Guid.NewGuid();
                Console.WriteLine(orders.OrderId);

                Console.WriteLine("Please, enter client id: ");
                orders.ClientId = Guid.Parse(Console.ReadLine());

                Console.WriteLine("Please, enter product id: ");
                orders.ProductsId = Guid.Parse(Console.ReadLine());


                OrderService.AddNewOrder(orders);

                Console.WriteLine("Continue entering new orders? (Y - to yes):");
                addOrder = Console.ReadLine().ToLower() == "y";

               
            }
        }

        static void SearchOrder() 
        {
            var searchOrder = true;
            while (searchOrder) 
            {
                Console.WriteLine("Orders search\n\t1.Search order by date\n\t2.Search order by number\n\t3.Search order by status\n\t4.Search order by clients phone number\n\t5.Search order by client id"+
                    "\n\t6.Search order by product id\n\t7.Search order by id\n\t8.Exit");
                Console.WriteLine("Enter the item number: ");
                string itemNumber = Console.ReadLine();
                switch (itemNumber) 
                {
                    case "1":
                        Console.WriteLine($"Please, enter date to search for an order");
                        DateTime dateOfOrder = DateTime.Parse(Console.ReadLine());
                        var result = OrderService.GetOrdersByDate(dateOfOrder);
                        OutputOrderList(result);
                        Console.WriteLine("Return to orders search menu? (Y - to yes):");
                        searchOrder = Console.ReadLine().ToLower() == "y";
                        break;
                    case "2":
                        Console.WriteLine($"Please, enter number to search for an order");
                        int number;
                        bool numberOfOrder = int.TryParse(Console.ReadLine(), out number);
                        var resultNumber = OrderService.GetOrdersByNumber(number);
                        OutputOrderList(resultNumber);
                        Console.WriteLine("Return to orders search menu? (Y - to yes):");
                        searchOrder = Console.ReadLine().ToLower() == "y";
                        break;
                    case "3":
                        Console.WriteLine($"Please, enter status to search for an order (keywords for example: new, paid, is making up, sent, completed, canceled)");
                        string orderStatus = Console.ReadLine();
                        var resultStatus = OrderService.GetOrdersByStatus(orderStatus);
                        OutputOrderList(resultStatus);
                        Console.WriteLine("Return to orders search menu? (Y - to yes):");
                        searchOrder = Console.ReadLine().ToLower() == "y";
                        break;
                    case "4":
                        Console.WriteLine("Please, enter clients phone to search for an order: ");
                        string phoneNumber = Console.ReadLine();                                               
                        var resultPhone = OrderService.GetOrdersByPhone(phoneNumber);                       
                        OutputOrderList(resultPhone);
                        Console.WriteLine("Return to orders search menu? (Y - to yes):");
                        searchOrder = Console.ReadLine().ToLower() == "y";
                        break;
                    case "5":
                        Console.WriteLine("Please, enter client id to search for an order: ");
                        Guid guidOfClientId = Guid.Parse(Console.ReadLine());
                        var resultClientGuidId = OrderService.GetOrdersByClientGuid(guidOfClientId);                      
                        OutputOrderList(resultClientGuidId);
                        Console.WriteLine("Return to orders search menu? (Y - to yes):");
                        searchOrder = Console.ReadLine().ToLower() == "y";
                        break;
                    case "6":
                        Console.WriteLine("Please, enter product id to search for an order: ");
                        Guid guidOfProductId = Guid.Parse(Console.ReadLine());                      
                        var resultProductGuidId = OrderService.GetOrdersByProductsGuid(guidOfProductId);                       
                        OutputOrderList(resultProductGuidId);
                        Console.WriteLine("Return to orders search menu? (Y - to yes):");
                        searchOrder = Console.ReadLine().ToLower() == "y";
                        break;

                    case "7":
                        Console.WriteLine($"Please, enter id to search for an order");
                        Guid guidOfOrder = Guid.Parse(Console.ReadLine());
                        var resultId = OrderService.GetOrdersById(guidOfOrder);
                        OutputOrderList(resultId);
                        Console.WriteLine("Return to orders search menu? (Y - to yes):");
                        searchOrder = Console.ReadLine().ToLower() == "y";
                        break;
                    case "8":
                        Console.WriteLine("Return to orders search menu? (Y - to yes):");
                        searchOrder = Console.ReadLine().ToLower() == "y";
                        break;

                }
            }     
        }

        static void OutputOrderList(List<Order> orders) 
        {
            if(orders.Count == 0) 
            {
                Console.WriteLine("No results, please try again");
            }
            else 
            {
                Console.WriteLine("Count of orders: " + orders.Count);

                foreach (Order o in orders)
                {
                    Console.WriteLine("Order date: " + o.OrderDate);                   
                    Console.WriteLine("Order number: " + o.OrderNumber);
                    Console.WriteLine("Order status: " + Order.OrderStatus.New);
                    Console.WriteLine("Client phone: " + o.ClientPhone);
                    Console.WriteLine("Client id: " + o.ClientId);
                    Console.WriteLine("Product id: " + o.ProductsId);
                    Console.WriteLine("Id: " + o.OrderId);
                    Console.WriteLine();
                }

            }
        }


        static void OutputProductList(List<Product> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No results, please try again");               
            }
            else
            {
                Console.WriteLine("Count of products: " + products.Count);

                foreach (Product p in products)
                {
                    Console.WriteLine("Product name: " + p.ProductName);
                    Console.WriteLine("Description: " + p.Description);
                    Console.WriteLine("Price: " + p.Price);
                    Console.WriteLine("Product number: " + p.ProductNumber);
                    Console.WriteLine("Existense: " + p.Existence);
                    Console.WriteLine("Id: " + p.Id);
                    Console.WriteLine();
                }
            }
        }
        static void ChangeOrder() 
        {
            Order.ChangeEntry changeEntry = new Order.ChangeEntry();
            var changeOrder = true;
            while (changeOrder) 
            {
                Console.WriteLine("Change order menu\n\t1. Find order for changes\n\t2. Set orders status and set orders date\n\t4. Exit");
                Console.WriteLine("Enter the item number: ");
                string itemNumber = Console.ReadLine();
                switch (itemNumber) 
                {
                    case "1":
                        OutputChangeOrderList(OrdersDataBase.Orders);
                        Console.WriteLine("Please, select orders number");
                        int index;
                        bool indexOfNumber = int.TryParse(Console.ReadLine(), out index);
                        Console.WriteLine("You entered: " + index);              
                        break;
                    case "2":                       
                        Console.WriteLine("Please, set new order status: ");
                        changeEntry.Status = Console.ReadLine();
                      
                       
                       
                        break;
                    case "3":
                        Console.WriteLine("Return to orders change menu? (Y - to yes):");
                        changeOrder = Console.ReadLine().ToLower() == "y";
                        break;
                       
                }
            }
        }
        static void OutputChangeOrderList(List<Order> orders)
        {
            Console.WriteLine("Count of orders: " + orders.Count);
            for (int i = 1; i < orders.Count; i++) 
            {
                 Console.WriteLine("№: " + i);
                 Console.WriteLine("Order date: " + orders[i].OrderDate);
                 Console.WriteLine("Order number: " + orders[i].OrderNumber);
                 Console.WriteLine("Order status: " + Order.OrderStatus.New);
                 Console.WriteLine("Client phone: " + orders[i].ClientPhone);
                 Console.WriteLine("Client id: " + orders[i].ClientId);
                 Console.WriteLine("Product id: " + orders[i].ProductsId);
                 Console.WriteLine("Id: " + orders[i].OrderId);
                 Console.WriteLine();

            }
           


        }
        
    }
}

