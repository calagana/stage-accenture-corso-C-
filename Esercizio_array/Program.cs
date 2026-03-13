using System;

namespace Esercizio_array
{
    class Program
    {
        public static void Main()
        {
            int[] numeri = {5,12,3,20,7,9};
            int max = 0;
            foreach (int num in numeri)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            
            
            Console.WriteLine("Risultato: " + max);
            
        }
    }
}