using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BootCamp
{
    class CSV
    {
        public List<string> OrderModelList = new List<string>();
        private readonly string path = @"..\\Order.csv";

        public int countOrders()
        {
            string[] s = File.ReadAllLines(path);
            return s.Length;
        }

        public int countOrdersForClient(int Id)
        {
            int b = 0;
            string[] s = File.ReadAllLines(path);
            for (int i = 1; i < s.Length; i++)
            {
                string c = s[i];
                int c1 = int.Parse(c.Substring(0, 1));
                if (c1 == Id)
                    b++;
            }

            return b;
        }

        public double ordersCost()
        {
            string[] s = File.ReadAllLines(path);
            double Cost = 0;

            for (int i = 1; i < s.Length; i++)
            {
                string t = s[i];
                string[] u = t.Split(',');
                Cost += int.Parse(u[3]) * double.Parse(u[4].Replace(".", ","));
            }

            return Cost;
        }

        public double ordersCostforCostumer(int Id)
        {
            string[] s = File.ReadAllLines(path);
            double Cost = 0;

            for (int i = 1; i < s.Length; i++)
            {
                string t = s[i];
                string[] u = t.Split(',');
                if (int.Parse(u[0]) == Id)
                    Cost += int.Parse(u[3]) * double.Parse(u[4].Replace(".", ","));
            }

            return Cost;
        }

        public void loadFile()
        {
            try
            {
                string s = File.ReadAllText(path);
                string[] t = s.Split(',');
                for (int i = 0; i < t.Length; i++)
                {
                    Console.Write(t[i].PadRight(t.Length));
                }
            }
            catch (Exception e)
            {
                ConsoleEx.WriteLine(e.Message, ConsoleColor.Red);
            }
        }

        public void loadOrder(int Id)
        {
            string[] s = File.ReadAllLines(path);
            Console.WriteLine(s[0].PadRight(40));
            for (int i = 1; i < countOrders(); i++)
            {
                string t = s[i];
                string[] u = t.Split(',');
                if (int.Parse(u[0]) == Id)
                    Console.WriteLine(s[i]);
            }
        }

        public double countAverage()
        {
            string[] s = File.ReadAllLines(path);
            double Average = 0;
            Average = ordersCost() / (countOrders() - 1);
            return Average;
        }

        public double countAverageForCostumer(int Id)
        {
            string[] s = File.ReadAllLines(path);
            double Average = 0;
            for (int i = 1; i < countOrders(); i++)
            {
                string t = s[i];
                string[] u = t.Split(',');
                if (int.Parse(u[0]) == Id)
                    Average = ordersCostforCostumer(Id) / countOrdersForClient(Id);
            }

            return Average;
        }

        public void countOrdersForProductName(string Name)
        {
            string[] s = File.ReadAllLines(path);
            int b = 0;
            for (int i = 1; i < countOrders(); i++)
            {
                string t = s[i];
                string[] u = t.Split(',');
                if (u[2].ToLower() == Name)
                    b++;
            }
            Console.WriteLine($"Naliczono {b} produktów");

        }
        public void countOrdersForProductNameAndClientId(string Name, int Id)
        {
            string[] s = File.ReadAllLines(path);
            int b = 0;
            for (int i = 1; i < countOrders(); i++)
            {
                string t = s[i];
                string[] u = t.Split(',');
                if (u[2].ToLower() == Name && int.Parse(u[0]) == Id)
                    b++;
            }
            Console.WriteLine($"Naliczono {b} produktów");
        }

        public void showOrdersInPriceRange(double Min, double Max)
        {
            string[] s = File.ReadAllLines(path);

                Console.WriteLine(s[0].PadRight(40));
                for (int i = 1; i < countOrders(); i++)
                {
                    string t = s[i];
                    string[] u = t.Split(',');
                    if (double.Parse(u[4].Replace(".", ",")) >= Min && double.Parse(u[4].Replace(".", ",")) <= Max)
                        Console.WriteLine(s[i]);
                }          
        }
    }
}
