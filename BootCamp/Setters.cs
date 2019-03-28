using System;
using System.Collections.Generic;
using System.Text;

namespace BootCamp
{
    class Setters
    {
        public int SetId(int Id)
        {
            Console.WriteLine("Podaj Id klienta:");
            try
            {
                Id = Int32.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                ConsoleEx.WriteLine("zły format", ConsoleColor.Red);
            }
            return Id;
        }
        public string SetName(string Name)
        {
            Console.WriteLine("Podaj nazwę produktu:");
            try
            {
                Name = Console.ReadLine().ToLower();
            }
            catch (Exception e)
            {
                ConsoleEx.WriteLine("zły format", ConsoleColor.Red);
            }

            return Name;
        }
        public double SetMin(double Min)
        {
            try
            {
            Console.WriteLine("podaj minimalną wartość:");
                Min = Double.Parse(Console.ReadLine().Replace(".", ","));
            }
            catch (Exception e)
            {
                ConsoleEx.WriteLine("zły format", ConsoleColor.Red);
            }

            return Min;
        }
        public double SetMax(double Max)
        {
            try
            {
                Console.WriteLine("podaj maksymalną wartość:");
                Max = Double.Parse(Console.ReadLine().Replace(".", ","));
            }
            catch (Exception e)
            {
                ConsoleEx.WriteLine("zły format", ConsoleColor.Red);
            }

            return Max;
        }
    }
}

