using System;

namespace No7.Solution
{
    public static class StringParser
    {
        private const float LotSize = 100000f;

        public static TradeRecord ToRecord(this string line)
        {
            var fields = line.Split(new char[] { ',' });

            if (fields.Length != 3)
            {
                throw new InvalidOperationException($"WARN: Line malformed. Only {fields.Length} field(s) found.");
            }

            if (fields[0].Length != 6)
            {
                throw new InvalidOperationException($"WARN: Trade currencies malformed: '{fields[0]}'");
            }

            if (!int.TryParse(fields[1], out var tradeAmount))
            {
                Console.WriteLine("WARN: Trade amount not a valid integer: '{0}'", fields[1]);

                // throw new InvalidOperationException($"WARN: Trade amount not a valid integer: '{fields[1]}'");
            }

            if (!decimal.TryParse(fields[2], out var tradePrice))
            {
                Console.WriteLine("WARN: Trade price not a valid decimal: '{0}'", fields[2]);

                // throw new InvalidOperationException($"WARN: Trade price not a valid decimal: '{fields[2]}'");
            }

            var sourceCurrencyCode = fields[0].Substring(0, 3);
            var destinationCurrencyCode = fields[0].Substring(3, 3);

            return new TradeRecord(destinationCurrencyCode, sourceCurrencyCode, tradeAmount / LotSize, tradePrice);
        }
    }

    // класс с методом расширения строка -> запись
}