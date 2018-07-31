using System;
using System.Collections.Generic;
using System.IO;

namespace No7.Solution
{
    public class TradeService : ITradeService
    {
        private readonly List<string> lines;

        private readonly List<TradeRecord> trades;

        public TradeService()
        {
            this.trades = new List<TradeRecord>();
            this.lines = new List<string>();
        }

        public void ReadStream(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    this.lines.Add(line);
                }
            }
        }

        public void ParseToRecords()
        {
            foreach (var line in this.lines)
            {
                try
                {
                    this.trades.Add(line.ToRecord());
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void SaveToTable(string connectionString)
        {
            foreach (var trade in this.trades)
            {
                DatabaseSaver.Save(trade, connectionString);
            }

            Console.WriteLine("INFO: {0} trades processed", this.trades.Count);
        }
    }
}

// отдельный класс для работы пользователя со списком записей