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
            SaveOrder(order);
            Orders.Add(order);
          
        }
       
        public static void SaveOrder(Order order)
        {
            FileInfo fileInfo = new FileInfo(xmlPath);
            XmlDocument xDoc = new XmlDocument();
            XmlNode rootElement = null;

            try
            {
                if (fileInfo.Exists)
                {
                    xDoc.Load(xmlPath);
                    rootElement = xDoc.DocumentElement;
                }
                else
                {
                    File.Create(xmlPath);
                    rootElement = xDoc.CreateNode(XmlNodeType.Element, "orders", string.Empty);
                    rootElement = xDoc.CreateNode(XmlNodeType.Element, "story", string.Empty);
                    xDoc.AppendChild(rootElement);
                }
            }
            catch
            {
                rootElement = xDoc.CreateNode(XmlNodeType.Element, "orders", string.Empty);               
                xDoc.AppendChild(rootElement);
                Console.WriteLine("An exception was thrown!");
            }
            XmlElement orderElem = xDoc.CreateElement("order");
            XmlAttribute orderDateAttr = xDoc.CreateAttribute("orderDate");
            orderDateAttr.Value = order.OrderDate.ToString();                          
            XmlAttribute orderStatusAttr = xDoc.CreateAttribute("orderStatus");
            orderStatusAttr.Value = Order.OrderStatus.New.ToString().ToLower();           
            XmlAttribute orderNumberAttr = xDoc.CreateAttribute("orderNumber");
            orderNumberAttr.Value = order.OrderNumber.ToString();
            XmlAttribute orderClientPhoneAttr = xDoc.CreateAttribute("clientPhone");
            orderClientPhoneAttr.Value = order.ClientPhone;
            XmlAttribute clientIdAttr = xDoc.CreateAttribute("clientsId");
            clientIdAttr.Value = order.ClientId.ToString();
            XmlAttribute productIdAttr = xDoc.CreateAttribute("productId");
            productIdAttr.Value = order.ProductsId.ToString();
            XmlAttribute guidAttr = xDoc.CreateAttribute("guid");
            guidAttr.Value = order.OrderId.ToString();

            orderElem.Attributes.Append(orderDateAttr);
            orderElem.Attributes.Append(orderNumberAttr);
            orderElem.Attributes.Append(orderStatusAttr);
            orderElem.Attributes.Append(orderClientPhoneAttr);
            orderElem.Attributes.Append(clientIdAttr);
            orderElem.Attributes.Append(productIdAttr);
            orderElem.Attributes.Append(guidAttr);

            rootElement.AppendChild(orderElem);
            var changeEntries = xDoc.OwnerDocument.CreateElement("story");
           
            xDoc.Save(xmlPath);

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
                    Order.ChangeEntry changeEntry = new Order.ChangeEntry();
                    order.ChangesEntries = new List<Order.ChangeEntry>();
                    changeEntry.Status = (Order.OrderStatus)Enum.Parse(typeof(Order.OrderStatus),  xnode.Attributes["status"].Value);
                    changeEntry.Date = DateTime.Parse(xnode.Attributes["date"].Value);
                    foreach(XmlNode orderChanges in xnode.ChildNodes) 
                    {
                        order.ChangesEntries.Add(changeEntry);
                    }
                    
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
                                                           
                    orders.Add(order);
                }

            }
            
            return orders;
        }
        static void ReadOrders(List<Order.ChangeEntry> changeEntries) 
        {
          foreach (Order.ChangeEntry changeEntry in changeEntries) 
            {
                Console.WriteLine(changeEntry.Status);
                foreach(var date in changeEntry.Date.ToString()) 
                {
                    Console.WriteLine($"Changed date: {date}");
                }
                Console.WriteLine();
            }
        }
       
        public static void AddChangeEntriesNode(XmlNode orderNode, DateTime date, Order.OrderStatus status) 
        {
            var changeEntries = orderNode.OwnerDocument.CreateElement("story");
            changeEntries.SetAttribute("date", date.ToString());
            changeEntries.SetAttribute("status", status.ToString());
            orderNode.AppendChild(changeEntries);
        }
    }
}
           