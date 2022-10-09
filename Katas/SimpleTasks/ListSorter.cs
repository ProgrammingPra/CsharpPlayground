using Basics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Basics.ListOf;

namespace SimpleTasks
{
    //TODO
    //1. reverse sort
    //2. sort integers, strings, timestamps, CultureInfo accented strings
    //3. sort objects
    //4. sort with function, Comparer.Create
    //5. sort with OrderBy
    //6. sort arrays, diff lists
    //7. sort by string length
    //https://zetcode.com/csharp/sortlist/
    internal class ListSorter : ILister
    {

        public void ShowWhatYouCan()
        {
            List<UncomparableObject> unsortableList = ListOf.Unsortables();
            Utils.Show(unsortableList, "Sorting the unsortables", Sort(unsortableList));
            Utils.Show(unsortableList, "Sorting the unsortables by name", Sort(unsortableList, item => item.Name, null));


            var randomInts = ListOf.RandomInts();
            Utils.Show(randomInts, "Sorting random integers", Sort(randomInts));

            Utils.Show(randomInts, "Shuffling list of integers", Shuffle(randomInts));

            Utils.Show(randomInts, "Rotating left", RotateLeft(randomInts));

            Utils.Show(randomInts, "Rotating right", RotateRight(randomInts));
        }
       

        internal static List<T> Sort<T>(List<T> list, Comparer<T>? comparer = null)
        {
            try
            {
                
                return list.OrderBy(item => item, comparer).ToList();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Your objects are not sortable. Sorry. Your list will remain unsorted");
            }

            return list;
        }

        internal static List<T> Sort<T, TKey>(List<T> list, Func<T, TKey> selector,  Comparer<TKey>? comparer = null)
        {

            return list.OrderBy(selector, comparer).ToList();
        }

        private static List<T> RotateLeft<T>(List<T> list)
        {
            
            var queue = new Queue<T>(list);

            queue.Enqueue(queue.Dequeue());
            var newList = queue.ToList();

            //var newList = list.Skip(1).Take(list.Count - 1).ToList();

            return newList;
        }

        private static List<T> RotateRight<T>(List<T> list)
        {

            return list.Select((item, index) => list[((index - 1) + list.Count) % list.Count]).ToList();

        }

        private static List<T> Shuffle<T>(List<T> list)
        {

            Random random = new Random();
            
            return list.OrderBy(index => random.Next()).ToList();
        }


        //OPTION2 --> Array
        internal static List<T> SortAsArray<T>(List<T> list, Comparer<T>? comparer = null)
        {
            Array.Sort(list.ToArray(), comparer);
            return list;
        }

        //OPTION3 --> Sort
        internal static List<T> SortInPlace<T>(List<T> list, Comparer<T>? comparer = null)
        {

            if (comparer == null)
                SortDefault(list);
            else
                //in-place!
                list.Sort(comparer);


            return list;
        }


        //will use Comparer<T>.Default with compareTo() from IComparable<T>
        //comparer = Comparer<T>.Default;
        private static List<T> SortDefault<T>(List<T> list)
        {
            try
            {
                //in-place!
                list.Sort();
            }
            catch (Exception e)
            {
                Console.WriteLine("Your objects are not sortable. Sorry. Your list will remain unsorted");
            }

            return list;
        }

    }
}
