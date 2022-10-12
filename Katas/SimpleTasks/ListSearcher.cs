using Basics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Basics.ListOf;

namespace SimpleTasks
{

    public class ListSearcher : ILister
    {

        public void ShowWhatYouCan()
        {
           

        }

        private List<(string, string)> FindSpecCharsLinq(List<string> list)
        {
            
            return list.Select(val => (val, String.Join("", val.Where(character => !Char.IsLetterOrDigit(character))))).ToList();
        }

        public static Dictionary<T, (int, List<int>)> GetDuplicates<T>(List<T> list)
        {
            var duplicates = new Dictionary<T, (int, List<int>)>();

            //list.GroupBy(item => item).Where(group => group.Count() > 1).
            //   Select(group => group.)

            list.Select((value, index) => (value, index)).ToList().ForEach(item =>
            {
                if (duplicates.ContainsKey(item.value))
                {
                    duplicates[item.value].Item2.Add(item.index);
                    duplicates[item.value] = (duplicates[item.value].Item2.Count, duplicates[item.value].Item2) ;
                }
                    
                else
                    duplicates.Add(item.value, (1, new List<int>() { item.index }));
            });

            return duplicates.Where(keyValue => keyValue.Value.Item1 > 1).ToDictionary(item => item.Key,
                item => item.Value         );
        }




    }
}
