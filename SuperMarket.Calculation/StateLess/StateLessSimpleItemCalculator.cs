namespace SuperMarket.Calculation.StateLess
{
    public class StateLessSimpleItemCalculator : IStateLessItemCalculator
    {
        public int Calculate(int items, ProductInfo info)
        {
            return items * info.NormalPrice;
        }
    }
}
