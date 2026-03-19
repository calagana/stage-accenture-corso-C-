using System;
using System.IO;
using System.Collections.Generic;

namespace  Esercizio_txt
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Nomi_vari.txt";
            List<string> righe = new List<string>();

            if (File.Exists(path)) righe.AddRange(File.ReadAllLines(path));
            
            // Quindi a questo punto ho aperto il file e ho inizializzato le righe direi. Ma io devo spamparlo, questo non deve farlo.
            // Per prima cosa devo inserire i dati.
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Inserisci un nome: ");
                string parola = Console.ReadLine();
                
                righe.Add(parola);
            }
            
            // Adesso ho i nomi direi. devo scriverli in file.
            File.WriteAllLines(path, righe);
            
            // Adesso direi di leggerli
            Console.WriteLine("Nomi inseriti sono:");

            foreach (string parola in righe)
            {
                Console.WriteLine(parola);
            }
            
            // Adesso devo leggere quante righe ha:
            Console.WriteLine("Hai inserito " + righe.Count + " nomi");
            
               
            





        }
    }
}