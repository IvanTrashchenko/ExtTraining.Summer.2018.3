using System.Configuration;
using System.Reflection;

namespace No7.Solution.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tradeStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream("No7.Solution.Console.trades.txt");

            string connectionString = ConfigurationManager.ConnectionStrings["TradeData"].ConnectionString;

            /*var tradeProcessor = new TradeHandler();

            tradeProcessor.HandleTrades(tradeStream);*/

            ITradeService a = new TradeService();

            a.ReadStream(tradeStream);

            a.ParseToRecords();

            a.SaveToTable(connectionString);

            System.Console.ReadKey();
        }
    }
}