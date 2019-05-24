using SuperMarket.Calculation.StateFull;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket.Calculation.StateLess
{
    public class StateLessItemCalculator : ISuperMarketCalculator
    {
        private readonly IDictionary<char, IStateLessItemCalculator> calculators;
        private readonly IDictionary<char, ProductInfo> catalog;

        public StateLessItemCalculator(IDictionary<char, IStateLessItemCalculator> calculators, IDictionary<char, ProductInfo> catalog)
        {
            this.calculators = calculators;
            this.catalog = catalog;
        }

        public int Calculate(string input)
        {
            var items = input.Split(',');

            var mas = SeparateInput(items);

            var result = mas.Sum(i =>
            {
                var calculator = calculators[i.Key];
                var productInfo = catalog[i.Key];
                return calculator.Calculate(i.Value, productInfo);
            });

            return result;
        }

        private static IDictionary<char, int> SeparateInput(string[] items)
        {
            return items.GroupBy(i => i).ToDictionary(i => i.Key[0], es => es.Count());
        }
    }
}
