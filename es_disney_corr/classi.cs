using Microsoft.ML.Data;


public class MovieData
{
    [LoadColumn(0)]
    public string MovieTitle { get; set; }
    [LoadColumn(1)] public string ReleaseDate { get; set; } // Caricata come stringa per estrarre l'anno
    [LoadColumn(2)] public string Genre { get; set; }
    [LoadColumn(3)] public string MPAARating { get; set; }
    //[LoadColumn(4)] public float TotalGross { get; set; }
    [LoadColumn(4)] public float InflationAdjustedGross { get; set; } // Questa sarà la nostra Label (Target)
}


public class MoviePrediction
{
    [ColumnName("Score")]
    public float PredictedGross { get; set; }
}


// Classe di supporto per la trasformazione dell'anno
public class MovieYearData : MovieData
{
    public float Year { get; set; }
}