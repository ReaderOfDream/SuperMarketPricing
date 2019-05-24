namespace SuperMarket.Calculation.StateLess
{
    public interface IStateLessItemCalculator
    {
        int Calculate(int items, ProductInfo discountRules);
    }
}