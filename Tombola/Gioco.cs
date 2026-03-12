using System;

namespace  Tombola
{
    class Gioco
    {
        private int numero;
        private int[,] tabellone = new int[9,10];
        
        // FAI IL TABELLONEEEEEEEEEEE
        public void Genera_tabellone()
        {
            for (int decine = 0; decine < 9; decine++)
            {
                for (int unità = 0; unità < 10; unità++)
                {
                    int numero = decine * 10 + unità + 1;
                    if(numero <=90) tabellone[decine, unità] = decine * 10 + unità + 1;
                }
            }
        }

        public void Stampa_cartellone()
        {
            for (int decine = 0; decine < 9; decine++)
            {
                for (int unità = 0; unità < 10; unità++)
                {
                    Console.Write(tabellone[decine,unità].ToString("D2") + "\t");
                }
                Console.WriteLine();
            }
        }

        public void Aggiorna_tabellone()
        {
            int n_riga = (numero - 1) / 10;
            int n_colonna = (numero - 1) % 10;

            tabellone[n_riga, n_colonna] = 0;
        }
        
        
        public void Estrai_numero()
        {
            Random random = new Random();
            int estr = random.Next(1,91);
            numero = estr;
        }

        public void Stampa_numero()
        {
            Console.WriteLine(numero);
        }

        public void Check_cartella(int[,] cartella, ref bool[,] matrice_flag)
        {
            // Estratto il numero inizio il check casella per casella.
            for (int i = 0; i < cartella.GetLength(0); i++)
            {
                for (int j = 0; j < cartella.GetLength(1); j++)
                {
                    // La sto solo aggiornando al momento, non più creando.
                    if (cartella[i, j] == numero) matrice_flag[i,j] = true;
                }
            }
            
            // Ho controllato a questo punto se il numero è presente nella cartella. Cartella controllata
            // Devo controllare se ho fatto ambo o più.
            //return matrice_flag;
        }

        public void Check_vittorie(int numero_giocatore, bool[,] matrice_flag, int target, ref bool flag_target)
        {
            // A questo punto ho la matrice e devo controllarlo.
            // Il target è a quanto bisogna arrivare. 
            // Il flag_target è se in questo turno è stato raggiunto il target e da chi.
            string Premio = "";
            switch (target)
            {
                case 2:
                    Premio = "ambo";
                    break;
                case 3:
                    Premio = "terno";
                    break;
                case 4:
                    Premio = "quaterna";
                    break;
                case 5:
                    Premio = "cinquina";
                    break;
                case 6:
                    Premio = "tombola";
                    break;
                default:
                    Console.WriteLine("C'è stato un problema nel gioco! Ricomincia per favore");
                    break;
            }

            if (target <= 5)
            {
                for (int i = 0; i < matrice_flag.GetLength(0); i++)
                {
                    int somma = 0;
                    for (int j = 0; j < matrice_flag.GetLength(1); j++)
                    {
                        somma += matrice_flag[i, j] ? 1 : 0;
                    }

                    if (somma == target)
                    {
                        Console.WriteLine("Il giocatore " + numero_giocatore + " ha fatto " + Premio + "!");
                        flag_target = true; // Da riazzerare nel Main!
                    }
                }
                
            }
            else
            {
                int somma_tot = 0;
                // Qui devo gestire la tombola. Si fa tombola quando tutti gli elementi sono 1
                for (int i = 0; i < matrice_flag.GetLength(0); i++)
                {
                    for (int j = 0; j < matrice_flag.GetLength(1); j++)
                    {
                        somma_tot += matrice_flag[i, j] ? 1 : 0;
                    }
                }

                if (somma_tot == matrice_flag.GetLength(0) * matrice_flag.GetLength(1))
                {
                    Console.WriteLine("Il giocatore " + numero_giocatore + " ha fatto " + Premio + "!");
                    flag_target = true; 
                }
            }
        }
        
        
        
        
    }
}