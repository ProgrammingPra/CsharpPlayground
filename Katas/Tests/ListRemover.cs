using Basics;
using Katas;
using NUnit.Framework.Internal;
using SimpleTasks;
using System.ComponentModel;
using static Basics.ListOf;

namespace Tests
{
    public class ListRemoverTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("13,1,2,4,7", "2,4,7")]
        public void RemoveFirstTwo(string list, string expectedList)
        {
            List<int> intList = GetIntList(list);
            var removed = ListRemover.RemoveBy(intList, (item, index) => Enumerable.Range(0, 2).Contains(index));

            Assert.That(expectedList.Equals(ListToString(removed)));
        }

        [Test]
        [TestCase("13,1,2,4,7", "13,1,2")]
        public void RemoveLastTwo(string list, string expectedList)
        {
            List<int> intList = GetIntList(list);
            var removed = ListRemover.RemoveBy(intList, (item, index) => Enumerable.Range(intList.Count - 2, 2).Contains(index));

            Assert.That(expectedList.Equals(ListToString(removed)));
        }

        [Test]
        [TestCase("13,1,2,4,7", "13,1,7", 2, 3)]
        public void RemoveIndexRange(string list, string expectedList, int startIdx, int endIdx)
        {
            List<int> intList = GetIntList(list);
            var removed = ListRemover.RemoveBy(intList, (item, index) => Enumerable.Range(startIdx, endIdx).Contains(index));

            Assert.That(expectedList.Equals(ListToString(removed)));
        }


        static List<int> GetIntList(string list)
        {
            return list.Split(",").Select(val => int.Parse(val.Trim())).ToList();
        }

        static string ListToString<T>(List<T> list)
        {
            return String.Join(",", list);
        }



    }


}