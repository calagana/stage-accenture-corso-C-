namespace Incap_ered_polim;

class Animale
{
    public virtual void FaiVerso()
    {
        Console.WriteLine("L'animale fa un verso.");
    }
}

class Cane : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Bau bau!!");
    }
}

class Gatto : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Miao Miao!!");
    }
}
