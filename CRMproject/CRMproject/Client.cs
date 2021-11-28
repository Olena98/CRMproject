using System;
using System.Collections.Generic;
using System.Text;


namespace CRMproject
{
    class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public List<ChangeEntry> ChangesEntries { get; set; }

        public override string ToString()
        {
            var result = "Client Name: " + Name + "\n\t Client LastName: " + LastName + "\n\t Client Surname: " + Surname + "\n\t Client email: " + Email +
                "\n\t Client phone: " + PhoneNumber + "\n\t Client Id: " + Id.ToString();
            result += $"\n\tChange Entries Count: {ChangesEntries.Count}\n";
            foreach (var entry in ChangesEntries)
            {
                result += $"\t\t{entry.Name} - {entry.Surname} - {entry.PhoneNumber}-{entry.Email}\n";
            }
            result = result.Remove(result.Length - 1);
            return result;
        }

        public class ChangeEntry 
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Surname { get; set; }
        
        }

    }
}

    


   