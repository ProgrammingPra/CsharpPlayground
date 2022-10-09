using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class Utils
    {
        private static String Before = "List Before: " + System.Environment.NewLine;
        private static String After = "List After: " + System.Environment.NewLine;

        internal static void Show<T, K>(List<T> oldList, string message = "", params List<K>[] newLists)
        {
            PrintBefore<T>(oldList, message);
            
            PrintAfter<K>(newLists);
        }

       
        private static string Print<T>(params List<T>[] lists)
        {

            var flattened = lists.Select(list => "[" + String.Join<T>(",", list) + "]").ToList();

            return String.Join(",", flattened);
        }

      

        internal static void PrintBefore<T>(List<T> list,string message = "")
        {
            Console.WriteLine("=======" + message + "===========");

            Console.WriteLine(Before + Print(list));
            
        }
        internal static void PrintAfter<T>(params List<T>[] lists)
        {

            Console.WriteLine(After + Print(lists));
        }
    }
}
