using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace BootCamp
{
    class Json
    {
        private readonly string path = @"..\\Order.json";
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JObject results = JObject.Parse(json);
                foreach (var js in results["requests"])
                {
                    int clientId = (int)js["clientId"];
                    int requestId = (int)js["requestId"];
                    string name = (string)js["name"];
                    int quantity = (int)js["quantity"];
                    double price = (double)js["price"];
                    Console.WriteLine(results["requests"].Count());
                    //dynamic data = JObject.Parse(json);
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}", clientId, requestId, name, quantity, price);
                }
            }
        }
        public int countOrders()
        {
            int NumerOfOrders = 0;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JObject results = JObject.Parse(json);

                NumerOfOrders = results["requests"].Count();
            }
            return NumerOfOrders;
        }
        public int countOrdersForClient(int Id)
        {
            int numberOfOrders = 0;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JObject results = JObject.Parse(json);

                foreach (var js in results["requests"])
                {
                    int clientId = (int)js["clientId"];
                    if (clientId == Id)
                        numberOfOrders++;
                }
            }
            return numberOfOrders;
        }
        public double ordersCost()
        {
            double Cost = 0;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JObject results = JObject.Parse(json);
                foreach (var js in results["requests"])
                {
                    int Quantity = (int)js["quantity"];
                    double Price = (double)js["price"];
                    Cost += (Quantity * Price);
                }
            }
            return Cost;
        }
        public double orderCostForClient(int Id)
        {
            double Cost = 0;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JObject results = JObject.Parse(json);
                foreach (var js in results["requests"])
                {
                    int clientId = (int)js["clientId"];
                    if (clientId == Id)
                    {
                        int Quantity = (int)js["quantity"];
                        double Price = (double)js["price"];
                        Cost += (Quantity * Price);
                    }
                }
            }
            return Cost;
        }

        public void showOrders()
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JObject results = JObject.Parse(json);
                foreach (var js in results["requests"])
                {
                    int clientId = (int)js["clientId"];
                    int requestId = (int)js["requestId"];
                    string name = (string)js["name"];
                    int quantity = (int)js["quantity"];
                    double price = (double)js["price"];
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}", clientId, requestId, name, quantity, price);
                }
            }
        }
        public void showOrdersForClient(int Id)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JObject results = JObject.Parse(json);
                foreach (var js in results["requests"])
                {
                    int clientId = (int)js["clientId"];
                    int requestId = (int)js["requestId"];
                    string name = (string)js["name"];
                    int quantity = (int)js["quantity"];
                    double price = (double)js["price"];
                    if (clientId == Id)
                        Console.WriteLine("{0}, {1}, {2}, {3}, {4}", clientId, requestId, name, quantity, price);
                }
            }
        }
        public double countAverage()
        {
            double Average = 0;
            Average = ordersCost() / countOrders();
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
            int numberOfOrders = 0;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JObject results = JObject.Parse(json);
                foreach (var js in results["requests"])
                {
                    string name = (string)js["name"];
                    if (name.ToLower() == Name)
                        numberOfOrders++;
                }
            }
            Console.WriteLine($"Naliczono {numberOfOrders} produktów");
        }
        public void countOrdersForProductNameAndClientId(string Name, int Id)
        {
            {
                int numberOfOrders = 0;
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    JObject results = JObject.Parse(json);
                    foreach (var js in results["requests"])
                    {
                        string name = (string)js["name"];
                        int id = (int)js["clientId"];
                        if ((name.ToLower() == Name) && (id == Id))
                            numberOfOrders++;
                    }
                }
                Console.WriteLine($"Naliczono {numberOfOrders} produktów");
            }
        }
        public void showOrdersInPriceRange(double Min, double Max)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JObject results = JObject.Parse(json);

                foreach (var js in results["requests"])
                {
                    int clientId = (int)js["clientId"];
                    int requestId = (int)js["requestId"];
                    string name = (string)js["name"];
                    int quantity = (int)js["quantity"];
                    double price = (double)js["price"];

                    if ((Min <= price) && (Max >= price))
                        Console.WriteLine("{0}, {1}, {2}, {3}, {4}", clientId, requestId, name, quantity, price);
                }
            }
        }
    }
}
