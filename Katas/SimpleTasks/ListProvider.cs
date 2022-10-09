using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class ListOf
    {
        private static string[] Bugs = new string[] { "reality101Failure", "Bloombug", "Hindenbug", "HiggsBugson", "hydraBug", "commonLawFeature", "Heisenbug", "MadGirlfriendBug", "LochNessMonsterBug" };
        private static string[] CodeFeatures = new string[] {"yodaConditions", "Ninja Comments", "JengaCode", "megamoth", "GodObject"};
        private static string[] Processes = new string[] { "DrugReport", "FearDriveDevelopment", "aDuck", "featuritis", "satisficing", "AssDrivenDevelopment", "ButtDebugging", "ChugReport", "ShrugReport", "SmugReport" };
        

    internal static List<UncomparableObject> Unsortables()
        {
            return new List<UncomparableObject>() { new UncomparableObject("Second"), new UncomparableObject("First") };
        }

        internal static List<UncomparableObject> RandomObjects()
        {
            List<string> names = RandomStrings();
            List<UncomparableObject> objects = new List<UncomparableObject>();

            names.ForEach(name => objects.Add(new UncomparableObject(name)));

            return objects;
        }

        internal static List<ICloneable> Clonify(List<UncomparableObject> cloneables)
        {

          

            return cloneables.OfType<ICloneable>().ToList();
        }
        internal static List<ICloneable> RandomCloneables()
        {
            
            List<UncomparableObject> objects = RandomObjects();

            return objects.OfType<ICloneable>().ToList();
        }


        internal static List<int> RandomInts()
        {
            var random = new Random();
            return Enumerable.Range(1, 100).OrderBy(i => random.Next()).Take(6).ToList();
        }

        internal static List<string> RandomStringsWithWhiteSpacesAndNulls()
        {
            var random = new Random();
            string[] nulls = new string[random.Next(1, 6)];
            Array.Fill(nulls, null);

            string[] empties = new string[] {"", "  ", " ", "\t", "\n" };

            
            return Enumerable.Concat(RandomStrings(), nulls).
                Concat(empties).
                OrderBy(i => random.Next()).ToList();
       
        }

        internal static List<string> RandomStrings()
        {
            var random = new Random();

           
            var randNums = Enumerable.Range(1, 10).OrderBy(i => random.Next()).Take(3).ToList();
            Func<string, int, bool> randomPick = (item, index) => randNums.Contains(index);
            return Enumerable.Concat(Bugs.Where(randomPick), Processes.Where(randomPick)).
                Concat(CodeFeatures.Where(randomPick)).
                OrderBy(i => random.Next()).ToList();

        }

        internal class UncomparableObject : ICloneable
        {
            internal string Name;

            internal UncomparableObject(string name)
            {
                this.Name = name;
            }

            public object Clone()
            {
                return new UncomparableObject(this.Name + "Clone");
            }

            public override string ToString()
            {
                return this.Name;
            }
        }
    }
}
