namespace SuperMarket.Calculation
{
    public class DiscountItemCalculator : IItemCalculator
    {
        public DiscountItemCalculator(int normalPrice, int discountPrice, int itemsToDiscount)
        {
            NormalPrice = normalPrice;
            DiscountPrice = discountPrice;
            ItemsToDiscount = itemsToDiscount;
        }

        public int NormalPrice { get; }
        public int DiscountPrice { get; }
        public int ItemsToDiscount { get; }

        public int Calculate(int items)
        {
            int discountItems = items / ItemsToDiscount; // 4/2 = 2
            var normalItems = items % ItemsToDiscount; // 4%2 = 0

            var discountPrice = DiscountPrice;
            var normalPrice = NormalPrice;

            return discountItems * discountPrice + normalItems * normalPrice; // 100
        }
    }
}
