using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BootCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            // using (var s = File.Create($"..\\Order.csv"));
            // using (var s = File.Create($"..\\Order.xml"));
            // using (var s = File.Create($"..\\Order.json"));
            Setters set = new Setters();
            CSV csv = new CSV();
            Xml xml = new Xml();
            Json json = new Json();
            Extensions ex = new Extensions();

            int Id = 0;
            string Com = "";
            string Name = "";
            double Min = 0;
            double Max = 0;

            Console.WriteLine("Hello");
            do
            {
                ex.ShowMainManu();
                Com = Console.ReadLine().ToLower();
                switch (Com)
                {

                    case "1":
                        ex.ShowRaportMenu();
                        do
                        {
                            string command = "";
                            Console.WriteLine("wpisz polecenie");
                            command = Console.ReadLine().ToLower();

                            if (command == "a")
                            {
                                Console.WriteLine("Raport A:");
                                Console.WriteLine("Ilość zamówień");
                                Console.WriteLine(csv.countOrders() - 1);
                                Console.WriteLine();
                            }
                            if (command == "b")
                            {
                                Id = set.SetId(Id);
                                Console.WriteLine("Raport B:");
                                Console.WriteLine("Ilość zamówień dla klienta o wskazanym identyfikatorze");
                                Console.WriteLine(csv.countOrdersForClient(Id));
                                Console.WriteLine();
                            }
                            if (command == "c")
                            {
                                Console.WriteLine("Raport C:");
                                Console.WriteLine("Łączna kwota zamówień");
                                Console.WriteLine(csv.ordersCost());
                                Console.WriteLine();
                            }
                            if (command == "d")
                            {
                                Id = set.SetId(Id);
                                Console.WriteLine("Raport D:");
                                Console.WriteLine("Łączna kwota zamówień dla klienta o wskazanym identyfikatorze");
                                Console.WriteLine(csv.ordersCostforCostumer(Id));
                                Console.WriteLine();
                            }
                            if (command == "e")
                            {
                                Console.WriteLine("Raport E:");
                                Console.WriteLine("Lista wszystkich zamówień");
                                csv.loadFile();
                                Console.WriteLine();
                            }
                            if (command == "f")
                            {
                                Id = set.SetId(Id);
                                Console.WriteLine("Raport F:");
                                Console.WriteLine("Lista zamówień dla klienta o wskazanym identyfikatorze");
                                csv.loadOrder(Id);
                                Console.WriteLine();
                            }
                            if (command == "g")
                            {
                                Console.WriteLine("Raport G:");
                                Console.WriteLine("Średnia wartość zamówienia");
                                Console.WriteLine(csv.countAverage());
                                Console.WriteLine();
                            }
                            if (command == "h")
                            {
                                {
                                    Id = set.SetId(Id);
                                    Console.WriteLine("Raport H:");
                                    Console.WriteLine("Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze");
                                    Console.WriteLine(csv.countAverageForCostumer(Id));
                                    Console.WriteLine();
                                }
                            }
                            if (command == "i")
                            {
                                Name = set.SetName(Name);
                                Console.WriteLine("Rapart I:");
                                Console.WriteLine("Ilość zamówień pogrupowanych po nazwie");
                                csv.countOrdersForProductName(Name);
                                Console.WriteLine();
                            }
                            if (command == "j")
                            {
                                Name = set.SetName(Name);
                                Id = set.SetId(Id);
                                Console.WriteLine(Name);
                                Console.WriteLine("Rapart J:");
                                Console.WriteLine("Ilość zamówień pogrupowanych po nazwie dla klienta o wskazanym identyfikatorze");
                                csv.countOrdersForProductNameAndClientId(Name, Id);
                                Console.WriteLine();
                            }
                            if (command == "k")
                            {
                                Min = set.SetMin(Min);
                                Max = set.SetMax(Max);
                                Console.WriteLine("Rapart K:");
                                Console.WriteLine("Zamówienia w podanym przedziale cenowym:");
                                csv.showOrdersInPriceRange(Min, Max);
                                Console.WriteLine();
                            }
                            if (command == "all")
                            {
                                Id = set.SetId(Id);
                                Name = set.SetName(Name);
                                Min = set.SetMin(Min);
                                Max = set.SetMax(Max);
                                ConsoleEx.WriteLine("Pełny Raport", ConsoleColor.Yellow);
                                Console.WriteLine($"Ilość zamówień: {csv.countOrders()}");
                                Console.WriteLine($"Ilość zamówień dla klienta o wskazanym identyfikatorze: {csv.countOrdersForClient(Id)}");
                                Console.WriteLine($"Łączna kwota zamówień: {csv.ordersCost()}");
                                Console.WriteLine($"Łączna kwota zamówień dla klienta o wskazanym identyfikatorze: {csv.ordersCostforCostumer(Id)}");
                                Console.WriteLine("Lista wszystkich zamówień ");
                                csv.loadFile();
                                Console.WriteLine("\n" + "Lista zamówień dla klienta o wskazanym identyfikatorze ");
                                csv.loadOrder(Id);
                                Console.WriteLine($"Średnia wartość zamówienia: {csv.countAverage()}");
                                Console.WriteLine($"Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze: {csv.countAverageForCostumer(Id)}");
                                Console.Write($"Ilość zamówień pogrupowanych po nazwie [ {Name} ]: ");
                                csv.countOrdersForProductName(Name);
                                Console.Write($"Ilość zamówień pogrupowanych po nazwie [ {Name} ] dla klienta o wskazanym identyfikatorze [ {Id} ]: ");
                                csv.countOrdersForProductNameAndClientId(Name, Id);
                                Console.WriteLine($"[Zamówienia w podanym przedziale cenowym [ {Min}-{Max} ]: ");
                                csv.showOrdersInPriceRange(Min, Max);
                            }
                            if (command == "exit")
                            {
                                command = "";
                                Console.Clear();
                                break;
                            }
                        } while (true);
                        break;
                    case "2":
                        ex.ShowRaportMenu();
                        do
                        {
                            string command = "";
                            Console.WriteLine("wpisz polecenie");
                            command = Console.ReadLine().ToLower();

                            if (command == "a")
                            {
                                Console.WriteLine("Raport A");
                                Console.WriteLine("Ilość zamówień");
                                Console.WriteLine(xml.countOrders());
                                Console.WriteLine();
                            }
                            if (command == "b")
                            {
                                Id = set.SetId(Id);
                                Console.WriteLine("Raport B:");
                                Console.WriteLine("Ilość zamówień dla klienta o wskazanym identyfikatorze");
                                Console.WriteLine(xml.countOrdersForClient(Id));
                                Console.WriteLine();
                            }
                            if (command == "c")
                            {
                                Console.WriteLine("Raport C");
                                Console.WriteLine("Łączna kwota zamówień");
                                Console.WriteLine(xml.orderCost());
                                Console.WriteLine();
                            }
                            if (command == "d")
                            {
                                Id = set.SetId(Id);
                                Console.WriteLine("Raport D");
                                Console.WriteLine("Łączna kwota zamówień dla klienta o wskazanym identyfikatorze");
                                Console.WriteLine(xml.orderCostForClient(Id));
                                Console.WriteLine();
                            }
                            if (command == "e")
                            {
                                Console.WriteLine("Raport E");
                                Console.WriteLine("Lista wszystkich zamówień");
                                xml.showOrders();
                                Console.WriteLine();
                            }
                            if (command == "f")
                            {
                                Id = set.SetId(Id);
                                Console.WriteLine("Raport F");
                                Console.WriteLine("Lista zamówień dla klienta o wskazanym identyfikatorze");
                                xml.showOrdersForCustomer(Id);
                                Console.WriteLine();
                            }
                            if (command == "g")
                            {
                                Console.WriteLine("Raport G");
                                Console.WriteLine("Średnia wartość zamówienia");
                                Console.WriteLine(xml.countAverage());
                                Console.WriteLine();

                            }
                            if (command == "h")
                            {
                                Id = set.SetId(Id);
                                Console.WriteLine("Raport H");
                                Console.WriteLine("Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze");
                                Console.WriteLine(xml.countAverageForClient(Id));
                                Console.WriteLine();
                            }
                            if (command == "i")
                            {
                                Name = set.SetName(Name);
                                Console.WriteLine("Rapart I:");
                                Console.WriteLine("Ilość zamówień pogrupowanych po nazwie");
                                xml.countOrdersForProductName(Name);
                                Console.WriteLine();
                            }
                            if (command == "j")
                            {
                                Name = set.SetName(Name);
                                Id = set.SetId(Id);
                                Console.WriteLine("Rapart J:");
                                Console.WriteLine("Ilość zamówień pogrupowanych po nazwie dla klienta o wskazanym identyfikatorze");
                                xml.countOrdersForProductNameAndClientId(Name, Id);
                                Console.WriteLine();
                            }
                            if (command == "k")
                            {
                                Min = set.SetMin(Min);
                                Max = set.SetMax(Max);
                                Console.WriteLine("Rapart K:");
                                Console.WriteLine("Zamówienia w podanym przedziale cenowym:");
                                xml.showOrdersInPriceRange(Min, Max);
                                Console.WriteLine();
                            }

                            if (command == "all")
                            {
                                Id = set.SetId(Id);
                                Name = set.SetName(Name);
                                Min = set.SetMin(Min);
                                Max = set.SetMax(Max);
                                ConsoleEx.WriteLine("Pełny Raport", ConsoleColor.Yellow);
                                Console.WriteLine($"Ilość zamówień: {xml.countOrders()}");
                                Console.WriteLine($"Ilość zamówień dla klienta o wskazanym identyfikatorze: {xml.countOrdersForClient(Id)}");
                                Console.WriteLine($"Łączna kwota zamówień: {xml.orderCost()}");
                                Console.WriteLine($"Łączna kwota zamówień dla klienta o wskazanym identyfikatorze: {xml.orderCostForClient(Id)}");
                                Console.WriteLine("Lista wszystkich zamówień ");
                                xml.showOrders();
                                Console.WriteLine("Lista zamówień dla klienta o wskazanym identyfikatorze ");
                                xml.showOrdersForCustomer(Id);
                                Console.WriteLine($"Średnia wartość zamówienia: {xml.countAverage()}");
                                Console.WriteLine($"Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze: {xml.countAverageForClient(Id)}");
                                Console.Write($"Ilość zamówień pogrupowanych po nazwie [ {Name} ]: ");
                                xml.countOrdersForProductName(Name);
                                Console.Write($"Ilość zamówień pogrupowanych po nazwie [ {Name} ] dla klienta o wskazanym identyfikatorze [ {Id} ]: ");
                                xml.countOrdersForProductNameAndClientId(Name, Id);
                                Console.WriteLine($"[Zamówienia w podanym przedziale cenowym [ {Min}-{Max} ]: ");
                                xml.showOrdersInPriceRange(Min, Max);
                            }
                            if (command == "exit")
                            {
                                command = "";
                                Console.Clear();
                                break;
                            }
                        } while (true);
                        break;
                    case "3":
                        ex.ShowRaportMenu();
                        do
                        {
                            string command = "";
                            Console.WriteLine("wpisz polecenie");
                            command = Console.ReadLine().ToLower();

                            if (command == "a")
                            {
                                Console.WriteLine("Raport A");
                                Console.WriteLine("Ilość zamówień");
                                Console.WriteLine(json.countOrders());
                                Console.WriteLine();
                            }
                            if (command == "b")
                            {
                                Id = set.SetId(Id);
                                Console.WriteLine("Raport B:");
                                Console.WriteLine("Ilość zamówień dla klienta o wskazanym identyfikatorze");
                                Console.WriteLine(json.countOrdersForClient(Id));
                                Console.WriteLine();
                            }
                            if (command == "c")
                            {
                                Console.WriteLine("Raport C");
                                Console.WriteLine("Łączna kwota zamówień");
                                Console.WriteLine(json.ordersCost());
                                Console.WriteLine();
                            }
                            if (command == "d")
                            {
                                Id = set.SetId(Id);
                                Console.WriteLine("Raport D:");
                                Console.WriteLine("Łączna kwota zamówień dla klienta o wskazanym identyfikatorze");
                                Console.WriteLine(json.orderCostForClient(Id));
                                Console.WriteLine();
                            }
                            if (command == "e")
                            {
                                Console.WriteLine("Raport E");
                                Console.WriteLine("Lista wszystkich zamówień");
                                json.showOrders();
                                Console.WriteLine();
                            }
                            if (command == "f")
                            {
                                Id = set.SetId(Id);
                                Console.WriteLine("Raport F:");
                                Console.WriteLine("Lista zamówień dla klienta o wskazanym identyfikatorze");
                                json.showOrdersForClient(Id);
                                Console.WriteLine();
                            }
                            if (command == "g")
                            {
                                Console.WriteLine("Raport G");
                                Console.WriteLine("Średnia wartość zamówienia");
                                Console.WriteLine(json.countAverage());
                                Console.WriteLine();
                            }
                            if (command == "h")
                            {
                                Id = set.SetId(Id);
                                Console.WriteLine("Raport H");
                                Console.WriteLine("Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze");
                                Console.WriteLine(json.countAverageForClient(Id));
                                Console.WriteLine();
                            }
                            if (command == "i")
                            {
                                Name = set.SetName(Name);
                                Console.WriteLine("Rapart I:");
                                Console.WriteLine("Ilość zamówień pogrupowanych po nazwie");
                                json.countOrdersForProductName(Name);
                                Console.WriteLine();
                            }
                            if (command == "j")
                            {
                                Name = set.SetName(Name);
                                Id = set.SetId(Id);
                                Console.WriteLine("Rapart J:");
                                Console.WriteLine("Ilość zamówień pogrupowanych po nazwie dla klienta o wskazanym identyfikatorze");
                                json.countOrdersForProductNameAndClientId(Name, Id);
                                Console.WriteLine();
                            }
                            if (command == "k")
                            {
                                Min = set.SetMin(Min);
                                Max = set.SetMax(Max);
                                Console.WriteLine("Rapart K:");
                                Console.WriteLine("Zamówienia w podanym przedziale cenowym:");
                                json.showOrdersInPriceRange(Min, Max);
                                Console.WriteLine();
                            }
                            if (command == "exit")
                            {
                                command = "";
                                Console.Clear();
                                break;
                            }
                            if (command == "all")
                            {
                                Id = set.SetId(Id);
                                Name = set.SetName(Name);
                                Min = set.SetMin(Min);
                                Max = set.SetMax(Max);
                                ConsoleEx.WriteLine("Pełny Raport", ConsoleColor.Yellow);
                                Console.WriteLine($"Ilość zamówień: {json.countOrders()}");
                                Console.WriteLine($"Ilość zamówień dla klienta o wskazanym identyfikatorze: {json.countOrdersForClient(Id)}");
                                Console.WriteLine($"Łączna kwota zamówień: {json.ordersCost()}");
                                Console.WriteLine($"Łączna kwota zamówień dla klienta o wskazanym identyfikatorze: {json.orderCostForClient(Id)}");
                                Console.WriteLine("Lista wszystkich zamówień ");
                                json.showOrders();
                                Console.WriteLine("Lista zamówień dla klienta o wskazanym identyfikatorze ");
                                json.showOrdersForClient(Id);
                                Console.WriteLine($"Średnia wartość zamówienia: {json.countAverage()}");
                                Console.WriteLine($"Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze: {json.countAverageForClient(Id)}");
                                Console.Write($"Ilość zamówień pogrupowanych po nazwie [ {Name} ]: ");
                                json.countOrdersForProductName(Name);
                                Console.Write($"Ilość zamówień pogrupowanych po nazwie [ {Name} ] dla klienta o wskazanym identyfikatorze [ {Id} ]: ");
                                json.countOrdersForProductNameAndClientId(Name, Id);
                                Console.WriteLine($"[Zamówienia w podanym przedziale cenowym [ {Min}-{Max} ]: ");
                                json.showOrdersInPriceRange(Min, Max);
                            }
                        } while (true);
                        break;
                    default:
                        Console.WriteLine("Bye!");
                        Console.ReadKey();
                        break;
                }
                if (Com == "exit")
                {
                    break;
                }
            } while (true);
        }
    }
}
