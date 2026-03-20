using Microsoft.ML;
using Microsoft.ML.Data;
using ScottPlot;
// Classe principale
class Program
{
   static void Main()
    {var context = new MLContext(seed: 0);

        // --- 2. Caricamento Dati ---
        Console.WriteLine("Caricamento dati in corso...");
        IDataView dataView = context.Data.LoadFromTextFile<InsuranceData>("insurance.csv", hasHeader: true, separatorChar: ',');
        var trainTestSplit = context.Data.TrainTestSplit(dataView, testFraction: 0.2);

        // --- 3. Pipeline di Trasformazione e Training ---
        // Gli algoritmi ML leggono solo numeri. Dobbiamo convertire le stringhe in vettori numerici (OneHotEncoding).
        // L'idea è che per fare il fit devo necessariamente avere una colonna chiamata Features, che è qui che creo. Prima di
        // Farlo semplicemente converto le colonne non numeriche in numeri. Poi sceglie l'algoritmo
        var pipeline = context.Transforms.Categorical.OneHotEncoding("GenderEncoded", nameof(InsuranceData.Gender))
            .Append(context.Transforms.Categorical.OneHotEncoding("SmokerEncoded", nameof(InsuranceData.IsSmoker)))
            .Append(context.Transforms.Categorical.OneHotEncoding("RegionEncoded", nameof(InsuranceData.Region)))
            .Append(context.Transforms.Concatenate("Features", "Age", "BMI", "Children", "GenderEncoded", "SmokerEncoded", "RegionEncoded"))
            .Append(context.Regression.Trainers.FastTree()); // Algoritmo basato su alberi di decisione

        Console.WriteLine("Addestramento del modello...");
        var model = pipeline.Fit(trainTestSplit.TrainSet);

        // --- 4. Valutazione ---
        var predictions = model.Transform(trainTestSplit.TestSet);
        var metrics = context.Regression.Evaluate(predictions);
        Console.WriteLine($"Metriche Modello:\n - R-Squared: {metrics.RSquared:0.##}\n - MAE (Errore Medio): {metrics.MeanAbsoluteError:0.##} $");

        // --- 5. Visualizzazione con ScottPlot ---
        VisualizzaRisultati(context, model, trainTestSplit.TestSet);
    }

