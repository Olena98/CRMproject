using System;
using System.Linq;
using System.Collections.Generic;

namespace CRMproject
{
    class ClientsService
    {
        public static void AddNewClient(Client client)
        {
            ClientsDataBase.AddClient(client);
        }
        public static List<Client> GetClientsByName(string name)
        {
            name = name.ToUpper();
            return ClientsDataBase.Clients.Where(c => c.Name.ToUpper().Contains(name)).ToList();

        }
        public static List<Client> GetClientsByEmail(string email) 
        {
            email = email.ToUpper();
            return ClientsDataBase.Clients.Where(c => c.Email.ToUpper().Contains(email)).ToList();

        }
        public static List<Client> GetClientsByPhone(string phonenumber) 
        {
            return ClientsDataBase.Clients.Where(c => c.PhoneNumber.Contains(phonenumber)).ToList();
        }
        public static List<Client> GetClientsById(Guid guid) 
        {
           
            return ClientsDataBase.Clients.Where(c => c.Id == guid).ToList();
        }
    }
}
