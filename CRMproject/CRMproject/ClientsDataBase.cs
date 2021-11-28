using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;


namespace CRMproject
{
    class ClientsDataBase
    {
        public static List<Client> Clients { get;  private set; }

        private static string xmlPath;

        public static void Initialize()
        {
            xmlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "clients.xml");           
            Clients = ReadXmlFile(xmlPath);                    
        }
        
        public static void AddClient(Client client)
        {
            Clients.Add(client);
            SaveClientsList();            
        }
        public static void SaveClientsList()
        {
            if (Clients == null || Clients.Count == 0)
            {
                return;
            }

            XmlDocument xDoc = new XmlDocument();
            XmlNode rootElement = xDoc.CreateNode(XmlNodeType.Element, "clients", string.Empty);
            xDoc.AppendChild(rootElement);

            foreach (var client in Clients)
            {
                AppendOrderNode(rootElement, client);
            }
            xDoc.Save(xmlPath);
        }

        private static void AppendOrderNode(XmlNode parentNode, Client client) 
        {
            XmlElement clientElem = parentNode.OwnerDocument.CreateElement("client");
            clientElem.SetAttribute("guid", client.Id.ToString());
            clientElem.SetAttribute("name", client.Name);
            clientElem.SetAttribute("lastname", client.LastName);
            clientElem.SetAttribute("surname", client.Surname);
            clientElem.SetAttribute("email", client.Email);
            clientElem.SetAttribute("phonenumber", client.PhoneNumber);

            AddChangeEntriesNode(clientElem, client.ChangesEntries);
            parentNode.AppendChild(clientElem);

        }

        public static List<Client> ReadXmlFile(string xmlPath)
        {       
            List<Client> clients = new List<Client>();
            var doc = new XmlDocument();           
            if (!File.Exists(xmlPath))
            {
                doc.CreateNode(XmlNodeType.Element, "clients", string.Empty);
                doc.Save(xmlPath);                     
            }
            else
            {
                doc.Load(xmlPath);
            }
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
                    var changeEntries = new List<Client.ChangeEntry>();
                    foreach (XmlNode storyNode in xnode.ChildNodes)
                    {
                        if (storyNode.Name.Equals("story"))
                        {
                            var entry = new Client.ChangeEntry();
                            entry.Name = storyNode.Attributes["name"].Value;
                            entry.Surname = storyNode.Attributes["surname"].Value;
                            entry.PhoneNumber = storyNode.Attributes["phonenumber"].Value;
                            entry.Email = storyNode.Attributes["email"].Value;
                            
                            changeEntries.Add(entry);
                        }
                    }

                    client.ChangesEntries = changeEntries;
                    clients.Add(client);
                }                                             
            }
            return clients;       
        }
        public static void AddChangeEntriesNode(XmlNode orderNode, List<Client.ChangeEntry> entries)
        {
            if (entries == null || entries.Count == 0)
            {
                return;
            }

            foreach (var entry in entries)
            {
                var changeEntry = orderNode.OwnerDocument.CreateElement("story");
                changeEntry.SetAttribute("name", entry.Name);
                changeEntry.SetAttribute("surname", entry.Surname);
                changeEntry.SetAttribute("phonenumber", entry.PhoneNumber);
                changeEntry.SetAttribute("email", entry.Email);

                orderNode.AppendChild(changeEntry);
            }

        }
    }
}




