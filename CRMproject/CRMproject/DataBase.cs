using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;


namespace CRMproject
{
    class DataBase
    {
        public static List<Client> Clients { get;  private set; }

        private const string xmlPath = "C://Users//Olena//Documents//clients.xml";

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "clients.xml");

        public static void Initialize()
        {
            Clients = ReadXmlFile(xmlPath);
        }
        
        public static void AddClient(Client client)
        {
            SaveClient(client);
            Clients.Add(client);
        }
        public static void SaveClient(Client client)
        {
           
            FileInfo fileInf = new FileInfo(xmlPath);
            XmlDocument xDoc = new XmlDocument();
            XmlNode rootElement = null;
          
            try
            {
                if (fileInf.Exists)
                {
                    xDoc.Load(xmlPath);
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
            xDoc.Save(xmlPath);
            
       
        }

        public static List<Client> ReadXmlFile(string xmlPath)
        {
          
            List<Client> clients = new List<Client>();
            var doc = new XmlDocument();
            doc.Load(xmlPath);
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
                    XmlNode attrGuid = xnode.Attributes.GetNamedItem("guid");
                    if (attrGuid != null)
                    {
                        client.Id = Guid.Parse(attrGuid.Value);
                    }
                    clients.Add(client);
                }                                             
            }
            return clients;       
        }
    }
}




