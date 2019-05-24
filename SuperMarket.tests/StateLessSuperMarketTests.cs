using SuperMarket.Calculation.StateFull;
using SuperMarket.Calculation.StateLess;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SuperMarket.tests
{
    public class StateLessSuperMarketTests
    {
        private readonly ISuperMarketCalculator calculator;

        public StateLessSuperMarketTests()
        {
            var stateLessDiscountItemCalculator = new StateLessDiscountItemCalculator();
            var stateLessSimpleItemCalculator = new StateLessSimpleItemCalculator();
            var calculatorCatalog = new Dictionary<char, IStateLessItemCalculator>()
            {
                {'A', stateLessDiscountItemCalculator },
                {'B', stateLessSimpleItemCalculator },
                {'C', stateLessDiscountItemCalculator }
            };

            var discountCatalog = new Dictionary<char, ProductInfo>
            {
                {'A', new ProductInfo(30, 50, 2)},
                {'B', new ProductInfo(40, 0 , 0)},
                {'C', new ProductInfo(50, 120, 3)}
            };

            calculator = new StateLessItemCalculator(calculatorCatalog, discountCatalog);
        }

        [Theory]
        [InlineData("A,A,B,C,C,A,A,B,C,B,A", 370)]
        public void Should_CalculateRightPrice_WhenInput(string input, int expectedPrice)
        {
            var result = calculator.Calculate(input);

            Assert.Equal(expectedPrice, result);
        }
    }
}
