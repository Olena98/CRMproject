using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;

namespace CRMproject
{
    class ProductsDataBase
    {
        public static List<Products> Product { get; private set; }
       
        public static void Initialize()
        {
            Product = ReadXmlFile("C://Users//Olena//Documents//products.xml");
           
        }
        public static void AddNewProduct(Products products) 
        {
            SaveProduct(products);
            Product.Add(products);
          
        }
        public static void SaveProduct(Products products) 
        {
            string path = ("C://Users//Olena//Documents//products.xml");
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
                    rootElement = xDoc.CreateNode(XmlNodeType.Element, "products", string.Empty);
                    xDoc.AppendChild(rootElement);
                }
            }
            catch
            {
                rootElement = xDoc.CreateNode(XmlNodeType.Element, "products", string.Empty);
                xDoc.AppendChild(rootElement);
                Console.WriteLine("An exception was thrown!");
            }
            XmlElement productElem = xDoc.CreateElement("product");

            XmlAttribute productNameAttr = xDoc.CreateAttribute("productName");
            productNameAttr.Value = products.ProductName;
            XmlAttribute descriptionAttr = xDoc.CreateAttribute("description");
            descriptionAttr.Value = products.Description;
            XmlAttribute priceAttr = xDoc.CreateAttribute("price");
            priceAttr.Value = products.Price.ToString();
            XmlAttribute productNumberAttr = xDoc.CreateAttribute("productNumber");
            productNumberAttr.Value = products.ProductNumber.ToString();
            XmlAttribute existenceAttr = xDoc.CreateAttribute("existence");
            existenceAttr.Value = products.Existence.ToString();
            XmlAttribute guidAttr = xDoc.CreateAttribute("guid");
            guidAttr.Value = products.Id.ToString();

            productElem.Attributes.Append(productNameAttr);
            productElem.Attributes.Append(descriptionAttr);
            productElem.Attributes.Append(priceAttr);
            productElem.Attributes.Append(productNumberAttr);
            productElem.Attributes.Append(existenceAttr);
            productElem.Attributes.Append(guidAttr);

            rootElement.AppendChild(productElem);
            xDoc.Save(path);
            ReadXmlFile(path);
        }
        public static List<Products> ReadXmlFile(string path)
        {

            List<Products> product = new List<Products>();
            var doc = new XmlDocument();
            doc.Load(path);
            var xRoot = doc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {

                if (xnode.Attributes.Count > 0)
                {
                    Products products = new Products();

                    XmlNode attrProductName = xnode.Attributes.GetNamedItem("productName");
                    if (attrProductName != null)
                    {
                        products.ProductName = attrProductName.Value;
                    }
                    XmlNode attrDescription = xnode.Attributes.GetNamedItem("description");
                    if (attrDescription != null)
                    {
                        products.Description = attrDescription.Value;
                    }
                    XmlNode attrPrice = xnode.Attributes.GetNamedItem("price");
                    if (attrPrice != null)
                    {
                        products.Price = attrPrice.Value;
                    }
                    XmlNode attrProductNumber = xnode.Attributes.GetNamedItem("productNumber");
                    if (attrProductNumber != null)
                    {
                        products.ProductNumber = attrProductNumber.Value;
                    }
                    XmlNode attrExistence = xnode.Attributes.GetNamedItem("existence");
                    if (attrExistence != null)
                    {
                         products.Existence = Convert.ToBoolean(attrExistence.Value);
                    }
                    XmlNode attrGuid = xnode.Attributes.GetNamedItem("guid");
                    if (attrGuid != null)
                    {
                        products.Id = Guid.Parse(attrGuid.Value);
                    }
                    product.Add(products);
                }
            }
            return product;
        }

    }
}
