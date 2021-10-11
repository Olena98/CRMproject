using System;
using System.Linq;
using System.Collections.Generic;

namespace CRMproject
{
    class ClientsService
    {
        public static void AddNewClient(Client client)
        {
            DataBase.AddClient(client);
        }
        public static List<Client> GetClientsByName(string name)
        {
            name = name.ToUpper();
            return DataBase.Clients.Where(c => c.Name.ToUpper().Contains(name)).ToList();

        }
        public static List<Client> GetClientsByEmail(string email) 
        {
            email = email.ToUpper();
            return DataBase.Clients.Where(c => c.Email.ToUpper().Contains(email)).ToList();

        }
        
    }
}
