using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace BootCamp
{
    class Xml
    {
        private readonly string path = @"..\\Order.xml";

        XmlDocument OrderXml = new XmlDocument();

        public Xml()
        {

        }

        public void readFile()
        {
            try
            {
            OrderXml.Load(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                using (var s = File.Create(path));
            }

        }

        public int countOrders()
        {
            readFile();

            XmlNodeList nodeList = OrderXml.DocumentElement.SelectNodes("/requests/request/requestId");

            int NumerOfOrders = nodeList.Count;
            return NumerOfOrders;
        }

        public int countOrdersForClient(int Id)
        {
            int numberOfOrders = 0;

            readFile();
            XmlNodeList nodeList = OrderXml.DocumentElement.SelectNodes("/requests/request/clientId");
            foreach (XmlNode node in nodeList)
            {
                if (Int32.Parse(node.InnerText) == Id)
                    numberOfOrders++;
            }

            return numberOfOrders;
        }
        public double orderCost()
        {
            double Cost = 0;

            readFile();
            XmlNodeList priceList = OrderXml.DocumentElement.SelectNodes("/requests/request");
            foreach (XmlNode priceNode in priceList)
            {
                double quantity = Double.Parse(priceNode.ChildNodes[3].InnerText.Replace(".", ","));
                double price = Double.Parse(priceNode.ChildNodes[4].InnerText.Replace(".", ","));
                Cost += quantity * price;
            }
            return Cost;
        }

        public double orderCostForClient(int Id)
        {
            double Cost = 0;

            readFile();
            XmlNodeList nodeList = OrderXml.DocumentElement.SelectNodes("/requests/request");
            foreach (XmlNode node in nodeList)
            {
                if (Id == Int32.Parse(node.ChildNodes[0].InnerText))
                {
                    double quantity = Double.Parse(node.ChildNodes[3].InnerText);
                    double price = Double.Parse(node.ChildNodes[4].InnerText.Replace(".", ","));
                    Cost += quantity * price;
                }
            }

            return Cost;
        }

        public void showOrders()
        {
            readFile();

            XmlNodeList nodeList = OrderXml.DocumentElement.SelectNodes("/requests/request");

            for (int i = 0; i < nodeList.Item(1).ChildNodes.Count; i++)
            {
                Console.Write(nodeList.Item(1).ChildNodes[i].LocalName.PadLeft(10));
            }
            Console.WriteLine();
            foreach (XmlNode node in nodeList)
            {
                for (int j = 0; j < nodeList.Item(1).ChildNodes.Count; j++)
                {
                    Console.Write(node.ChildNodes[j].InnerText.PadLeft(10));
                }
                Console.WriteLine();
            }
        }

        public void showOrdersForCustomer(int Id)
        {
            readFile();

            XmlNodeList nodeList = OrderXml.DocumentElement.SelectNodes("/requests/request");

            for (int i = 0; i < nodeList.Item(1).ChildNodes.Count; i++)
            {
                Console.Write(nodeList.Item(1).ChildNodes[i].LocalName.PadLeft(10));
            }
            Console.WriteLine();
            foreach (XmlNode node in nodeList)
            {
                if (Id == Int32.Parse(node.ChildNodes[0].InnerText))
                {
                    for (int j = 0; j < nodeList.Item(1).ChildNodes.Count; j++)
                    {
                        Console.Write(node.ChildNodes[j].InnerText.PadLeft(10));
                    }
                }
                Console.WriteLine();
            }
        }

        public double countAverage()
        {
            double Average = 0;

            Average = orderCost() / countOrders();

            return Average;
        }

        public double countAverageForClient(int Id)
        {
            double Average = 0;

            Average = orderCostForClient(Id) / countOrdersForClient(Id);

            return Average;
        }
        public void countOrdersForProductName(string Name)
        {
            readFile();
            int numberOfOrders = 0;
            XmlNodeList nodeList = OrderXml.DocumentElement.SelectNodes("/requests/request/name");
            foreach (XmlNode node in nodeList)
            {
                if (node.InnerText.ToLower() == Name)
                    numberOfOrders++;
            }

            Console.WriteLine($"Naliczono {numberOfOrders} produktów");

        }
        public void countOrdersForProductNameAndClientId(string Name, int Id)
        {
            readFile();
            int numberOfOrders = 0;
            XmlNodeList nodeList = OrderXml.DocumentElement.SelectNodes("/requests/request");
            foreach (XmlNode node in nodeList)
            {
                if (Name == node.ChildNodes[2].InnerText.ToLower() && Id == Int32.Parse(node.ChildNodes[0].InnerText))
                    numberOfOrders++;
            }

            Console.WriteLine($"Naliczono {numberOfOrders} produktów");
        }

        public void showOrdersInPriceRange(double Min, double Max)
        {
            readFile();
            XmlNodeList nodeList = OrderXml.DocumentElement.SelectNodes("/requests/request");

            for (int i = 0; i < nodeList.Item(1).ChildNodes.Count; i++)
            {
                Console.Write(nodeList.Item(1).ChildNodes[i].LocalName.PadLeft(10));
            }
            Console.WriteLine();
            foreach (XmlNode node in nodeList)
            {
                if (Min <= Double.Parse(node.ChildNodes[4].InnerText.Replace(".", ",")) && Max >= Double.Parse(node.ChildNodes[4].InnerText.Replace(".", ",")))
                {
                    for (int j = 0; j < nodeList.Item(1).ChildNodes.Count; j++)
                    {
                        Console.Write(node.ChildNodes[j].InnerText.PadLeft(10));
                    }
                }
                Console.WriteLine();
            }
        }
        //public int countOrdersForCostumer(int Id)
        //{
        //    int b = 0;
        //    string[] s = File.ReadAllLines(path);
        //    for (int i = 1; i < s.Length; i++)
        //    {
        //        string c = s[i];
        //        int c1 = int.Parse(c.Substring(0, 1));
        //        if (c1 == Id)
        //            b++;
        //    }

        //    return b;
        //}

        //public double ordersCost()
        //{
        //    string[] s = File.ReadAllLines(path);
        //    double Cost = 0;

        //    for (int i = 1; i < s.Length; i++)
        //    {
        //        string t = s[i];
        //        string[] u = t.Split(',');
        //        Cost += int.Parse(u[3]) * double.Parse(u[4].Replace(".", ","));
        //    }

        //    return Cost;
        //}

        //public double ordersCostforCostumer(int Id)
        //{
        //    string[] s = File.ReadAllLines(path);
        //    double Cost = 0;

        //    for (int i = 1; i < s.Length; i++)
        //    {
        //        string t = s[i];
        //        string[] u = t.Split(',');
        //        if (int.Parse(u[0]) == Id)
        //            Cost += int.Parse(u[3]) * double.Parse(u[4].Replace(".", ","));
        //    }

        //    return Cost;
        //}

        //public void loadFile()
        //{
        //    try
        //    {
        //        string s = File.ReadAllText(path);
        //        string[] t = s.Split(',');
        //        for (int i = 0; i < t.Length; i++)
        //        {
        //            Console.Write(t[i].PadRight(t.Length));
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        ConsoleEx.WriteLine(e.Message, ConsoleColor.Red);
        //    }
        //}

        //public void loadOrder(int Id)
        //{
        //    string[] s = File.ReadAllLines(path);
        //    Console.WriteLine(s[0].PadRight(40));
        //    for (int i = 1; i < countOrders(); i++)
        //    {
        //        string t = s[i];
        //        string[] u = t.Split(',');
        //        if (int.Parse(u[0]) == Id)
        //            Console.WriteLine(s[i]);
        //    }
        //}

        //public double countAverage()
        //{
        //    string[] s = File.ReadAllLines(path);
        //    double Average = 0;
        //    Average = ordersCost() / (countOrders() - 1);
        //    return Average;
        //}

        //public double countAverageForCostumer(int Id)
        //{
        //    string[] s = File.ReadAllLines(path);
        //    double Average = 0;
        //    for (int i = 1; i < countOrders(); i++)
        //    {
        //        string t = s[i];
        //        string[] u = t.Split(',');
        //        if (int.Parse(u[0]) == Id)
        //            Average = ordersCostforCostumer(Id) / countOrdersForCostumer(Id);
        //    }

        //    return Average;
        //}

    }
}
