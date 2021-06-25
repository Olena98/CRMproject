using System;
using System.Collections.Generic;
using System.Text;

namespace CRMproject
{
    class DataBase
    {
        static void Main(string[] args)


        {
            List<Client> people = new List<Client>(3);
            people.Add(new Client() { Name = "aaa", LastName = "bbb", Surname = "ссс", Email = "ddd@", PhoneNumber = "+000" });
            people.Add(new Client() { Name = "eee", LastName = "fff", Surname = "ggg", Email = "hhh@", PhoneNumber = "+111" });

            foreach (Client p in people)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}



