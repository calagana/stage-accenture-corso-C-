using System;

class array_bidim
{
    public static void Main()
    {
        
        Console.WriteLine("Inserire la dimensione x: ");
        int dimx = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Inserire la dimensione y: ");
        int dimy = int.Parse(Console.ReadLine());
        
        int[,] mat = new int[dimx, dimy];

        Random rand = new Random();
        
        Console.WriteLine("La matrice è:");
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                mat[i, j] = rand.Next(1, 51);
                Console.Write(mat[i, j] + " ");
            }
            Console.WriteLine();
        }
        
        Console.WriteLine("Sommo gli elementi sulla riga: ");
        int somma_totale = 0;
        for (int i = 0; i < mat.GetLength(0); i++)
        {
            int somma_riga = 0;
            for (int j = 0; j < mat.GetLength(1); j++)
            {
                somma_riga += mat[i, j];
                somma_totale += mat[i, j];
            }
            Console.WriteLine("Riga " + i + " = " + somma_riga );
        }
        Console.WriteLine("Somma totale = " + somma_totale);
        
        
    }
}