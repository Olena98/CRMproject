using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;

namespace CRMproject
{
    class ProductsDataBase
    {
        public static List<Product> Products { get; private set; }

        private static string xmlPath;

        public static void Initialize()
        {
            xmlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "products.xml");            
            Products = ReadXmlFile(xmlPath);
        }
        public static void AddNewProduct(Product product) 
        {          
            Products.Add(product);
            SaveProductList();

        }
        public static void SaveProductList() 
        {
            if (Products == null || Products.Count == 0)
            {
                return;
            }
            
            XmlDocument xDoc = new XmlDocument();
            XmlNode rootElement = xDoc.CreateNode(XmlNodeType.Element, "products", string.Empty);
            xDoc.AppendChild(rootElement);

            foreach (var order in Products)
            {
                AppendOrderNode(rootElement, order);
            }

            xDoc.Save(xmlPath);

        }
        private static void AppendOrderNode(XmlNode parentNode, Product product) 
        {
            XmlElement productElem = parentNode.OwnerDocument.CreateElement("product");
            productElem.SetAttribute("guid", product.Id.ToString());
            productElem.SetAttribute("productName", product.ProductName);
            productElem.SetAttribute("description", product.Description);
            productElem.SetAttribute("price", product.Price.ToString());
            productElem.SetAttribute("productNumber", product.ProductNumber.ToString());
            productElem.SetAttribute("existence", product.Existence.ToString());
           

            AddChangeEntriesNode(productElem, product.ChangesEntries);

            parentNode.AppendChild(productElem);
        }
        public static List<Product> ReadXmlFile(string xmlPath)
        {

            List<Product> products = new List<Product>();
            var doc = new XmlDocument();
           
            if (File.Exists(xmlPath))
            {
                doc.Load(xmlPath);
            }
            else
            {
                File.Create(xmlPath);
                doc.CreateElement("products");
            }
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
                        product.ProductNumber = Convert.ToInt32(attrProductNumber.Value);
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
                    var changeEntries = new List<Product.ChangeEntry>();
                    foreach (XmlNode storyNode in xnode.ChildNodes)
                    {
                        if (storyNode.Name.Equals("story"))
                        {
                            var entry = new Product.ChangeEntry();
                            entry.ProductName =  storyNode.Attributes["productName"].Value;
                            entry.ProductNumber = Convert.ToInt32(storyNode.Attributes["productNumber"].Value);
                            entry.Price = Convert.ToDecimal(storyNode.Attributes["price"].Value);
                            entry.Existence = Convert.ToBoolean(storyNode.Attributes["existence"].Value);
                            changeEntries.Add(entry);
                        }
                    }
                    product.ChangesEntries = changeEntries;
                    products.Add(product);
                }
            }
            return products;
        }
        public static void AddChangeEntriesNode(XmlNode productNode, List<Product.ChangeEntry> entries)
        {
            if (entries == null || entries.Count == 0)
            {
                return;
            }

            foreach (var entry in entries)
            {
                var changeEntry = productNode.OwnerDocument.CreateElement("story");
                changeEntry.SetAttribute("productName", entry.ProductName);
                changeEntry.SetAttribute("productNumber", entry.ProductNumber.ToString());
                changeEntry.SetAttribute("price", entry.Price.ToString());
                changeEntry.SetAttribute("existence", entry.Existence.ToString());

                productNode.AppendChild(changeEntry);
            }

        }

    }
}
