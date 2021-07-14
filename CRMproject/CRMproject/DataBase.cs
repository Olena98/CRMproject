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
        public static void SaveClient(Client client)
        {         
            string path = ("C://Users//Olena//clients.xml");
            FileInfo fileInf = new FileInfo(path);
            XmlDocument xDoc = new XmlDocument();
            XmlNode rootElement = null;
            
            try
            {
                if (fileInf.Exists)
                {
                    xDoc.Load(path);
                    rootElement = xDoc.DocumentElement;
                }
                else
                {
                    rootElement = xDoc.CreateNode(XmlNodeType.Element, "clients", string.Empty);
                    xDoc.AppendChild(rootElement);
                }
            }
            catch
            {
                rootElement = xDoc.CreateNode(XmlNodeType.Element, "clients", string.Empty);
                xDoc.AppendChild(rootElement);
                Console.WriteLine("An exception was thrown!");
            }
         
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

            clientElem.Attributes.Append(nameAttr);
            clientElem.Attributes.Append(lastnameAttr);
            clientElem.Attributes.Append(surnameAttr);
            clientElem.Attributes.Append(emailAttr);
            clientElem.Attributes.Append(phonenumberAttr);

            rootElement.AppendChild(clientElem);
            xDoc.Save(path);

            Console.WriteLine($"Count of users: {Clients.Count}");
        }
    }
}


