using System;
using System.Collections.Generic;
using System.IO;

namespace No7.Solution
{
    public class TradeService
    {
        private const float LotSize = 100000f;

        private readonly List<string> lines;

        private readonly List<TradeRecord> trades;

        public TradeService()
        {
            this.trades = new List<TradeRecord>();
            this.lines = new List<string>();
        }

        public void HandleTable()
        {
            var lineCount = 1;
            foreach (var line in this.lines)
            {
                var fields = line.Split(new char[] { ',' });

                if (fields.Length != 3)
                {
                    Console.WriteLine("WARN: Line {0} malformed. Only {1} field(s) found.", lineCount, fields.Length);
                    continue;
                }

                if (fields[0].Length != 6)
                {
                    Console.WriteLine("WARN: Trade currencies on line {0} malformed: '{1}'", lineCount, fields[0]);
                    continue;
                }

                if (!int.TryParse(fields[1], out var tradeAmount))
                {
                    Console.WriteLine(
                        "WARN: Trade amount on line {0} not a valid integer: '{1}'",
                        lineCount,
                        fields[1]);
                }

                if (!decimal.TryParse(fields[2], out var tradePrice))
                {
                    Console.WriteLine("WARN: Trade price on line {0} not a valid decimal: '{1}'", lineCount, fields[2]);
                }

                var sourceCurrencyCode = fields[0].Substring(0, 3);
                var destinationCurrencyCode = fields[0].Substring(3, 3);

                var trade = new TradeRecord(
                    destinationCurrencyCode,
                    sourceCurrencyCode,
                    tradeAmount / LotSize,
                    tradePrice);

                this.trades.Add(trade);

                lineCount++;
            }
        }

        public void ReadTable(Stream stream)
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

        public void SaveTable()
        {
            foreach (var trade in this.trades)
            {
                DatabaseSaver.Save(trade);
            }
        }
    }
}