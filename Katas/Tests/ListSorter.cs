using Basics;
using Katas;
using NUnit.Framework.Internal;
using SimpleTasks;
using System.ComponentModel;
using static Basics.ListOf;

namespace Tests
{
    public class ListSorterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("13,1,2,4,7", "7,13,1,2,4")]
        public void RotateRight(string list, string expectedList)
        {
            List<int> intList = GetIntList(list);
            string sorted = ListToString(ListSorter.RotateRight(intList));

            Assert.That(expectedList.Equals(sorted));
        }

        [Test]
        [TestCase("13,1,2,4,7", "1,2,4,7,13")]
        public void RotateLeft(string list, string expectedList)
        {
            List<int> intList = GetIntList(list);
            string sorted = ListToString(ListSorter.RotateLeft(intList));

            Assert.That(expectedList.Equals(sorted));
        }

        [Test]
        [TestCase("13,1,2,1,4,13,7", "1,1,2,4,7,13,13")]
        public void SortBySelf(string list, string expectedList)
        {
            List<int> intList = GetIntList(list);
            string sorted = ListToString(ListSorter.SortBySelf(intList)); 

            Assert.That(expectedList.Equals(sorted));
        }

        [Test]
        [TestCase("13,1,2,1,4,7")]
        public void Shuffle(string list)
        {
            List<int> intList = GetIntList(list);
            List<int> shuffled = ListSorter.Shuffle(intList);

            Assert.That(shuffled.Count == intList.Count);
            Assert.That(shuffled.All(item => intList.Contains(item)));
        }

        [Test]
        public void SortUncomparables()
        {
            var unsortableList = ListOf.Unsortables();
            Assert.Throws<InvalidOperationException>(() => ListSorter.SortBySelf(unsortableList));
        }

        [Test]
        public void SortObjectsByAttr()
        {
            var objList = ListOf.RandomObjects();

            var sorted = ListSorter.SortByAttribute(objList, item => item.Name);

            Console.WriteLine(String.Join(",", sorted.Select(item => item.Name)));

            Assert.That(IsReallySorted(sorted));
        }

        static bool IsReallySorted(List<UncomparableObject> list)
        {
            Func<string, string, bool> alphabetic = (string1, string2) =>
            {
                return string1.ToCharArray()[0] <= string2.ToCharArray()[1];
            };

            return list.Select((item, index) => (item, index)).
                    All(tuple => tuple.index == 0 || alphabetic(tuple.item.Name, list[tuple.index - 1].Name));
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