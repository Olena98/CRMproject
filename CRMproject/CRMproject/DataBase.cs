using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;


namespace CRMproject
{
    class DataBase
    {
        private static readonly List<Client> Clients = new List<Client>();
        public void AddClient(Client client)
        {
            Clients.Add(client);
        }
        public static void GetClient(string name)
        {
            new Client { Name = name };
        }
    }
}


