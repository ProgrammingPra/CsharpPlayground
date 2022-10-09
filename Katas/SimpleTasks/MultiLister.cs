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

    internal class MutliLister : ILister
    {

        public void ShowWhatYouCan()
        {
            //COPY
            List<UncomparableObject> objects = ListOf.RandomObjects();
            Utils.Show(objects, "Shallow Copy", ShallowCopy(objects));

            Utils.Show(objects, "Deep Copy", DeepCopy<UncomparableObject>(ListOf.Clonify(objects)));

            //SPLIT
            int[] chunks = new int[] { 2, 4 };
            Utils.Show(objects, "Split into chunks by indices {" + String.Join(",", chunks) + "}", Split(objects, new int[] { 2, 4 }));
            Utils.Show(objects, "Split into chunks of 2", SplitInChunks(objects, 2));

        }

        private List<T> ShallowCopy<T>(List<T> list)
        {
            //return new List<T>(list);
            return list.ToList();
        }

        private List<T> DeepCopy<T>(List<ICloneable> list)
        {

            return list.Select(item => (T)item.Clone()).ToList();

        }

        private List<T>[] Split<T>(List<T> list, int[] indices)
        {

            List<List<T>> result = new List<List<T>>();

            var orderedIndices = indices.ToList().Where(item => item < list.Count).OrderBy(i => i).ToList();

            //first chunk: start_idx = 0; count = first index in indices
            result.Add(list.GetRange(0, orderedIndices.First() + 1).ToList());

            //ranges
            orderedIndices.Select((item, idx) => (item, idx)).Skip(1).ToList().ForEach(tuple =>
            {
                int start_idx = indices[tuple.idx - 1] + 1;
                result.Add(list.GetRange(start_idx, tuple.item - start_idx + 1).ToList());
            });


            //last chunk: from last specified index to the end of the list
            int lastRequestedIdx = orderedIndices.Last();
            int lastIdxInList = list.Count - 1;
            if (lastRequestedIdx < lastIdxInList)
                result.Add(list.GetRange(lastRequestedIdx + 1, lastIdxInList - lastRequestedIdx).ToList());

            return result.ToArray();

        }

        private List<T>[] SplitInChunks<T>(List<T> list, int chunkSize)
        {
            return list.Chunk(chunkSize).Select(array => array.ToList()).ToArray();
        }
    }
}
