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

    internal class ListReplacer: ILister
    {

        public void ShowWhatYouCan()
        {
           

        }

        private List<(string, string)> FindSpecCharsLinq(List<string> list)
        {
            
            return list.Select(val => (val, String.Join("", val.Where(character => !Char.IsLetterOrDigit(character))))).ToList();
        }

        


    }
}
