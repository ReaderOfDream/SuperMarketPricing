using SuperMarket.Calculation;
using SuperMarket.Calculation.StateFull;
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

            Console.WriteLine(AnotherApproach(input));

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

        public static int AnotherApproach(string input)
        {
            var checkout = new Checkout();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ',')
                {
                    checkout.Scan(input[i]);
                }
            }

            return checkout.Total;
        }


    public class Checkout
        {
            private Dictionary<char, int> _prices;
            private Dictionary<char, Offer> _offers;
            private Dictionary<char, int> _itemCounters;

            public Checkout()
            {
                _itemCounters = new Dictionary<char, int> { { 'A', 0 }, { 'B', 0 }, { 'C', 0 } };
                _prices = new Dictionary<char, int> { { 'A', 30 }, { 'B', 40 }, { 'C', 50 } };
                _offers = new Dictionary<char, Offer>
            {
                {'A', new Offer { Discount = 10, NumberOfItems = 2}},
                {'C', new Offer { Discount = 30, NumberOfItems = 3}},
            };
            }
            public int Total { get; private set; }

            public void Scan(char item)
            {
                _itemCounters[item]++;
                Total += _prices[item];
                if (HasOffer(item) && RequiredNumber(item))
                {
                    Total -= _offers[item].Discount;
                }
            }

            private bool HasOffer(char item)
            {
                return _offers.ContainsKey(item);
            }

            private bool RequiredNumber(char item)
            {
                return _itemCounters[item] == _offers[item].NumberOfItems;
            }
        }

        public class Offer
        {
            public int Discount { get; set; }
            public int NumberOfItems { get; set; }
        }
    }
}
