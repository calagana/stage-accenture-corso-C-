using System;

namespace do_while
{
    class Program
    {
        //Controlla dopo aver eseguito almeno una volta
        public static void Main()
        {
            /*int i = 0;
            
            do
            {
                Console.WriteLine("Enter a number");
                i++;
            } while (i<10);
        
            int numero;
            while (true)
            {
                Console.WriteLine("Inserisci numero");
                numero =  int.Parse(Console.ReadLine());
                if (numero == 0)
                {
                    Console.WriteLine("Uscita in corso");
                    break;
                }
                Console.WriteLine("Hai inserito il numero: " + numero);
            }
        */
/*
            int passwd;
            do
            {
                Console.WriteLine("Benvenuto nel menu");
                Console.WriteLine("1) Somma");
                Console.WriteLine("2) Sottrai");
                Console.WriteLine("3) Esci");

                int valore = int.Parse(Console.ReadLine());
                switch (valore)
                {
                    case 1:
                        Console.WriteLine("Inserisci i due valori: ");
                        int v1 = int.Parse(Console.ReadLine());
                        int v2 = int.Parse(Console.ReadLine());
                        Console.WriteLine(v1 + v2);
                        break;
                    case 2:
                        Console.WriteLine("Inserisci i due valori: ");
                        int v3 = int.Parse(Console.ReadLine());
                        int  v4 = int.Parse(Console.ReadLine());
                        Console.WriteLine(v3 - v4);
                        break;
                    case 3:
                        break;
                }

                if (valore == 3)
                {
                    break;
                }
            } while (true);*/

            int i = 0;
            int num = 1;
            do
            {
                Console.WriteLine("Enter a number: ");
                num = int.Parse(Console.ReadLine());
                i++;
            } while ( num != 0 );
            
            Console.WriteLine("Hai inserito " + (i-1) + " numeri");

            Console.WriteLine("Bravo l'hai presa");
        }
    }   
}

