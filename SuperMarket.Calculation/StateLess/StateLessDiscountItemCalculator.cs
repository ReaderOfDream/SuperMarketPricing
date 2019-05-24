namespace SuperMarket.Calculation.StateLess
{
    public class StateLessDiscountItemCalculator : IStateLessItemCalculator
    {
        public int Calculate(int items, ProductInfo discountRules)
        {
            int discountItems = items / discountRules.ItemsToDiscount;
            var normalItems = items % discountRules.ItemsToDiscount;

            var discountPrice = discountRules.DiscountPrice;
            var normalPrice = discountRules.NormalPrice;

            return discountItems * discountPrice + normalItems * normalPrice;
        }
    }
}
