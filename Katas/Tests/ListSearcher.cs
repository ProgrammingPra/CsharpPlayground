using Katas;
using NUnit.Framework.Internal;
using SimpleTasks;
using System.ComponentModel;

namespace Tests
{
    public class ListSearcherTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("13,1,2,1,4,13,13", "13:(3=[0,5,6]),1:(2=[1,3])")]
        public void GetDuplicates(string list, string expectedDuplicates)
        {
            List<int> intList = list.Split(",").Select(val => int.Parse(val.Trim())).ToList();
            var duplicates = ListSearcher.GetDuplicates(intList);

            string duplicatesString = String.Join(",", duplicates.Select(item =>
                item.Key + ":(" + item.Value.Item1 + "=[" + String.Join(",", item.Value.Item2)
                + "])"
            ));

            Assert.AreEqual(expectedDuplicates, duplicatesString);
        }

        

    }


}