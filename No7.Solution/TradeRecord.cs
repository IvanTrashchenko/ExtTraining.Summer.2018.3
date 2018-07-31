namespace No7.Solution
{
    public class TradeRecord
    {
        public TradeRecord(string destinationCurrency, string sourceCurrency, float lots, decimal price)
        {
            this.DestinationCurrency = destinationCurrency;
            this.Lots = lots;
            this.Price = price;
            this.SourceCurrency = sourceCurrency;
        }

        public string DestinationCurrency { get; }

        public float Lots { get; }

        public decimal Price { get; }

        public string SourceCurrency { get; }
    }
}
