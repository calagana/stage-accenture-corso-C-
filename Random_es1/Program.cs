using System;

namespace Random_es1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Inserisci numero dadi: ");
            int numero_dadi = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Inserisci facce dei dadi: ");
            int numero_facce = int.Parse(Console.ReadLine());

            Random random = new Random();
            for (int i = 0; i < numero_dadi; i++)
            {
                int num =  random.Next(1, numero_facce+1);
                Console.WriteLine("Numero " + i + ": " + num);
            }
        }
    }
}