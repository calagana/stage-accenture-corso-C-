using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace Esercizio_csv2
{
    class Program
    {
        public static void Main()
        {
            string path = "Nomi.csv";
            List<string> righe = new List<string>(File.ReadAllLines(path));
            
            // Ora direi che posso semplicemente stamparle con strip
            foreach (string r in righe)
            {
                string[] colonne = r.Split(',');
                Console.WriteLine($"{colonne[0]} {colonne[1]} {colonne[2]}");
            }
            Console.WriteLine();
            
            // Stampo ora quelli che soddisfano solo una certa condizione di età
            Console.WriteLine("Persone sopra i 12 anni");
            foreach (string r in righe)
            {
                string[] colonne = r.Split(',');
                
                if (int.Parse(colonne[2]) > 12) Console.WriteLine($"{colonne[0]} {colonne[1]} {colonne[2]}");
            }
            
            Console.WriteLine();
            
            string pathj = "Studenti.json";
            
            List<Studente> studenti;

            if (File.Exists(pathj))
            {
                string json = File.ReadAllText(pathj);
                studenti = JsonSerializer.Deserialize<List<Studente>>(json);
            }
            else
            {
                studenti = new List<Studente>();
            }
            
            studenti.Add(new Studente
            {
                Nome = "Carlo",
                Cognome = "Lagana",
                Eta = 24
            });
            
            File.WriteAllText(pathj, JsonSerializer.Serialize(studenti));
            
            
            
            
            
            
            
            
        }
    }
}

class Studente
{
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public int Eta { get; set; }
}