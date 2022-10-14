using Katas;
using NUnit.Framework.Internal;
using SimpleTasks;
using System.ComponentModel;

namespace Tests
{
    public class IntListerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("13,1,3,80,2,4,55,5", "1,2,3,4,5")]
        public void GetLongestConsecutive(string list, string expectedConsecutive)
        {
            List<int> intList = list.Split(",").Select(val => int.Parse(val.Trim())).ToList();
            string longestConsec = String.Join(",", IntLister.GetLongestConsecutive(intList));

            Console.Write(longestConsec);

            Assert.AreEqual(expectedConsecutive, longestConsec);
        }

        [Test]
        [TestCase("1,2", "[1,2],[2,1]")]
        [TestCase("1,2,3", "[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]")]
        public void GetPermutations(string list, string expectedPermutations)
        {
            List<int> intList = list.Split(",").Select(val => int.Parse(val.Trim())).ToList();

            string permutations = String.Join(",", IntLister.GetPermutations(intList).Select(list => "[" + String.Join(",", list) + "]"));

            Console.Write(permutations);

            Assert.AreEqual(expectedPermutations, permutations);
        }


    }


}