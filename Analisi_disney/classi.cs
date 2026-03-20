using Microsoft.ML.Data;

// Questa serve SOLO per leggere il CSV originale
public class filmInput
{
    [LoadColumn(1)] public string Release_date;
    [LoadColumn(2)] public string Genre;         
    [LoadColumn(3)] public string MPAA_rating;
    [LoadColumn(4), ColumnName("Label")] public float Total_gross; 
}

// Questa serve per il Training e contiene il campo calcolato
public class film
{
    public string Release_date;
    public string Genre;         
    public string MPAA_rating;
    public float data_int; // Nessun LoadColumn qui!
    [ColumnName("Label")] public float Total_gross; 
}