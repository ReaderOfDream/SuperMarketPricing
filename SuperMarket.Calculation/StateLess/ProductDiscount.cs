namespace SuperMarket.Calculation.StateLess
{
    public class ProductInfo
    {
        public ProductInfo(int normalPrice, int discountPrice, int itemsToDiscount)
        {
            NormalPrice = normalPrice;
            DiscountPrice = discountPrice;
            ItemsToDiscount = itemsToDiscount;
        }

        public int NormalPrice { get; private set; }
        public int DiscountPrice { get; private set; }
        public int ItemsToDiscount { get; private set; }
    }
}
