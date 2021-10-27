﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;

namespace CRMproject
{
    class ProductsDataBase
    {
        public static List<Product> Products { get; private set; }
       
        public static void Initialize()
        {
            Products = ReadXmlFile("C://Users//Olena//Documents//products.xml");
           
        }
        public static void AddNewProduct(Product product) 
        {
            SaveProduct(product);
            Products.Add(product);
          
        }
        public static void SaveProduct(Product product) 
        {
            const string path = ("C://Users//Olena//Documents//products.xml");
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
            productNameAttr.Value = product.ProductName;
            XmlAttribute descriptionAttr = xDoc.CreateAttribute("description");
            descriptionAttr.Value = product.Description;
            XmlAttribute priceAttr = xDoc.CreateAttribute("price");
            priceAttr.Value = product.Price.ToString();
            XmlAttribute productNumberAttr = xDoc.CreateAttribute("productNumber");
            productNumberAttr.Value = product.ProductNumber.ToString();
            XmlAttribute existenceAttr = xDoc.CreateAttribute("existence");
            existenceAttr.Value = product.Existence.ToString();
            XmlAttribute guidAttr = xDoc.CreateAttribute("guid");
            guidAttr.Value = product.Id.ToString();

            productElem.Attributes.Append(productNameAttr);
            productElem.Attributes.Append(descriptionAttr);
            productElem.Attributes.Append(priceAttr);
            productElem.Attributes.Append(productNumberAttr);
            productElem.Attributes.Append(existenceAttr);
            productElem.Attributes.Append(guidAttr);

            rootElement.AppendChild(productElem);
            xDoc.Save(path);
        }
        public static List<Product> ReadXmlFile(string path)
        {

            List<Product> products = new List<Product>();
            var doc = new XmlDocument();
            doc.Load(path);
            var xRoot = doc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {

                if (xnode.Attributes.Count > 0)
                {
                    Product product = new Product();

                    XmlNode attrProductName = xnode.Attributes.GetNamedItem("productName");
                    if (attrProductName != null)
                    {
                        product.ProductName = attrProductName.Value;
                    }
                    XmlNode attrDescription = xnode.Attributes.GetNamedItem("description");
                    if (attrDescription != null)
                    {
                        product.Description = attrDescription.Value;
                    }
                    XmlNode attrPrice = xnode.Attributes.GetNamedItem("price");
                    if (attrPrice != null)
                    {
                        product.Price = Convert.ToDecimal(attrPrice.Value);
                    }
                    XmlNode attrProductNumber = xnode.Attributes.GetNamedItem("productNumber");
                    if (attrProductNumber != null)
                    {
                        product.ProductNumber = attrProductNumber.Value;
                    }
                    XmlNode attrExistence = xnode.Attributes.GetNamedItem("existence");
                    if (attrExistence != null)
                    {
                         product.Existence = Convert.ToBoolean(attrExistence.Value);
                    }
                    XmlNode attrGuid = xnode.Attributes.GetNamedItem("guid");
                    if (attrGuid != null)
                    {
                        product.Id = Guid.Parse(attrGuid.Value);
                    }
                    products.Add(product);
                }
            }
            return products;
        }

    }
}
