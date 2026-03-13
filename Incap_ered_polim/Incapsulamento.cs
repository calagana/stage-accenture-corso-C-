namespace Incap_ered_polim
{
    public class Incapsulamento
    {
        private decimal saldo;
        public decimal Saldo
        {
            get { return saldo; }
            private set { saldo = value;}
        }

        // Questo è il costruttore
        public Incapsulamento(decimal saldoiniziale)
        {
            saldo = saldoiniziale;
        }

        public void Deposita(decimal importo)
        {
            if (importo > saldo)
            {
                saldo += importo;
            }
        }

        public void Preleva(decimal importo)
        {
            if (importo > 0 && importo <= saldo)
            {
                saldo -= importo;
            }
        }
        
    }
}