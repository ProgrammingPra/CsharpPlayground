using Basics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static Basics.ListOf;

namespace SimpleTasks
{

    internal class NestedLister : ILister
    {

        public void ShowWhatYouCan()
        {
          
        }

        public List<int> FlattenOneLevel(int[][] list)
        {
            return list.SelectMany(item => item).ToList();
        }

        public List<object> Flatten(object[] multiLevel)
        {
            List<object> oneLevel = new List<object>();

            foreach(object item in multiLevel)
            {
                Type valueType = item.GetType();
                if (valueType.IsArray)
                    oneLevel.AddRange(Flatten(item as object[]));
                else
                    oneLevel.Add(item);
            }

            return oneLevel;
        }

        private int Depth(object[] list)
        {
            object[] noNullsList = list.Where(item => item != null).ToArray();
            int depth = 1;
            int maxDepth = 1;
            foreach(object child in noNullsList)
            {
                Type valueType = child.GetType();
                if (valueType.IsArray)
                    depth += Depth(child as object[]);

                if (depth > maxDepth)
                    maxDepth = depth;
            }

            return depth;
        }

        
    }
}
