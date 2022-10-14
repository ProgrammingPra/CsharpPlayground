using Katas;
using NUnit.Framework.Internal;
using System.ComponentModel;

namespace Tests
{
    public class NestedListerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("2,3,[5,15],75", "2,3,5,15,75")]
        public void Flatten(string multiLevel, string expectedOneLevel)
        {
            
        }

        
    }

    public static class Array
    {
        public static int[] Of(string multiLevelString)
        {
            var multiLevelList = new List<int>();

          /*  foreach (string item in multiLevelString.Split(","))
            {
                Type valueType = item.GetType();
                if (valueType.IsArray)
                    oneLevel.AddRange(Flatten(item as object[]));
                else
                    oneLevel.Add(item);
            }*/

            return multiLevelList.ToArray();
        }
    }
}