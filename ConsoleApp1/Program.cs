using System;

namespace ConsoleApp1
{
    internal class  Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il numero di progetto da usare");
            string el = Console.ReadLine();
            int elemento = 0;
            elemento = int.Parse(el);

            switch (elemento)
            {
                case 1:
                    Console.WriteLine("Inserisci un numero N per favore: ");
                    string N = Console.ReadLine();

                    int num = 0;
                    num = int.Parse(N);

                    int somma = 0;
                    for (int j = 0; j <= num; j++)
                    {
                        somma += j;
                    }

                    Console.WriteLine(somma);
                break;
                case 2:
                    Console.WriteLine("Questo è il secondo caso");
                    break;
                default:
                    Console.WriteLine("Tutto sbagliato, riprova");
                    break;
            }

        }
    }
}