namespace SuperMarket.Calculation
{
    public class SimpleItemCalculator : IItemCalculator
    {
        public SimpleItemCalculator(int price)
        {
            Price = price;
        }

        public int Price { get; }

        public int Calculate(int count)
        {
            return count * Price;
        }
    }
}
