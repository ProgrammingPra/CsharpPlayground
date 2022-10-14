using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    //RemoveAt, RemoveRange, RemoveAll mutate in-place
    //LINQ does not
    public class ListRemover: ILister
    {
       

        public static List<T> RemoveBy<T>(List<T> list, Func<T, int, bool> kickOut)
        {
            Utils.PrintBefore(list);


            PrintItemsToRemove(list, kickOut);

            Func<T, int, bool> keepItem = (item, index) => !kickOut(item, index);
           

            List<T> newList = list.Where<T>(keepItem).ToList();

            Utils.PrintAfter(newList);

            return newList;
        }

        private static void PrintItemsToRemove<T>(List<T> list, Func<T, int, bool> kickOut)
        {
            List<(T, int)> kickedOut = list.Select((item, index) => (item, index)).ToList().Where(itemWithIdx => kickOut(itemWithIdx.Item1, itemWithIdx.Item2)).ToList();
            foreach (var (item, index) in kickedOut)
                Console.WriteLine("Removing item " + item + " at index " + index);

        }

        private static Func<T, int, bool> IndexFilter<T>(params int[] indices)
        {
           // Enumerable.Range(0, list.Count).Where(filter).ToArray();

            return (T item, int index) =>
            {

                bool keepInList = !indices.Contains(index);

                if (!keepInList)
                    Console.WriteLine("Removing item " + item + " with index " + index);
                return keepInList;
            };

        }



        public void ShowWhatYouCan()
        {
            //WHERE
            Console.WriteLine("Removing first two from list");
            RemoveBy(ListOf.RandomInts(), (item, index) => Enumerable.Range(0, 2).Contains(index));

            Console.WriteLine("Removing last two from list");
            var list = ListOf.RandomInts();
            RemoveBy(list, (item, index) => Enumerable.Range(list.Count - 2, 2).Contains(index));

            Console.WriteLine("Removing 2-4");
            RemoveBy(ListOf.RandomInts(), (item, index) => Enumerable.Range(2, 3).Contains(index));

            int[] indices = new int[] { 0, 3, 5 };
            Console.WriteLine("Removing indices " + String.Join(";", indices));
            RemoveBy(ListOf.RandomInts(), (item, index) => indices.Contains(index));

            list = ListOf.RandomInts();
            Console.WriteLine("Removing all even indices: ");
            RemoveBy(ListOf.RandomInts(), (item, index) => index % 2 == 0);

            Console.WriteLine("Removing all ");
            RemoveBy(ListOf.RandomInts(), (item, index) => true);

            Console.WriteLine("Removing all nulls");
            RemoveBy(ListOf.RandomStrings(), (item, index) => item == null);


            Console.WriteLine("Removing all empty or whitespace");
            RemoveBy(ListOf.RandomStrings(), (item, index) => item != null && item.Trim().Length == 0);

            //EXCEPT
            int[] toRemove = new int[] { 0, 3, 5 };
            List<int> ints = new List<int>() { 1, 5, 2, 3, 0, 3, 3, 5, 4 };
            Console.WriteLine("Removing all occurences of " + String.Join(", ", toRemove)
             + " from {" + String.Join(",", ints) + "}");

            Utils.PrintAfter(ints.Except(toRemove).ToList());

        }


    }
}
