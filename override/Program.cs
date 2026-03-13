using System;

namespace override_
{
    class Program
    {

        class Calcolatrice
        {
            public int Somma(int a, int b)
            {
                return a + b;
            }

            public int Somma(int a, int b, int c)
            {
                return a + b + c;
            }

            public double Somma(double a, double b)
            {
                return a + b;
            }
        }

        public static void Main()
        {
            int a = 2, b = 15, c = 10;
            double x = 12, y = 32;
            Calcolatrice classe = new Calcolatrice();
            Console.WriteLine(classe.Somma(a, b, c));
            classe.Somma(x, y);
        }
    }
}