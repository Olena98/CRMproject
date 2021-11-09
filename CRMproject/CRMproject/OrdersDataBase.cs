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

            XmlAttribute orderNumberAttr = xDoc.CreateAttribute("orderNumber");
            orderNumberAttr.Value = order.OrderNumber.ToString();
            XmlAttribute orderStatusAttr = xDoc.CreateAttribute("order status");
            orderStatusAttr.Value = order.OrderStatus;
            XmlAttribute guidAttr = xDoc.CreateAttribute("guid");
            guidAttr.Value = order.OrderId.ToString();
            XmlAttribute orderDateAttr = xDoc.CreateAttribute("order date");
            orderDateAttr.Value = order.OrderDate.ToString();

            orderElem.Attributes.Append(orderDateAttr);
            orderElem.Attributes.Append(orderStatusAttr);
            orderElem.Attributes.Append(orderNumberAttr);
            orderElem.Attributes.Append(guidAttr);

            rootElement.AppendChild(orderElem);
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

                    XmlNode attrOrderNumber = xnode.Attributes.GetNamedItem("order number");
                    if (attrOrderNumber != null)
                    {
                        order.OrderNumber = Convert.ToInt32(attrOrderNumber.Value);
                    }
                    XmlNode attrOrderStatus = xnode.Attributes.GetNamedItem("order status");
                    if (attrOrderStatus != null)
                    {
                        order.OrderStatus = attrOrderStatus.Value;
                    }
                    XmlNode attrOrderDate = xnode.Attributes.GetNamedItem("order date");
                    if (attrOrderDate != null)
                    {
                        order.OrderDate = DateTime.Parse(attrOrderDate.Value);
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
    }
}
           