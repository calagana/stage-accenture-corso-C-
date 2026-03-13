/*using System;

namespace Tombola
{
    class Program
    {
        public static void Main(string[] args)
        {
            // ###########################################################
            // ############## CODICE DELLA PRIMA PARTE ###################
            // ###########################################################
            int n_cartelle = 2;   // Per ora definisco così poi vedremo
            int[][,] cartelle = new int[n_cartelle][,];
            cartelle[0] = new int[,]
            {
                { 29, 1, 2, 3,32 },
                { 4, 5, 6, 7, 52 },
                { 8, 9, 10, 11,9 }
            };
            
            cartelle[1] = new int[,]
            {
                { 29, 36, 23, 87, 15 },
                { 15, 27, 34, 44,21 },
                { 5, 90, 1, 11, 2 }
            };
            
            
            
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
            game.Stampa_cartellone();
            
            /*game.Estrai_numero();
            game.Stampa_numero();
            game.Aggiorna_tabellone();
            game.Stampa_cartellone();
            
            
            // continua finchè qualcuno non fa tombola. 5 sono cinquina, 6 tombola, 7 è finito.
            while (target < 7)
            {
                game.Estrai_numero();
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
            
            Console.WriteLine("Gioco finito, complimenti al vincitore!!!");
            
            //game.Stampa_cartellone();
            
        }
        
    }
}*/