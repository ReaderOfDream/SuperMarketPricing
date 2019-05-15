using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket.Calculation
{
    public class SuperMarketCalculator
    {
        public IDictionary<char, IItemCalculator> Catalog { get; }

        public SuperMarketCalculator(IDictionary<char, IItemCalculator> catalog)
        {
            Catalog = catalog;
        }

        public int Calculate(string input)
        {
            var items = input.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            var mas = SeparateInput(items);

            var result = mas.Sum(i =>
            {
                var calculator = Catalog[i.Key];
                return calculator.Calculate(i.Value);
            });

            return result;
        }

        private static IDictionary<char, int> SeparateInput(string[] items)
        {
            return items.GroupBy(i => i).ToDictionary(i => i.Key[0], es => es.Count());
        }
    }
}
