using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;


namespace CRMproject
{
    class DataBase
    {
        private static List<Client> clients = new List<Client>();

        public static void Initialize()
        {
            clients = ReadXmlFile("C://Users//Olena//clients.xml"); 


            foreach (Client c in clients)
            {

                Console.WriteLine(c.Name);
            }
        }
        
        public void AddClient(Client client)
        {
            clients.Add(client);
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
            XmlAttribute guidAttr = xDoc.CreateAttribute("guid");
            guidAttr.Value = client.Id.ToString();

            clientElem.Attributes.Append(nameAttr);
            clientElem.Attributes.Append(lastnameAttr);
            clientElem.Attributes.Append(surnameAttr);
            clientElem.Attributes.Append(emailAttr);
            clientElem.Attributes.Append(phonenumberAttr);
            clientElem.Attributes.Append(guidAttr);

            rootElement.AppendChild(clientElem);
            xDoc.Save(path);
            ReadXmlFile(path);
       
        }

        public static List<Client> ReadXmlFile(string path)
        {
          
            List<Client> clients = new List<Client>();
            var doc = new XmlDocument();
            doc.Load(path);
            var xRoot = doc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {      

                if (xnode.Attributes.Count > 0)
                {
                    Client client = new Client();     

                    XmlNode attrName = xnode.Attributes.GetNamedItem("name");
                    if (attrName != null)
                    {
                        client.Name = attrName.Value;                      
                    }
                    XmlNode attrLastname = xnode.Attributes.GetNamedItem("lastname");
                    if (attrLastname != null)
                    {
                        client.LastName = attrLastname.Value;                     
                    }
                    XmlNode attrSurname = xnode.Attributes.GetNamedItem("surname");
                    if (attrSurname != null)
                    {
                        client.Surname = attrSurname.Value;                      
                    }
                    XmlNode attrEmail = xnode.Attributes.GetNamedItem("email");
                    if (attrEmail != null)
                    {
                        client.Email = attrEmail.Value;                       
                    }
                    XmlNode attrPhonenumber = xnode.Attributes.GetNamedItem("phonenumber");
                    if (attrPhonenumber != null)
                    {
                        client.PhoneNumber = attrPhonenumber.Value;                      
                    }
                    clients.Add(client);
                }                                             
            }
            return clients;       
        }
    }
}




