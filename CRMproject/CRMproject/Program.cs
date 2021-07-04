using System;
using System.Xml;
using System.IO;


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


                string path = ("C://Users//Olena//clients.xml");
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    fileInf.Create();
                }

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("C://Users//Olena//clients.xml");
                XmlElement xRoot = xDoc.DocumentElement;


                XmlElement clientElem = xDoc.CreateElement("client");

                XmlAttribute nameAttr = xDoc.CreateAttribute("name");
                nameAttr.Value = client.Name;
                XmlAttribute lastnameAttr = xDoc.CreateAttribute("lastname");
                lastnameAttr.Value = client.LastName;
                XmlAttribute surnameAttr = xDoc.CreateAttribute("surname");
                surnameAttr.Value = client.Surname;
                XmlAttribute emailAttr = xDoc.CreateAttribute("email");
                emailAttr.Value = client.Email;
                XmlAttribute phonenumberAttr = xDoc.CreateAttribute("phonenumber");
                phonenumberAttr.Value = client.PhoneNumber;

                XmlElement lastnameElem = xDoc.CreateElement("lastname");
                XmlElement surnameElem = xDoc.CreateElement("surname");
                XmlElement emailElem = xDoc.CreateElement("email");
                XmlElement pnonenumberElem = xDoc.CreateElement("phonenumber");
                
                clientElem.Attributes.Append(nameAttr);
                clientElem.Attributes.Append(lastnameAttr);
                clientElem.Attributes.Append(surnameAttr);
                clientElem.Attributes.Append(emailAttr);
                clientElem.Attributes.Append(phonenumberAttr);

                xRoot.AppendChild(clientElem);
                xDoc.Save("C://Users//Olena//clients.xml");

                Console.WriteLine($"Count of users: {client}");
                Console.ReadLine();
               



            }

        }
        }
    }



