using System;

namespace  Tombola
{
    class Gioco
    {
        public int numero;
        private int[,] tabellone = new int[9,10];
        
        // Questo mi segnalerà quale giocatore ha vinto quale premio
        // 0 -> ambo
        // 1 -> terno ...
        private string[] vincitore = new string[5];
        private string[] premio_vinto = {"ambo", "terno", "quaterna", "cinquina",  "tombola"};
        
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
                    if(tabellone[decine,unità] != 0) Console.Write(tabellone[decine,unità].ToString("D2") + "\t");
                    if(tabellone[decine,unità] == 0) Console.Write("--\t");
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
        
        
        // ------------------------------------------------------
        // OCCHIO CHE SE IL NUMERO è USCITO NON DEVE RIUSCIRE!!!!
        // ------------------------------------------------------
        private List<int> usciti = new List<int>();
        
        public void Estrai_numero()
        {
            bool flag = false;
            
            Random random = new Random();
            int estr = random.Next(1, 91);
                
            // Controllo la lista dei numeri già usciti.
            for (int i = 0; i < usciti.Count; i++)
            {
                if (estr == usciti[i])
                {
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                numero = estr;
                usciti.Add(numero);
            }
        }

        public void Stampa_numero()
        {
            Console.WriteLine("Ho estratto il numero: " + numero);
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

            // Da ambo a cinquina
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
                        Console.WriteLine("Il giocatore " + (numero_giocatore + 1) + " ha fatto " + Premio + "!");
                        
                        vincitore[target - 2] += (numero_giocatore + 1).ToString() + " ";
                        //Console.WriteLine(vincitore[target - 2]);
                        
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
        
        
        public void Check_vittorie_tabellone(int target, ref bool flag_target)
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

            // Da ambo a cinquina
            if (target <= 5)
            {
                // Ciclo per controllare il tabellone
                for (int i = 0; i < tabellone.GetLength(0); i++)
                {
                    // Inizializzo la variabile per studiare il tabellone. In base a come è fatto, se un
                    // numero è segnato come zero è già uscito. Quindi controllo se mezza riga per mezza riga
                    // ci sono x zeri, e poi vedo quanti sono rispetto al target.
                    int n_cartellone_primi5 = 0;
                    int n_cartellone_ultimi5 = 0;
            
                    for (int j = 0; j < tabellone.GetLength(1); j++)
                    {
                        if (j<5 && tabellone[i, j] == 0) n_cartellone_primi5++;
                        if (j>=5 && tabellone[i, j] == 0) n_cartellone_ultimi5++;
                    }

                    if (!flag_target && (n_cartellone_primi5 == target || n_cartellone_ultimi5 == target))
                    {
                        Console.WriteLine("Il tabellone ha fatto " + Premio + "!");
                        vincitore[target - 2] = "0";
                        Stampa_cartellone();
                        flag_target = true;
                    }
            
                }
            }
    
            else
            {
                //Controlliamo la tombola del tabellone.
                int[] cartelle_tab = new int[6];
        
                // Controllo tutto il cartellone insieme, metà sx e metà dx le divido
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        cartelle_tab[0] += tabellone[i, j];
                        cartelle_tab[1] += tabellone[i, j + 5];
                        cartelle_tab[2] += tabellone[i + 3, j];
                        cartelle_tab[3] += tabellone[i + 3, j + 5];
                        cartelle_tab[4] += tabellone[i + 6, j];
                        cartelle_tab[5] += tabellone[i + 6, j + 5];
                    }
                }

                for (int k = 0; k < 6; k++)
                {
                    if (cartelle_tab[k] == 0)
                    {
                        vincitore[target - 2] = "0";
                        Console.WriteLine("Il tabellone ha fatto " + Premio + "! In posizione: " + (k+1));
                        Stampa_cartellone();
                        flag_target = true;
                        break;
                    }
                }
            }
        }


