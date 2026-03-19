using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string basePath = AppContext.BaseDirectory;
        string path = Path.Combine(basePath, "studenti.json");

        List<Studente> studenti;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            studenti = JsonSerializer.Deserialize<List<Studente>>(json);
        }
        else
        {
            studenti = new List<Studente>();
        }
     

        Console.WriteLine("Percorso file: " + path);
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
                int eta = int.Parse(Console.ReadLine());

                studenti.Add(new Studente
                {
                    Nome = nome,
                    Cognome = cognome,
                    Eta = eta
                });

                File.WriteAllText(path, JsonSerializer.Serialize(studenti));

                break;

            case 2:

                foreach (var s in studenti)
                {
                    Console.WriteLine($"{s.Nome} {s.Cognome} {s.Eta}");
                }

                break;

            case 3:

                Console.Write("Indice studente: ");
                int index = int.Parse(Console.ReadLine());

                studenti.RemoveAt(index);

                File.WriteAllText(path, JsonSerializer.Serialize(studenti));

                break;
        }
    }
}

class Studente
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public int Eta { get; set; }
}
