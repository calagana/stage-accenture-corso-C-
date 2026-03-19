using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string path = "studenti.csv";

        List<string> righe = new List<string>(File.ReadAllLines(path));

        Console.WriteLine("1 Inserisci");
        Console.WriteLine("2 Visualizza");
        Console.WriteLine("3 Elimina");

        int scelta = int.Parse(Console.ReadLine());

        switch (scelta)
        {
            case 1:

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Cognome: ");
                string cognome = Console.ReadLine();

                Console.Write("Eta: ");
                string eta = Console.ReadLine();

                righe.Add($"{nome},{cognome},{eta}");

                File.WriteAllLines(path, righe);

                break;

            case 2:

                foreach (string r in righe)
                {
                    string[] colonne = r.Split(',');
                    Console.WriteLine($"{colonne[0]} {colonne[1]} {colonne[2]}");
                }

                break;

            case 3:

                Console.Write("Indice da eliminare: ");
                int index = int.Parse(Console.ReadLine());

                righe.RemoveAt(index);

                File.WriteAllLines(path, righe);

                break;
        }
    }
}