        public void Stampa_vittoria(List<decimal> premi)
        {
            //Console.WriteLine("Gioco finito, complimenti!");
            Console.WriteLine("I vincitori ritirano: ");

            for (int i = 0; i < vincitore.GetLength(0); i++)
            {
                if(int.Parse(vincitore[i]) !=0) Console.WriteLine("Il giocatore/i " + vincitore[i] + " ritira il premio per " + premio_vinto[i] + ": " + premi[i].ToString("0.##") );    
                else Console.WriteLine("Il tabellone ritira il premio per " + premio_vinto[i] + ": " + premi[i].ToString("0.##") );
            }
            
            Console.WriteLine("Congratulazioni!");
            
        }
        
        // Stampa una cartella
        public void StampaCartella(int[,] cartella)
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if(usciti.Contains(cartella[r,c])) Console.Write("##\t");
                    if(cartella[r,c] != 0) Console.Write(cartella[r, c].ToString("D2") + "\t");
                    if(cartella[r,c] == 0) Console.Write("--\t");
                }
                Console.WriteLine();
            }
        }
        
    }
    
    class Cartella
    {
        // Conta quanti numeri non zero ci sono in una riga
        static int ContaNumeri(int[,] cartella, int riga)
        {
            int cont = 0;
            for (int col = 0; col < 9; col++)
            {
                if (cartella[riga, col] != 0) cont++;
            }
            return cont;
        }

        // Crea il tabellone completo 1-90
        public int[,] Tabellone()
        {
            int[,] tabellone = new int[9, 10]; // 9 righe x 10 colonne
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    int numero = r * 10 + c + 1; // calcola numero
                    if (numero <= 90)
                        tabellone[r, c] = numero;
                }
            }
            return tabellone;
        }

        // Stampa il tabellone
        public void StampaTabellone(int[,] tabellone)
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    if (tabellone[r, c] != 0)
                        Console.Write(tabellone[r, c].ToString("D2") + "\t");
                }
                Console.WriteLine();
            }
        }

        // Genera una cartella 3x9 con 5 numeri per riga
        public int[,] Cards()
        {
            Random rnd = new Random();
            int[,] card = new int[3, 9];

            for (int r = 0; r < 3; r++)
            {
                while (ContaNumeri(card, r) < 5)
                {
                    int col = rnd.Next(0, 9); // colonna casuale
                    if (card[r, col] == 0)
                    {
                        int min = col * 10 + 1;
                        int max = Math.Min(min + 9, 90); // non superare 90
                        int numero = rnd.Next(min, max + 1);

                        // evita numeri duplicati nella stessa colonna
                        bool duplicato = false;
                        for (int rr = 0; rr < 3; rr++)
                        {
                            if (card[rr, col] == numero)
                            {
                                duplicato = true;
                                break;
                            }
                        }
                        if (!duplicato)
                            card[r, col] = numero;
                    }
                }
            }

            return card;
        }

        // Stampa una cartella
        public void StampaCartella(int[,] cartella)
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if(cartella[r,c] != 0) Console.Write(cartella[r, c].ToString("D2") + "\t");
                    if(cartella[r,c] == 0) Console.Write("--\t");
                }
                Console.WriteLine();
            }
        }

        public void Avvia()
        {
            Console.WriteLine("Il gioco si avvia...\n");
        }

        public decimal Montepremi(int players, int card_scelte)
        {
            return players * card_scelte * 0.50m;//50 cents a cartella
        }

        
        public List<decimal> SoldiVinci(decimal premio)
        {
            List<decimal> tombolata = new List<decimal>();
            tombolata.Add(premio*0.01m);//soldi per l'ambo
            tombolata.Add(premio*0.09m);//soldi per il terno
            tombolata.Add(premio*0.2m);//soldi per la quaterna
            tombolata.Add(premio*0.3m);//soldi per la cinquina
            tombolata.Add(premio*0.4m);//soldi per la tombola
            return tombolata;
            //Ambo 1%,terno 9%,quaterna 20%,cinquina 30%,tombola40%
        }
        
    }
}