using System;
using System.Collections.Generic;
using WooliesXChallenge.Dto;
using WooliesXChallenge.Dto.Request;
using WooliesXChallenge.Services;
using Xunit;

namespace WooliesXChallenge.UnitTests.Services
{
    public class TrolleyCalculatorTests
    {
        private static List<List<int>> _answer = new List<List<int>>();

        [Fact]
        public void CalculateCheapestTrolley_Test()
        {
            var trolley = new Trolley
            {
                Products = new List<Product>
                {
                    new Product {Name = "Test Product A", Price = 10}
                },
                Specials = new List<Special>
                {
                    new Special { Quantities = new List<Quantity>
                        {
                            new Quantity { Name = "Test Product A", quantity = 5}
                        },
                            Total = 5
                        },
                    new Special { Quantities = new List<Quantity>
                        {
                            new Quantity { Name = "Test Product A", quantity = 3}
                        },
                        Total = 3
                    },
                },
                Quantities = new List<Quantity>
                {
                    new Quantity {Name = "Test Product A", quantity = 11}
                }
            };

            var trolleyCalculator = new TrolleyCalculator();

            var amount = trolleyCalculator.CalculateCheapestTrolley(trolley);

            Assert.Equal(29m, amount);
        }

        [Fact]
        public void Test()
        {
            List<int> numbers = new List<int>() { 1 };
            int target = 11;
            sum_up(numbers, target);
        }

        private static void sum_up(List<int> numbers, int target)
        {
            sum_up_recursive(numbers, target, new List<int>());
        }

        private static void sum_up_recursive(List<int> numbers, int target, List<int> partial)
        {
            int s = 0;
            foreach (int x in partial) s += x;

            if (s == target)
                Console.WriteLine("sum(" + string.Join(",", partial.ToArray()) + ")=" + target);
            

            if (s >= target)
                return;

            for (int i = 0; i < numbers.Count; i++)
            {
                List<int> remaining = new List<int>();
                int n = numbers[i];
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    remaining.Add(numbers[j]);
                }

                List<int> partial_rec = new List<int>(partial);
                partial_rec.Add(n);
                sum_up_recursive(remaining, target, partial_rec);
            }
        }

        [Fact]
        public void Test2()
        {
            List<int> numbers = new List<int>() { 1 };
            int target = 11;
            sum_up_reuse(numbers, target);

            Assert.Equal(1, _answer.Count);
            Assert.Equal(1, _answer[0][0]);
            Assert.Equal(1, _answer[0][1]);
            Assert.Equal(1, _answer[0][2]);
            Assert.Equal(1, _answer[0][3]);
            Assert.Equal(1, _answer[0][4]);
        }

        private static void sum_up_reuse(List<int> numbers, int target)
        {
            sum_up_reuse_recursive(numbers, target, new List<int>());
        }

        private static void sum_up_reuse_recursive(List<int> numbers, int target, List<int> toAdd)
        {
            int sum = 0;
            foreach (var add in toAdd)
            {
                sum += add;
            }

            if (sum == target)
            {
                _answer.Add(toAdd);
            }

            if (sum > target)
            {
                return;
            }

            toAdd.Add(numbers[0]);

            sum_up_reuse_recursive(numbers, target, toAdd);
        }
    }
}
