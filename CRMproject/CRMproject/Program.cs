using System;

namespace CRMproject
{
    class Program
    {
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
                        Console.WriteLine("You click 1");
                        AddNewClient();                        
                        Console.WriteLine("Return menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;                  
                    case "2":
                        Console.WriteLine("You click 2");
                        SearchClient();
                        Console.WriteLine("Return menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "3":
                        Console.WriteLine("You click 3");
                        EditClient();
                        Console.WriteLine("Return menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "4":
                        Console.WriteLine("You click 4");
                        AddProduct();
                        Console.WriteLine("Return menu? (Y - to yes):");
                        returnUserMenu = Console.ReadLine().ToLower() == "y";
                        break;
                    case "5":
                        Console.WriteLine("You click 5");
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
                    Client client = new Client();

                    ClientsService.EnterClient();
                    
                    DataBase.SaveClient(client);
                   

                    Console.WriteLine("Continue entering new users? (Y - to yes):");
                    continueEnteringNewUser = Console.ReadLine().ToLower() == "y";
 
                }
            }
            static void SearchClient()
            {
                Console.WriteLine("Please, enter data to search for a client");
                Console.ReadLine();               
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

        static void Main(string[] args)
        {
            UserMenu();
          
        }
    
    }
}