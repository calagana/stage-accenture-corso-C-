using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Studente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public int Eta { get; set; }
    
    public int Voto { get; set; } 
}

public class ScuolaContext : DbContext
{
    public DbSet<Studente> Studenti { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string connStr = "server=localhost;database=scuola;user=root;password=root;";

        options.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var db = new ScuolaContext())
        {
            Console.WriteLine("Connessione riuscita");

            // ---------------------------
            // CREATE
            // ---------------------------

            var studente = new Studente
            {
                Nome = "Mario",
                Cognome = "Rossi",
                Eta = 21,
                Voto = 15
            };

            var studente2 = new Studente
            {
                Nome = "Paolo",
                Cognome = "Di Paolo",
                Eta = 23,
                Voto = 25
            };
            
            var studente3 = new Studente
            {
                Nome = "Gennaro",
                Cognome = "Bullo",
                Eta = 22,
                Voto = 23
            };
            
            db.Studenti.Add(studente);
            db.Studenti.Add(studente2);
            db.Studenti.Add(studente3);
            Console.WriteLine();
            db.SaveChanges();

            Console.WriteLine("Studente inserito");


            // ---------------------------
            // READ
            // ---------------------------

            var studenti = db.Studenti.ToList();

            Console.WriteLine("\nLista studenti:");

            foreach (var s in studenti)
            {
                Console.WriteLine($"{s.Id} {s.Nome} {s.Cognome} {s.Eta}");
            }
            Console.WriteLine();
            
            // Ricerca voti >= 6
            Console.WriteLine("Studenti sopra il 18: ");
            foreach (var s in studenti)
            {
                if(s.Voto >= 18) Console.WriteLine($"{s.Id} {s.Nome} {s.Cognome} {s.Eta}");
            }
            
            Console.WriteLine("Studenti sopra i 20 anni: ");
            foreach (var s in studenti)
            {
                if(s.Eta >= 20) Console.WriteLine($"{s.Id} {s.Nome} {s.Cognome} {s.Eta} Voto =  {s.Voto}");
            }

            Console.WriteLine();
            var studenti_ordinati = studenti.OrderBy(s => s.Voto);
            Console.WriteLine("Per voto: ");
            // Li stampo ordinati
            foreach (var s in studenti_ordinati)
            {
                Console.WriteLine($"{s.Id} {s.Nome} {s.Cognome} {s.Eta}, Voto = {s.Voto}");
            }
            
            Console.WriteLine();
            
            Console.WriteLine();
            var studenti_ordinati_nome = studenti.OrderBy(s => s.Nome);
            Console.WriteLine("Per Nome: ");
            // Li stampo ordinati
            foreach (var s in studenti_ordinati_nome)
            {
                Console.WriteLine($"{s.Id} {s.Nome} {s.Cognome} {s.Eta}, Voto = {s.Voto}");
            }
            
            Console.WriteLine();

            
            // Trovo la media, il max e il min 
            double media = studenti.Average(s => s.Voto);
            double max = studenti.Max(s => s.Voto);
            double min = studenti.Min(s => s.Voto);

            Console.WriteLine($"I valori sono: {media}, {max}, {min}");
            

            // ---------------------------
            // UPDATE
            // ---------------------------

            var studenteUpdate = db.Studenti.FirstOrDefault(s => s.Id == 1);

            if (studenteUpdate != null)
            {
                studenteUpdate.Eta = 30;
                db.SaveChanges();

                Console.WriteLine("\nStudente aggiornato");
            }


            // ---------------------------
            // DELETE
            // ---------------------------
            /*
            var studenteDelete = db.Studenti.FirstOrDefault(s => s.Id == 1);

            if (studenteDelete != null)
            {
                db.Studenti.Remove(studenteDelete);
                db.SaveChanges();

                Console.WriteLine("Studente eliminato");
            }
            */
        }

        Console.WriteLine("\nOperazioni completate");
    }
}
