using System;
using System.Collections.Generic;

namespace Tombola
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            Cartella c1 = new Cartella();

            // Genera e stampa il tabellone completo
            int[,] tabellone = c1.Tabellone();
            c1.Avvia();
            Console.WriteLine("Tabellone completo da 1 a 90:");
            c1.StampaTabellone(tabellone);
            Console.WriteLine();

            // Input numero di giocatori e cartelle per giocatore
            Console.Write("Quanti giocatori partecipano? ");
            int numeroGiocatori = Convert.ToInt32(Console.ReadLine());

            Console.Write("Quante cartelle per giocatore? ");
            int numCartellePerGiocatore = Convert.ToInt32(Console.ReadLine());

            // Lista di liste di cartelle (una lista per ogni giocatore)
            List<List<int[,]>> cartelleGiocatori = new List<List<int[,]>>();

            for (int g = 0; g < numeroGiocatori; g++)
            {
                List<int[,]> cartelleGiocatore = new List<int[,]>();
                for (int c = 0; c < numCartellePerGiocatore; c++)
                {
                    int[,] cartella = c1.Cards();
                    cartelleGiocatore.Add(cartella);
                }
                cartelleGiocatori.Add(cartelleGiocatore);
            }

            // Stampa tutte le cartelle per ogni giocatore
            for (int g = 0; g < cartelleGiocatori.Count; g++)
            {
                Console.WriteLine($"\nGiocatore {g + 1}:");
                List<int[,]> cartelleDue = cartelleGiocatori[g];

                for (int k = 0; k < cartelleDue.Count; k++)
                {
                    Console.WriteLine($"\n Cartella {k + 1}:");
                    c1.StampaCartella(cartelleDue[k]);
                }
            }
            decimal cassa=c1.Montepremi(numeroGiocatori, numCartellePerGiocatore);
            Console.WriteLine("Il montepremi da dividere è: "+cassa);
            List<decimal> divisiPremio=c1.SoldiVinci(cassa);
            Console.WriteLine("Ecco le possibili vincite" + divisiPremio);
            for (int k = 0; k < divisiPremio.Count; k++)
            {
                if (k == 0)
                    Console.WriteLine($"\n Ambo: ");
                else if (k == 1)
                    Console.WriteLine($"\n Terno: ");
                else if (k == 2)
                    Console.WriteLine($"\n Quaterna: "); 
                else if (k == 3)
                    Console.WriteLine($"\n Cinquina: ");
                else
                {
                    Console.WriteLine($"\n Tombola: ");
                }
                Console.WriteLine(divisiPremio[k].ToString("0.##"));
            }

            List<int[,]> tutteCartelle = new List<int[,]>();

            foreach (var giocatore in cartelleGiocatori)
            {
                foreach (var cartella in giocatore)
                {
                    tutteCartelle.Add(cartella);
                }
            }
  
            
            int n_cartelle = tutteCartelle.Count;
            int[][,] cartelle = tutteCartelle.ToArray();
            
            // Arrivo ad iniziare il gioco. 
            // Iniziamo ad estrarre un target, che sarà a quanto dobbiamo arrivare
            int target = 2; 
            
            // Definisco inoltre la flag del target, per segnalare se il target è già stato raggiunto
            // ad esempio, ambo già stato fatto
            bool flag_target = false;
            
            // Definisco le cartelle di flag delle vittorie. Mi sembra il modo migliore sia la matrice 3D
            bool[][,] matrici_flag = new bool[n_cartelle][,];
            
            for (int i = 0; i < n_cartelle; i++)
            {
                matrici_flag[i] = new bool[cartelle[0].GetLength(0),cartelle[0].GetLength(1)];
            }

            //Primo passo, definisco la variabile per estrarre i numeri e giocare
            Gioco game = new Gioco();
            
            game.Genera_tabellone();
            //game.Stampa_cartellone();
            
            // continua finchè qualcuno non fa tombola. 5 sono cinquina, 6 tombola, 7 è finito.
            while (target < 7)
            {
                //Console.WriteLine("Premi Enter per estrarre il prossimo numero: ");
                //Console.ReadLine(); 
                game.Estrai_numero();
                //game.Stampa_numero();
                game.Aggiorna_tabellone();
                //game.Stampa_numero();
                
                // Ok ora voglio fare il check di ogni cartella direi
                for (int k = 0; k < n_cartelle; k++)
                {
                    game.Check_cartella(cartelle[k], ref matrici_flag[k]);
                    game.Check_vittorie(k, matrici_flag[k], target, ref flag_target);
                }
                game.Check_vittorie_tabellone(target, ref flag_target);
                // Console.WriteLine(target);
                // Se la flag è vera, incremento il target e riporto la flag falsa e daje.
                if (flag_target)
                {
                    target++;
                    flag_target = false;
                }
                // A questo punto non manca nulla. 
            }
            
            //Console.WriteLine("Gioco finito, complimenti al vincitore!!!");
            game.Stampa_vittoria(divisiPremio);
            
        }
        
    }
}