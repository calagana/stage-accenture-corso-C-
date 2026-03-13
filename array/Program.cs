using System;

namespace array
{
    class Program
    {
        static void Main()
        {
            int[] numeri = { 10, 20, 30 };
            int[] numeri2 = new int[3];      // ci sono tre elementi qui così
            numeri2[0] = 10;
            numeri2[1] = 20;
            numeri2[2]  = 30;

            for (int i = 0; i < numeri.Length; i++)
            {
                Console.WriteLine(numeri[i]);
            }
            
            // Oppure anche il for each
            foreach (int n in numeri2)
            {
                Console.WriteLine(n);
            }

            int[] numeri4 = { 5, 10, 20, 25, 30 };
            int somma = 0;

            for (int i = 0; i < numeri4.Length; i++)
            {
                somma += numeri4[i];
            }
            Console.WriteLine("La somma è: " + somma);

        }
    }
}