using Microsoft.ML.Data;

public class Persona
{
    [LoadColumn(0)] public float age;
    [LoadColumn(1)] public string workclass;
    [LoadColumn(4)] public float edu_num;
    [LoadColumn(5)] public string mar_status;
    [LoadColumn(6)] public string occupation;
    [LoadColumn(7)] public string relationship;
    [LoadColumn(8)] public string race;
    [LoadColumn(9)] public string sex;
    [LoadColumn(10)] public float cap_gain;
    [LoadColumn(11)] public float cap_loss;
    [LoadColumn(12)] public float hpw;
    [LoadColumn(13)] public string native_c;
    [LoadColumn(14)] public string salary_str; // serve per il target
}

public class proPersona : Persona
{
    public float cap_tot { get; set; }
   // public float Label;                   // Questo sarà il nostro target
   [ColumnName("PredictedLabel")] // Fondamentale: punta alla colonna creata dal modello
   public bool PredictedLabel { get; set; }

   [ColumnName("Label")] // Punta alla tua colonna reale (0 o 1)
   public float Label { get; set; }
}