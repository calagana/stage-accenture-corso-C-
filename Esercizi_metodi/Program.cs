using System;

namespace Esercizi_metodi
{
    class Program
    {
        
        public static void Saluta()
        {
            Console.WriteLine("Ciao, sono proprio io");
            return;
        }

        public static void StampaNumero(int num)
        {
            Console.WriteLine("Il numero è: " + num);
        }

        class Calcolatrice
        {
            public int Somma(int x, int y)
            {
                return x + y;
            }

            public int Moltiplicazione(int x, int y)
            {
                return x * y;
            }

            public double Divisione(int x, int y)
            {
                return (double) x / y;
            }

            public int Sottrazione(int x, int y)
            {
                return x - y;
            }

            public void Raddoppia(ref int x)
            {
                x = 2 * x;
            }

            public void Calcola(int x, int y, out int somma, out int differenza)
            {
                somma = Somma(x, y);
                differenza = Sottrazione(x, y);
            }

            public int Area_q(int lato)
            {
                return lato * lato;
            }

            public int Area_r(int bas, int altezza)
            {
                return bas * altezza;
            }

            public double Area_c(double r)
            {
                return Math.PI * r * r;
            }
        }

        class Persona
        {
            public string nome;
            public int eta;
            
            public void Presentati()
            {
                Console.WriteLine("Ciao mi chiamo " + nome + " ed ho " + eta);
            }
        }

        class programma
        {
            private int a, b, c;

            public void LeggiNumero()
            {
                Console.WriteLine("Inserisci i tre numeri!");
                a = int.Parse(Console.ReadLine());
                b = int.Parse(Console.ReadLine());
                c = int.Parse(Console.ReadLine());
            }

            public void Studia()
            {
                Calcolatrice calc = new Calcolatrice();
                Console.WriteLine("Somma:   " + calc.Somma(a, b));
                Console.WriteLine("Media:   " + (double)(calc.Somma(calc.Somma(a, b),c) / 3.0));

                int[] lista = [a, b, c];
                int max = 0;
                
                // Trovo il maggiore
                for(int i= 0; i < lista.Length; i++)
                {
                    if(lista[i] > max) max = lista[i];
                }
                
                Console.WriteLine("Massimo: " + max);
            }
        }
        
        
        static void Main()
        {
            Saluta();
            int num = 10;
            int x = 9;
            int diff = 0;
            int somma = 0;
            Calcolatrice calc = new Calcolatrice();
            double div = calc.Divisione(num, x);
            Console.WriteLine(div);

            calc.Calcola(num, x, out somma, out diff);
            
            Persona p1 = new Persona();
            p1.nome = "Carlo";
            p1.eta = 24;
            calc.Raddoppia(ref p1.eta);
            p1.Presentati();
            
            Console.WriteLine("Area cerchio = " + calc.Area_c(div) + "    area quadrato = " + calc.Area_q(p1.eta));
            
            programma p2 = new programma();
            
            p2.LeggiNumero();

            p2.Studia();
        }
    }
}