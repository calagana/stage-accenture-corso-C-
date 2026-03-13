using System;

namespace Metodi
{
    class Calcolatrice
    {
        public static int somma(int x, int y)
        {
            return x + y;
        }

    }

    internal class Program
    {
        // Funzione definita così. Qua è statica.
        static void aumenta(ref int numero)     
            // il ref serve per cambiare effettivamente di base anche il ref!!!! senza il ref non cambierebbe davvero il numero. 
        {
            numero = numero + 10;
        }

        static void calcola(int a, int b, out int somma, out int prodotto)
        {
            somma = a + b;
            prodotto = a * b;     // Con out non serve fare il return!!!!!!!!!!
        }
        
        class Persona
        {
            public string nome;

            public void Saluta()
            {
                Console.WriteLine("Ciao, mi chiamo " + nome);
                
            }
        }
        
        public static void Main()
        {
            int ris = Calcolatrice.somma(10, 20);
            Console.WriteLine(ris);
            
            Persona carlo = new Persona();
            carlo.nome = "Carlo";
            
            carlo.Saluta();

            int x = 5;
            
            aumenta(ref x);

            int a = 3, b = 5;
            int p, s;
            calcola(a,b, out s, out p);
            Console.WriteLine(s + " " +  p);
            

        }
    }
}