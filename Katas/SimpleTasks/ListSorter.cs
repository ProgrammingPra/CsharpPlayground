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
    
    public class ListSorter : ILister
    {
        
        public static List<T> SortBySelf<T>(List<T> list, Comparer<T>? comparer = null)
        {
            return SortByAttribute(list, item => item, comparer);
        }

        public static List<T> SortByAttribute<T, TKey>(List<T> list, Func<T, TKey> selector,  Comparer<TKey>? comparer = null)
        {
           return list.OrderBy(selector, comparer).ToList();
        }

        public static List<T> RotateLeft<T>(List<T> list)
        {
            var queue = new Queue<T>(list);

            queue.Enqueue(queue.Dequeue());
            var newList = queue.ToList();

            //var newList = list.Skip(1).Take(list.Count - 1).ToList();

            return newList;
        }

        public static List<T> RotateRight<T>(List<T> list)
        {

            return list.Select((item, index) => list[((index - 1) + list.Count) % list.Count]).ToList();

        }

        public static List<T> Shuffle<T>(List<T> list)
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
        //will use Comparer<T>.Default with compareTo() from IComparable<T>
        //comparer = Comparer<T>.Default;
        internal static List<T> SortInPlace<T>(List<T> list, Comparer<T>? comparer = null)
        {

            if (comparer == null)
                list.Sort(comparer);
            else
                //in-place!
                list.Sort(comparer);


            return list;
        }

        public void ShowWhatYouCan()
        {
            List<UncomparableObject> unsortableList = ListOf.Unsortables();
            Utils.Show(unsortableList, "Sorting the unsortables", SortBySelf(unsortableList));
            Utils.Show(unsortableList, "Sorting the unsortables by name", SortByAttribute(unsortableList, item => item.Name, null));


            var randomInts = ListOf.RandomInts();
            Utils.Show(randomInts, "Sorting random integers", SortBySelf(randomInts));

            Utils.Show(randomInts, "Shuffling list of integers", Shuffle(randomInts));

            Utils.Show(randomInts, "Rotating left", RotateLeft(randomInts));

            Utils.Show(randomInts, "Rotating right", RotateRight(randomInts));
        }

    }
}
