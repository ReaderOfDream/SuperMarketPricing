using SuperMarket.Calculation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var input = "A,A,B,C,C,A,A,B,C,B,A";

            var catalog = new Dictionary<char, IItemCalculator>()
            {
                {'A',new DiscountItemCalculator(30, 50, 2) },
                {'B',new SimpleItemCalculator(40) },
                {'C',new DiscountItemCalculator(50, 120, 3) },
            };

            var calculator = new SuperMarketCalculator(catalog);

            var result = calculator.Calculate(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }

    }
}
