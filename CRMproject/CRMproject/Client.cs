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

        public class ChangeEntry 
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Surname { get; set; }
            public string LastName { get; set; }
        }

    }
}

    


   