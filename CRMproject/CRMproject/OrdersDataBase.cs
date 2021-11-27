using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Text;

namespace CRMproject
{
    class OrdersDataBase
    {
        public static List<Order> Orders { get; private set; }

        private static string xmlPath;

        public static void Initialize() 
        {
            xmlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "orders.xml");
            Orders = ReadXmlFile(xmlPath);
           
        }
        public static void AddNewOrder(Order order)
        {         
            Orders.Add(order);
            SaveOrdersList();
        }

        public static void SaveOrdersList()
        {
            if(Orders == null || Orders.Count == 0)
            {
                return;
            }

            XmlDocument xDoc = new XmlDocument();
            XmlNode rootElement = xDoc.CreateNode(XmlNodeType.Element, "orders", string.Empty);
            xDoc.AppendChild(rootElement);

            foreach(var order in Orders)
            {
                AppendOrderNode(rootElement, order);
            }

            xDoc.Save(xmlPath);
        }
       
        private static void AppendOrderNode(XmlNode parentNode, Order order)
        {
            XmlElement orderElem = parentNode.OwnerDocument.CreateElement("order");
            orderElem.SetAttribute("guid", order.OrderId.ToString());
            orderElem.SetAttribute("orderDate", order.OrderDate.ToString());
            orderElem.SetAttribute("orderStatus", order.Status.ToString());
            orderElem.SetAttribute("orderNumber", order.OrderNumber.ToString());
            orderElem.SetAttribute("clientPhone", order.ClientPhone?.ToString());
            orderElem.SetAttribute("clientsId", order.ClientId.ToString());
            orderElem.SetAttribute("productId", order.ProductsId.ToString());

            AddChangeEntriesNode(orderElem, order.ChangesEntries);

            parentNode.AppendChild(orderElem);

        }

        public static List<Order> ReadXmlFile(string xmlPath)
        {
            
            List<Order> orders = new List<Order>();
            var doc = new XmlDocument();

            if (File.Exists(xmlPath))
            {
                doc.Load(xmlPath);
            }
            else
            {
                File.Create(xmlPath);
                doc.CreateElement("orders");
            }
            var xRoot = doc.DocumentElement;
          
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    Order order = new Order();
                    
                    XmlNode attrOrderDate = xnode.Attributes.GetNamedItem("orderDate");
                    if (attrOrderDate != null)
                    {
                        order.OrderDate = DateTime.Parse(attrOrderDate.Value);
                    }
                    XmlNode attrOrderNumber = xnode.Attributes.GetNamedItem("orderNumber");
                    if (attrOrderNumber != null)
                    {
                        order.OrderNumber = Convert.ToInt32(attrOrderNumber.Value);
                    }
                    XmlNode attrOrderStatus = xnode.Attributes.GetNamedItem("orderStatus");
                    if (attrOrderStatus != null)
                    {
                       order.Status = (Order.OrderStatus)Enum.Parse(typeof(Order.OrderStatus), attrOrderStatus.Value);                       
                    }
                    XmlNode attrOrderClientPhone = xnode.Attributes.GetNamedItem("clientPhone");
                    if (attrOrderClientPhone != null)
                    {
                        order.ClientPhone = attrOrderClientPhone.Value;
                    }
                    XmlNode attrClientId = xnode.Attributes.GetNamedItem("clientsId");
                    if (attrClientId != null)
                    {
                        order.ClientId = Guid.Parse(attrClientId.Value);
                    }
                    XmlNode attrProductId = xnode.Attributes.GetNamedItem("productId");
                    if (attrProductId != null)
                    {
                        order.ProductsId = Guid.Parse(attrProductId.Value);
                    }
                    XmlNode attrGuid = xnode.Attributes.GetNamedItem("guid");
                    if (attrGuid != null)
                    {
                        order.OrderId = Guid.Parse(attrGuid.Value);
                    }

                    var changeEntries = new List<Order.ChangeEntry>();
                    foreach(XmlNode storyNode in xnode.ChildNodes)
                    {
                        if(storyNode.Name.Equals("story"))
                        {
                            var entry = new Order.ChangeEntry();
                            entry.Status = (Order.OrderStatus)Enum.Parse(typeof(Order.OrderStatus), storyNode.Attributes["status"].Value);
                            entry.Date = DateTime.Parse(storyNode.Attributes["date"].Value);
                            changeEntries.Add(entry);
                        }
                    }

                    order.ChangesEntries = changeEntries;
                    orders.Add(order);
                }

            }
            
            return orders;
        }
       
        public static void AddChangeEntriesNode(XmlNode orderNode, List<Order.ChangeEntry> entries) 
        {
            if(entries == null || entries.Count == 0)
            {
                return;
            }

            foreach(var entry in entries)
            {
                var changeEntry = orderNode.OwnerDocument.CreateElement("story");
                changeEntry.SetAttribute("date", entry.Date.ToString());
                changeEntry.SetAttribute("status", entry.Status.ToString());
                orderNode.AppendChild(changeEntry);
            }

        }
    }
}
           