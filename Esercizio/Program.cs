using System;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.VisualBasic.CompilerServices;
using MySql.Data.MySqlClient;

namespace Esercizio
{
    class Program
    {
        static void Main(string[] args)
        {
            string conne = "server=localhost;database=orchestra;user=root;password=root;";

            using (MySqlConnection conn = new MySqlConnection(conne))
            {
                conn.Open();
                while (true)
                {
                    Console.WriteLine("1) Inserisci CD");
                    Console.WriteLine("2) Rimuovi CD");
                    Console.WriteLine("3) Modifica CD");
                    Console.WriteLine("4) Visualizza i CD");
                    Console.WriteLine("0) Esci");

                    int test = int.Parse(Console.ReadLine());
                    
                    if (test == 0) break;
                    
                    switch (test)
                    {
                        case 1:
                            Console.Write("Inserisci nome CD: ");
                            string nome = Console.ReadLine();
                            
                            Console.Write("Inserisci autore CD: ");
                            string autore = Console.ReadLine();
                        
                            Console.Write("Inserisci la data di uscita del CD: ");
                            string data = Console.ReadLine();
                            
                            string comando = "INSERT INTO CD(nome, autore, uscita)  VALUES (@nome, @autore, @uscita)";
                            MySqlCommand cmdInsert = new MySqlCommand(comando, conn);

                            cmdInsert.Parameters.AddWithValue("@nome", nome);
                            cmdInsert.Parameters.AddWithValue("@autore", autore);
                            cmdInsert.Parameters.AddWithValue("@uscita", data);

                            cmdInsert.ExecuteNonQuery();
                            
                            Console.WriteLine("CD inserito");
                            break;
                        case 2:
                            Console.Write("Inserisci ID del CD da rimuovere: ");
                            int idDelete = int.Parse(Console.ReadLine());

                            string delete = "DELETE FROM studenti WHERE id=@id";
                            MySqlCommand cmdDelete = new MySqlCommand(delete, conn);

                            cmdDelete.Parameters.AddWithValue("@id", idDelete);

                            cmdDelete.ExecuteNonQuery();

                            Console.WriteLine("CD eliminato");
                            break;
                        case 3:
                            Console.Write("Modifica un CD. Inserisci l'id del CD da modificare: ");
                            int idMod = int.Parse(Console.ReadLine());
                            
                            Console.Write("Inserisci l'autore corretto del CD ");
                            
                            string select2 = "SELECT * FROM Orchestra WHERE  id = @idMod";
                            MySqlCommand cmdSelect2 = new MySqlCommand(select2, conn);
                            using (MySqlDataReader reader = cmdSelect2.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine(reader["nome"]);
                                }
                            }
                            string nuovotit = Console.ReadLine();

                            string update = "UPDATE studenti SET eta=@eta WHERE id=@id";
                            MySqlCommand cmdUpdate = new MySqlCommand(update, conn);

                            cmdUpdate.Parameters.AddWithValue("@Titolo", nuovotit);
                            cmdUpdate.Parameters.AddWithValue("@id", idMod);

                            cmdUpdate.ExecuteNonQuery();

                            Console.WriteLine("CD aggiornato");
                            break;
                        case 4:
                            string select = "SELECT * FROM studenti";
                            MySqlCommand cmdSelect = new MySqlCommand(select, conn);
                            
                            using (MySqlDataReader reader = cmdSelect.ExecuteReader())
                            {
                                Console.WriteLine("\nLista CD");

                                while (reader.Read())
                                {
                                    Console.WriteLine(
                                        reader["id"] + " " +
                                        reader["nome"] + " " +
                                        reader["titolo"] + " " +
                                        reader["uscita"]
                                    );
                                }
                            }

                            break;
                        
                        case 5:
                            Console.WriteLine("Hai sbagliato qualcosa, riprova");
                            break;
                    }




                }
                


            }



        }
    }
}