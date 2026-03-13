using System;

namespace Incap_ered_polim
{
    class Program
    {
        public static void Main()
        {
            var conto = new Incapsulamento(1000);
            
            conto.Deposita(200.3M);     // var sposta direttamente al double
            Console.WriteLine(conto.Saldo);
            
            conto.Preleva(90.2M);
            Console.WriteLine(conto.Saldo);
            
            Auto macchina = new Auto();
            macchina.Marca = "Fiat";
            macchina.NumeroPorte = 4;
            
            macchina.Avvia();
            macchina.SuonaClacson();
            
            Animale[] animale =  {new Cane(), new Gatto()};

            foreach (var animal in animale)
            {
                animal.FaiVerso();
            }
            
            bool[,] matrice_flag =  new bool[10,10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(matrice_flag[i,j]);
                }
            }
            
        }
    }
}