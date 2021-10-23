using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;

namespace CRMproject
{
    class ProductsDataBase
    {
        public static void AddProductsList()
        {
            List<Products> products = new List<Products>();
            products.Add(new Products("Microwave","Type: solo, Color: black, Weight: 11 kg ", 2519, 83284179, true, Guid.NewGuid()));
            products.Add(new Products("Blender", "Type: hand, Color: black/silver, Weight: 1,98 kg ", 2899, 232178845, true, Guid.NewGuid()));
            products.Add(new Products("Iron", "Type: with steam, Color: black/golden, Weight: 1,66 kg ", 2999, 81776523, true, Guid.NewGuid()));
            products.Add(new Products("Grill", "Type: solo , Color: black/silver, Weight: 5,2 kg ", 4999, 41020184, true, Guid.NewGuid()));
            products.Add(new Products("Vacuum cleaner", "Type: dry , Color: black/purple, Weight: 4,4 kg ", 2499, 35068047, true, Guid.NewGuid()));
            products.Add(new Products("Hair dryer", "Type: solo , Color: black, Weight: 0,85 kg ", 1599, 146833528, true, Guid.NewGuid()));
            products.Add(new Products("Fridge", "Type: solo , Color: silver, Weight: 67 kg ", 11999, 92106032, true, Guid.NewGuid()));
            products.Add(new Products("Washing machine", "Type: solo , Color: white, Weight: 60 kg ", 11999, 292994538, true, Guid.NewGuid()));
            products.Add(new Products("Coffee machine", "Type: solo , Color: black/silver, Weight: 11,5 kg ", 21499, 18848130, true, Guid.NewGuid()));
            products.Add(new Products("Electric toothbrush", "Type: hand , Color: dark blue, Weight: 0,45 kg ", 9999, 302980148, true, Guid.NewGuid()));
            
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

            XmlAttribute productNameAttr = xDoc.CreateAttribute("product name");
            productNameAttr.Value = products.ProductName;
            XmlAttribute descriptionAttr = xDoc.CreateAttribute("description");
            descriptionAttr.Value = products.Description;
            XmlAttribute priceAttr = xDoc.CreateAttribute("price");
            priceAttr.Value = products.Price.ToString();
            XmlAttribute productNumberAttr = xDoc.CreateAttribute("product number");
            productNumberAttr.Value = products.ProductNumber.ToString();
            XmlAttribute existenceAttr = xDoc.CreateAttribute("existence");
            existenceAttr.Value = products.Existense.ToString();
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
           
        }

    }
}
