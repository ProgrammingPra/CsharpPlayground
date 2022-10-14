using Basics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static Basics.ListOf;

namespace SimpleTasks
{

    public class IntLister : ILister
    {

        public void ShowWhatYouCan()
        {

        }

        public static List<int> GetLongestConsecutive(List<int> ints)
        {
            var orderedList = ints.OrderBy(value => value).ToList();
            List<int> longestConsec = new List<int> { orderedList[0] };

            int curIndex = 1;
            while (curIndex < ints.Count)
            {
                var consecSublist = orderedList.Select((value, index) => (value, index)).TakeWhile(
                    item => item.index == 0 || item.value == orderedList[item.index - 1] + 1).ToList();

                if (consecSublist.Count > longestConsec.Count)
                    longestConsec = consecSublist.Select(item => item.value).ToList();

                curIndex += consecSublist.Count;
            }

            return longestConsec;
        }


        public static List<List<int>> GetPermutations(List<int> ints)
        {
            //stop recursion 
            if (ints.Count == 1)
                return new List<List<int>> { new List<int>() { ints[0] } };

            //start recursion 
            var permutations = new List<List<int>>();

            //remove duplicates
            var nums = ints.Distinct().ToList();
            foreach (var first in nums)
            {
                //all permutations of sublist
                var restListPermutations = GetPermutations(nums.Where(val => val != first).ToList());

                foreach (var partPermutation in restListPermutations)
                    permutations.Add(partPermutation.Prepend(first).ToList());

            }

            return permutations;

        }


    }
}
