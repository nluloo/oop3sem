using lab13;
using System;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Text.Json.Nodes;
using System.Text.Json;
using Newtonsoft.Json;
using System.Xml.XPath;

namespace lab13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product pc = new PC(700, "Gaming PC", 16000);

            CustomSerializer.SerializeToBinary(pc, "pc.dat");

            Product pcC = null;
            CustomSerializer.DeserializeFromBinary("pc.dat", ref pcC);


            Console.WriteLine(pcC.ToString());

            Product pc2 = new PC(1000, "LAPTOP", 16);


            CustomSerializer.SerializeToXml(pc2, "SerXML.xml");

            Product pcC2 = null;
            CustomSerializer.DeserializefromXml("SerXML.xml", ref pcC2);

            Console.WriteLine(pcC2.ToString());

            PC pc3 = new PC(3000, "GAMEING", 8000);
            CustomSerializer.SerializeToJson(pc3, "SerJson.json");

            CustomSerializer.DeserializeFromJson("SerJson.json", ref pcC);

            Console.WriteLine(pcC.ToString());


            Console.WriteLine("---------LIST----------");
            List<Product> pcList = new List<Product>();

            pcList.Add(pc);
            pcList.Add(pc2);
            pcList.Add(pc3);

            CustomSerializer.SerializeToXml(pcList, "ListSer.xml");


            List<Product> list = null;

            CustomSerializer.DeserializefromXml("ListSer.xml", ref list);

            foreach (Product item in list)
            {
                Console.WriteLine(item.ToString());
            }


            Console.WriteLine("-------XPath-------");
            XmlDocument doc = new XmlDocument();
            doc.Load("ListSer.xml");

            XmlElement xRoot = doc.DocumentElement;

            XmlNodeList productNodes = xRoot.SelectNodes("//Product[price < 1000]");

            if (productNodes != null)
            {
                foreach (XmlNode node in productNodes)
                {
                    Console.WriteLine("Product:");
                    Console.WriteLine("Name: " + node.SelectSingleNode("name")?.InnerText);
                    Console.WriteLine("Price: " + node.SelectSingleNode("price")?.InnerText);
                    Console.WriteLine("RAM: " + node.SelectSingleNode("ram_pc")?.InnerText);
                    Console.WriteLine();
                }
            }


            XmlNodeList priceNodes = xRoot.SelectNodes("//Product/price");

            if (priceNodes != null)
            {
                int totalPrice = 0;

                foreach (XmlNode priceNode in priceNodes)
                {
                    if (int.TryParse(priceNode.InnerText, out int price))
                    {
                        totalPrice += price;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка при преобразовании цены.");
                    }
                }

                Console.WriteLine($"Общая сумма всех продуктов: {totalPrice}");
            }


            Console.WriteLine("-------XMLLinq-------");

            XDocument listPCs = new XDocument(
            new XElement("Products",
                new XElement("PCs",
                    new XElement("PC",
                        new XElement("name", "Gaming PC"),
                        new XElement("price", "16000"),
                        new XElement("ram", "16000")
                    ),
                    new XElement("PC",
                        new XElement("name", "Office PC"),
                        new XElement("price", "4000"),
                        new XElement("ram", "8GB")
                    )
                ),
                new XElement("Laptops",
                    new XElement("Laptop",
                        new XElement("name", "Gaming Laptop"),
                        new XElement("price", "20000"),
                        new XElement("ram", "32GB")
                ),
                    new XElement("Laptop",
                        new XElement("name", "Super Laptop"),
                        new XElement("price", "12000"),
                        new XElement("ram", "16GB")
                        )
                    )
                )
            );

            listPCs.Save("Products.xml");


            var pcs = listPCs.Descendants("PC")
                .Select(pc => new
                {
                    Name = pc.Element("name")?.Value,
                    Price = pc.Element("price")?.Value,
                    Ram = pc.Element("ram")?.Value
                });

            foreach (var item in pcs)
            {
                Console.WriteLine($"PC Name: {item.Name}, Price: {item.Price}, RAM: {item.Ram}");
            }


            var productsRam = listPCs.Descendants()
                             .Where(p => p.Element("ram")?.Value.Contains("16GB") == true)
                             .Select(p => new
                             {
                                 Name = p.Element("name")?.Value,
                                 Price = p.Element("price")?.Value,
                                 Ram = p.Element("ram")?.Value
                             });

            foreach (var product in productsRam)
            {
                Console.WriteLine($"Product Name: {product.Name}, Price: {product.Price}, RAM: {product.Ram}");
            }
        }
    }
}
