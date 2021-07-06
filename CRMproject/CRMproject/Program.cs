using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;

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
                XmlDocument xDoc = new XmlDocument();
                if (fileInf.Exists)
                {
                    xDoc.Load(path);
                }
                else
                {
                    var rootElement = xDoc.CreateNode(XmlNodeType.Element, "clients", string.Empty);
                    xDoc.AppendChild(rootElement);
                }
                try
                {
                    xDoc.Load(path);
                }
                catch (FormatException)
                {
                    Console.WriteLine("An exception was thrown!");
                }
                finally
                {
                    Console.WriteLine("Final blok");
                    var rootElement = xDoc.CreateNode(XmlNodeType.Element, "clients", string.Empty);
                   
                }
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
                xDoc.Save(path);

                Console.WriteLine($"Count of users: {client}");
                Console.ReadLine();

            }
        }
    }

}

