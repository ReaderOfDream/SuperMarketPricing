using SuperMarket.Calculation;
using System;
using System.Collections.Generic;
using Xunit;

namespace SuperMarket.tests
{
    public class SuperMarketTest
    {
        private readonly SuperMarketCalculator calculator;

        public SuperMarketTest()
        {
            var catalog = new Dictionary<char, IItemCalculator>()
            {
                {'A',new DiscountItemCalculator(30, 50, 2) },
                {'B',new SimpleItemCalculator(40) },
                {'C',new DiscountItemCalculator(50, 120, 3) },
            };

            calculator = new SuperMarketCalculator(catalog);
        }

        [Theory]
        [InlineData("A,A,B,C,C,A,A,B,C,B,A", 370)]
        public void Should_CalculateRightPrice_WhenInput(string input,int expectedPrice)
        {
            var result = calculator.Calculate(input);

            Assert.Equal(expectedPrice, result);
        }
    }
}
