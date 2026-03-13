namespace Incap_ered_polim;

class Veicolo
{
    public string Marca { get; set; }

    public void Avvia()
    {
        Console.WriteLine("Il veicolo si avvia");
    }
}

class Auto : Veicolo
{
    public int NumeroPorte{ get; set; }

    public void SuonaClacson()
    {
        Console.WriteLine("Beep Beep");
    }
}