    static void VisualizzaRisultati(MLContext context, ITransformer model, IDataView testData)
    {
       /* // Estraiamo i dati per il grafico (primi 50 campioni)
        var predictionsRaw = model.Transform(testData);  // Fa le predizioni sostanzialmente
        // Creo un enumerable dai dati che ho predetto, cioè un oggetto della forma standard in C#, tipo passando da
        // una tabella csv (che è predictionsRaw) in un oggetto su cui si può scorrere ad esempio 
        var predictedEnumerable = context.Data.CreateEnumerable<InsurancePrediction>(predictionsRaw, reuseRowObject: false).ToArray();
        var actualEnumerable = context.Data.CreateEnumerable<InsuranceData>(testData, reuseRowObject: false).ToArray();

        double[] indices = Enumerable.Range(0, actualEnumerable.Length).Select(x => (double)x).ToArray();
        double[] actuals = actualEnumerable.Select(x => (double)x.Charges).ToArray();
        double[] predicts = predictedEnumerable.Select(x => (double)x.PredictedCharges).ToArray();

        // --- NUOVA SINTASSI SCOTTPLOT 5 ---
        var plt = new ScottPlot.Plot(); // In SP5 le dimensioni si passano nel Save()

        // Add.Scatter ora restituisce un oggetto "Scatter"
        var s1 = plt.Add.Scatter(indices, actuals);
        s1.Label = "Reale";
        s1.Color = Colors.Blue;

        var s2 = plt.Add.Scatter(indices, predicts);
        s2.Label = "Predetto";
        s2.Color = Colors.Red;

        // Titoli e Label
        plt.Title("Confronto Prezzi Assicurazione: Reale vs Predetto");
        plt.XLabel("Paziente (Campione)");
        plt.YLabel("Costo ($)");

        // La legenda ora si attiva così
        plt.ShowLegend();

        // Il salvataggio specifica qui la risoluzione
        plt.SavePng("RisultatoML.png", 800, 600);
    
        Console.WriteLine("Grafico generato con successo: RisultatoML.png");
        
        
        
        // Proviamo a capire quanto impatta il bmi e il fumare sulla media.
        // Intanto il bmi. Vorrei un grafico che all'aumentare del bmi mi dica quant'è la predizione. 
        foreach (var p in predicts)
        {
            p.BMI;
        }*/
       // Estraiamo i dati per il grafico (primi 50 campioni)
        var predictionsRaw = model.Transform(testData);  // Fa le predizioni sostanzialmente

        // Creo un enumerable dai dati che ho predetto, cioè un oggetto della forma standard in C#, tipo passando da
        // una tabella csv (che è predictionsRaw) in un oggetto su cui si può scorrere ad esempio 
        var predictedEnumerable = context.Data.CreateEnumerable<InsurancePrediction>(predictionsRaw, reuseRowObject: false).ToArray();
        var actualEnumerable = context.Data.CreateEnumerable<InsuranceData>(testData, reuseRowObject: false).ToArray();

        // Estraiamo i dati numerici per il primo grafico (usiamo i primi 50 per leggibilità)
        double[] indices = Enumerable.Range(0, actualEnumerable.Length).Select(x => (double)x).ToArray();
        double[] actuals = actualEnumerable.Select(x => (double)x.Charges).ToArray();
        double[] predicts = predictedEnumerable.Select(x => (double)x.PredictedCharges).ToArray();

        // --- NUOVA SINTASSI SCOTTPLOT 5 ---
        var plt = new ScottPlot.Plot(); // In SP5 le dimensioni si passano nel Save()

        // Add.Scatter ora restituisce un oggetto "Scatter"
        var s1 = plt.Add.Scatter(indices, actuals);
        s1.Label = "Reale";
        s1.Color = Colors.Blue;
        s1.LineWidth = 0; // Usiamo 0 per vedere solo i punti (Scatter puro)

        var s2 = plt.Add.Scatter(indices, predicts);
        s2.Label = "Predetto";
        s2.Color = Colors.Red;
        s2.LineWidth = 0;

        // Titoli e Label
        plt.Title("Confronto Prezzi Assicurazione: Reale vs Predetto");
        plt.XLabel("Paziente (Campione)");
        plt.YLabel("Costo ($)");

        // La legenda ora si attiva così
        plt.ShowLegend();

        // Il salvataggio specifica qui la risoluzione
        plt.SavePng("RisultatoML.png", 800, 600);
        Console.WriteLine("Grafico generato con successo: RisultatoML.png");

        // Proviamo a capire quanto impatta il bmi e il fumare sulla media.
        // Intanto il bmi. Vorrei un grafico che all'aumentare del bmi mi dica quant'è la predizione. 
        // Intanto devo partire da predicted enumerable, che è dove ho tutti i dati predetti direi
        double[] BMIs = actualEnumerable.Select(x => (double)x.BMI).ToArray();
        
        // Quindi ora ho due array
        // predicts -> Contiene quanto devi pagare per l'assicurazione
        // predicts_BMI -> Contiene il valore del BMI per quelle predizioni. Vorrei organizzarli però in ordine!
        
        
        double n_BMI = 0, n_pred = 0, n_act = 0;
        
        for (int i = 0; i < BMIs.Length; i++)
        {
            for (int j = 1; j < BMIs.Length; j++)
            {
                if (BMIs[j] < BMIs[j - 1])
                {
                    n_BMI = BMIs[j-1];
                    BMIs[j-1] = BMIs[j];
                    BMIs[j] = n_BMI;
                    
                    // Non ho finito il codice, in realtà volevo organizzrli ma bastava fare uno scatter
                }
            }
        }
        
    }
}
