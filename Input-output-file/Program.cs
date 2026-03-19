using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string path = "studenti.txt";

        Console.WriteLine("1 Inserisci");
        Console.WriteLine("2 Visualizza");
        Console.WriteLine("3 Aggiorna");
        Console.WriteLine("4 Elimina");

        int scelta = int.Parse(Console.ReadLine());

        List<string> righe = new List<string>();

        if (File.Exists(path))
            righe.AddRange(File.ReadAllLines(path));

        switch (scelta)
        {
            // CREATE
            case 1:
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Cognome: ");
                string cognome = Console.ReadLine();

                Console.Write("Eta: ");
                string eta = Console.ReadLine();

                righe.Add($"{nome},{cognome},{eta}");
                File.WriteAllLines(path, righe);

                Console.WriteLine("Studente inserito");
                break;

            // READ
            case 2:
                foreach (string r in righe)
                    Console.WriteLine(r);
                break;

            // UPDATE
            case 3:
                Console.Write("Indice riga da modificare: ");
                int index = int.Parse(Console.ReadLine());

                Console.Write("Nuova riga (nome,cognome,eta): ");
                string nuova = Console.ReadLine();

                righe[index] = nuova;
                File.WriteAllLines(path, righe);

                Console.WriteLine("Aggiornato");
                break;

            // DELETE
            case 4:
                Console.Write("Indice riga da eliminare: ");
                int delete = int.Parse(Console.ReadLine());

                righe.RemoveAt(delete);
                File.WriteAllLines(path, righe);

                Console.WriteLine("Eliminato");
                break;
        }
    }
}