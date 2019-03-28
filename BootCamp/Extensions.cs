using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BootCamp
{
    class Extensions
    {
        public void ShowMainManu()
        {
            Console.WriteLine("Wybierz format pliku");
            Console.WriteLine("[1] CSV");
            Console.WriteLine("[2] XML");
            Console.WriteLine("[3] Json");
            Console.WriteLine("[EXIT] jesli chcesz zakonczyc działanie programu");
        }

        public void ShowRaportMenu()
        {
            Console.WriteLine("Wybierz raport:");
            Console.WriteLine("[a] Ilość zamówień");
            Console.WriteLine("[b] Ilość zamówień dla klienta o wskazanym identyfikatorze");
            Console.WriteLine("[c] Łączna kwota zamówień");
            Console.WriteLine("[d] Łączna kwota zamówień dla klienta o wskazanym identyfikatorze");
            Console.WriteLine("[e] Lista wszystkich zamówień");
            Console.WriteLine("[f] Lista zamówień dla klienta o wskazanym identyfikatorze");
            Console.WriteLine("[g] Średnia wartość zamówienia");
            Console.WriteLine("[h] Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze");
            Console.WriteLine("[i] Ilość zamówień pogrupowanych po nazwie");
            Console.WriteLine("[j] Ilość zamówień pogrupowanych po nazwie dla klienta o wskazanym identyfikatorze");
            Console.WriteLine("[k] Zamówienia w podanym przedziale cenowym");
            ConsoleEx.WriteLine("[all] Pełny raport a-k", ConsoleColor.Yellow);
            Console.WriteLine("[exit] aby wrócić do menu głównego");
        }
    }
}
