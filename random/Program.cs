using System;

namespace random
{
    class Program
    {
        static void Main(string[] args)
        {
            // Questa è la vera e propria randomizzazione
            Random random = new Random();

            int numero = random.Next(1,21);
            
            Console.WriteLine("Ho generato il numero, prova ad indovinare!");

            do
            {
                int guess = int.Parse(Console.ReadLine());
                if (guess > numero)
                {
                    Console.WriteLine("No, il numero inserito è troppo alto! Riprova");
                } else if (guess < numero)
                {
                    Console.WriteLine("No, il numero inserito è troppo basso! Riprova");
                }
                else if (guess == numero)
                {
                    Console.WriteLine("Incredibile, hai indovinato!");
                    break;
                }
            } while (true);
            
            
            

        }
    }
}