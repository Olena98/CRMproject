using System;
using System.Text;


namespace CRMproject
{
    [Serializable]
    class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }

        
    }
}

    


   