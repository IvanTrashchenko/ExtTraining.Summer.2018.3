using System.Reflection;

namespace No7.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("No7.Solution.Console.trades.txt");

            TradeService a = new TradeService();

            a.ReadTable(tradeStream);

            a.HandleTable();

            a.SaveTable();

            System.Console.ReadKey();
        }
    }
}