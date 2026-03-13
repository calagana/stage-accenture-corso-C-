using System;
using System.Collections.Generic;

namespace Esercizio_liste
{
    class Program
        {
            static void Main()
            {
                List<string> Lista_nomi = new List<string>();
                while (true)
                {
                    Console.WriteLine("Eccoci nel menu! Scegli la modalità:");
                    Console.WriteLine("1) Aggiungi una persona");
                    Console.WriteLine("2) Eliminare la persona");
                    Console.WriteLine("3) Vedere la persona");
                    Console.WriteLine("4) Cercare per nome");
                    Console.WriteLine("5) Esci ");
                    int num = int.Parse(Console.ReadLine());

                    switch (num)
                    {
                        case 1: 
                            Console.WriteLine("Aggiungi una persona: Dammi il nome");
                            Lista_nomi.Add(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Eliminare la persona: Chi vorresti eliminare?");
                            foreach (string item in Lista_nomi)
                            {
                                Console.WriteLine(item);
                            }
                            Lista_nomi.Remove(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Ecco la lista delle persone:");
                            foreach (string item in Lista_nomi)
                            {
                                Console.WriteLine(item);
                                
                            }
                            Console.WriteLine("\n\n");

                            break;
                        case 4:
                            Console.WriteLine("Chi vorresti cercare? ");
                            string nome = Console.ReadLine();
                            bool presente = false;
                            foreach (string item in Lista_nomi)
                            {
                                if (item == nome)
                                {
                                    presente = true;
                                    break;
                                } 
                            }
                            if (presente) Console.WriteLine("L'utente è presente!");
                            else Console.WriteLine("L'utente non è presente! Riprova");

                            break;
                        
                        case 5:
                            Console.WriteLine("Esco... ");
                            break;
                           
                        default:
                            Console.WriteLine("Valore non valido! Riprova");
                            break;
                    }

                    if (num == 5) break;
                }
            }
        }
}