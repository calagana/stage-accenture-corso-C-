using System;

namespace Ciclo_while
{
    class Program
    {
        static void Main()
        {
            int i = 0;
            int j = 0;
            int somma = 0;
            
            while (i < 5)
            {
                Console.WriteLine("Inserisci un numero:");
                string ins =  Console.ReadLine();
                j = int.Parse(ins);
                
                somma += j;
                i++;
            }
            Console.WriteLine("Somma = "+ somma);
        }
    }
}