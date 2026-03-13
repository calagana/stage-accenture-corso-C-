using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Liste_etc
{
    class Program
    {
        public static void Main()
        {
            List<int> numeri = new List<int>();

            numeri.Add(1);
            numeri.Add(2);
            numeri.Add(3);
            numeri.Add(4);
            numeri.Add(5);

            foreach (int i in numeri)
            {
                Console.WriteLine(i);
            }
            
            numeri.Remove(1);           // Questo elimina proprio l'1, non il primo elemento della lista!!!!
            foreach (int i in numeri)
            {
                Console.WriteLine(i);
            }

            if (numeri.Contains(5)) Console.WriteLine("Ci sta caspita!");
        }
    }
}