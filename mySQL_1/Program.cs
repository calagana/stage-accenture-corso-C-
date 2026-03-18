using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connStr = "server=localhost;database=scuola;user=root;password=root;";

        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            conn.Open();

            Console.WriteLine("Connessione riuscita");

            // ---------------------------
            // CREATE
            // ---------------------------

            string insertQuery = "INSERT INTO studenti (nome, cognome, eta) VALUES (@nome,@cognome,@eta)";

            MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);

            insertCmd.Parameters.AddWithValue("@nome", "Mario");
            insertCmd.Parameters.AddWithValue("@cognome", "Rossi");
            insertCmd.Parameters.AddWithValue("@eta", 22);

            insertCmd.ExecuteNonQuery();

            Console.WriteLine("Studente inserito");


            // ---------------------------
            // READ
            // ---------------------------

            string selectQuery = "SELECT * FROM studenti";

            MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn);

            using (MySqlDataReader reader = selectCmd.ExecuteReader())
            {
                Console.WriteLine("\nLista studenti:");

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


            // ---------------------------
            // UPDATE
            // ---------------------------

            string updateQuery = "UPDATE studenti SET eta=@eta WHERE id=1";

            MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);

            updateCmd.Parameters.AddWithValue("@eta", 30);

            updateCmd.ExecuteNonQuery();

            Console.WriteLine("\nStudente aggiornato");


            // ---------------------------
            // DELETE
            // ---------------------------
/*
            string deleteQuery = "DELETE FROM studenti WHERE id=1";

            MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn);

            deleteCmd.ExecuteNonQuery();

            Console.WriteLine("Studente eliminato");
  */
        }

        Console.WriteLine("\nOperazioni completate");
    }
}
