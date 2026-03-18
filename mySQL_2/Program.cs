using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        string connStr = "server=localhost;database=scuola;user=root;password=root;";

        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();

            Console.WriteLine("1 Inserisci studente");
            Console.WriteLine("2 Visualizza studenti");
            Console.WriteLine("3 Aggiorna studente");
            Console.WriteLine("4 Elimina studente");

            Console.Write("Scelta: ");
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

                    string insert = "INSERT INTO studenti (nome,cognome,eta) VALUES (@nome,@cognome,@eta)";
                    MySqlCommand cmdInsert = new MySqlCommand(insert, conn);

                    cmdInsert.Parameters.AddWithValue("@nome", nome);
                    cmdInsert.Parameters.AddWithValue("@cognome", cognome);
                    cmdInsert.Parameters.AddWithValue("@eta", eta);

                    cmdInsert.ExecuteNonQuery();

                    Console.WriteLine("Studente inserito");
                    break;

                case 2:

                    string select = "SELECT * FROM studenti";
                    MySqlCommand cmdSelect = new MySqlCommand(select, conn);

                    using (MySqlDataReader reader = cmdSelect.ExecuteReader())
                    {
                        Console.WriteLine("\nLista studenti");

                        while (reader.Read())
                        {
                            Console.WriteLine(
                                reader["id"] + " " +
                                reader["nome"] + " " +
                                reader["cognome"] + " " +
                                reader["eta"]
                            );
                        }
                    }

                    break;

                case 3:

                    Console.Write("ID studente: ");
                    int idUpdate = int.Parse(Console.ReadLine());

                    Console.Write("Nuova eta: ");
                    int nuovaEta = int.Parse(Console.ReadLine());

                    string update = "UPDATE studenti SET eta=@eta WHERE id=@id";
                    MySqlCommand cmdUpdate = new MySqlCommand(update, conn);

                    cmdUpdate.Parameters.AddWithValue("@eta", nuovaEta);
                    cmdUpdate.Parameters.AddWithValue("@id", idUpdate);

                    cmdUpdate.ExecuteNonQuery();

                    Console.WriteLine("Studente aggiornato");

                    break;

                case 4:

                    Console.Write("ID studente da eliminare: ");
                    int idDelete = int.Parse(Console.ReadLine());

                    string delete = "DELETE FROM studenti WHERE id=@id";
                    MySqlCommand cmdDelete = new MySqlCommand(delete, conn);

                    cmdDelete.Parameters.AddWithValue("@id", idDelete);

                    cmdDelete.ExecuteNonQuery();

                    Console.WriteLine("Studente eliminato");

                    break;

                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        }
    }
}
