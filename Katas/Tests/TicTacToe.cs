using Katas;
using NUnit.Framework.Internal;
using System.ComponentModel;

namespace Tests
{
    public class TicTacToeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("2,3,5,15,75", 5, "5,5,5,13,72")]
        public void TakeFromTheRichestAndMiddleClass(string curDistribution, int minMoney, string expectedDistribution)
        {
            List<int> current = curDistribution.Split(",").Select(val => int.Parse(val.Trim())).ToList();

           string newDistribution = String.Join(",", SocialistDistribution.TakeFromTheRichestAndMiddleClass(current, minMoney));
            Console.WriteLine("NEW :" + newDistribution);
            Assert.That(expectedDistribution == newDistribution);
        }

        [Test]
        [TestCase("2,3,5,15,75", 5, "5,5,5,15,70")]
        [TestCase("2,3,5,45,45", 5, "5,5,5,42,43")]
        public void TakeFromTheRichest(string curDistribution, int minMoney, string expectedDistribution)
        {
            List<int> current = curDistribution.Split(",").Select(val => int.Parse(val.Trim())).ToList();

            string newDistribution = String.Join(",", SocialistDistribution.TakeFromTheRichest(current, minMoney));
            Console.WriteLine("NEW :" + newDistribution);
            Assert.That(expectedDistribution == newDistribution);
        }
    }

    public static class List
    {
        public static List<T> Of<T>(params T[] items)
        {
            return new List<T> (items);
        }
    }
}