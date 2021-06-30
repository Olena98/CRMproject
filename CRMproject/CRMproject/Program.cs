using System;
using System.Xml;

namespace CRMproject
{
    class Program
    {

        static void Main(string[] args)
        {
            var continueEnteringNewUser = true;

            while (continueEnteringNewUser)
            {
                Client client = new Client();

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
                client.Id = Guid.NewGuid();


              
                Console.WriteLine("Continue entering new users? (Y - to yes):");
                continueEnteringNewUser = Console.ReadLine().ToLower() == "y";


                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("C://Users//Olena//clients.xml");
                XmlElement xRoot = xDoc.DocumentElement;

                XmlElement clientElem = xDoc.CreateElement("client");

                XmlAttribute nameAttr = xDoc.CreateAttribute("name");

                XmlElement lastnameElem = xDoc.CreateElement("lastname");
                XmlElement surnameElem = xDoc.CreateElement("surname");
                XmlElement emailElem = xDoc.CreateElement("email");
                XmlElement pnonenumberElem = xDoc.CreateElement("phonenumber");

                clientElem.Attributes.Append(nameAttr);
                clientElem.AppendChild(lastnameElem);
                clientElem.AppendChild(surnameElem);
                clientElem.AppendChild(emailElem);
                clientElem.AppendChild(pnonenumberElem);

                xRoot.AppendChild(clientElem);
                xDoc.Save("C://Users//Olena//clients.xml");

                Console.WriteLine($"Count of users: {client}");
                Console.ReadLine();


                   
            }
                
            }
        }
    }



