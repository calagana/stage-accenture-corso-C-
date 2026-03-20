using Microsoft.ML.Data;

public class InsuranceData
{
    [LoadColumn(0)] public float Age;
    [LoadColumn(1)] public string Gender; // Verrà trasformato in numeri
    [LoadColumn(2)] public float BMI;
    [LoadColumn(3)] public float Children;
    [LoadColumn(4)] public string IsSmoker;
    [LoadColumn(5)] public string Region;
    [LoadColumn(6), ColumnName("Label")] public float Charges; // Il Target
}

/*public class InsurancePrediction
{
    [ColumnName("Score")] public float PredictedCharges;
}*/

public class InsurancePrediction
{
    [ColumnName("Score")] 
    public float PredictedCharges;

    // ML.NET vede che questi nomi esistono nei dati originali e li "copia" qui
    public float BMI; 
    public float Age;
}