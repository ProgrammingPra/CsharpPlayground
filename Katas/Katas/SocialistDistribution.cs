namespace Katas
{
    public class SocialistDistribution
    {
        public static List<int> TakeFromTheRichestAndMiddleClass(List<int> curDistribution, int minMoney)
        {
            List<int> poors = GetPoor(curDistribution, minMoney);
            List<int> richesAndMiddleClass = GetRichAndMiddleClass(curDistribution, minMoney);

            //take from the riches
            List<int> poorerRiches = Redistribute(poors, richesAndMiddleClass, minMoney);

            //poors should all have minMoney after re-distribution
            //middle class and the riches got poorer
            return poors.Select(val => minMoney).Concat(poorerRiches).ToList();
        }

        public static List<int> TakeFromTheRichest(List<int> curDistribution, int minMoney)
        {
            List<int> poors = GetPoor(curDistribution, minMoney);
            List<int> riches = GetTheRichest(curDistribution, minMoney);

            //take from the riches
            List<int> poorerRiches = Redistribute(poors, riches, minMoney);

            //poors should all have minMoney after re-distribution
            //middle class remains untouched
            //the riches got poorer
            return poors.Select(val => minMoney).Concat(GetMiddleClass(curDistribution, minMoney)).Concat(poorerRiches).ToList();
        }

        private static List<int> Redistribute(List<int> poors, List<int> riches, int minMoney)
        {
            Queue<int> richesQueue = new Queue<int>(riches);

            poors.ForEach(poor =>
                {
                    while (poor < minMoney)
                    {
                        int richWithLessMoney = richesQueue.Dequeue();
                        if (richWithLessMoney > minMoney)
                        {
                            richWithLessMoney--;
                            poor++;
                        }

                        richesQueue.Enqueue(richWithLessMoney);
                    }
                });
            return richesQueue.OrderBy(val => val).ToList();
         }

        private static Action<List<int>, Queue<int>, int> FromTheRiches()
        {
            return (poors, riches, minMoney) => {
                poors.ForEach(poor =>
                {
                    while (poor < minMoney)
                    {
                        int richWithLessMoney = riches.Dequeue();
                        if (richWithLessMoney > minMoney)
                        {
                            richWithLessMoney--;
                            poor++;
                        }

                        riches.Enqueue(richWithLessMoney);
                    }
                });
            };
        }


        private static List<int> GetPoor(List<int> curDistribution, int minMoney)
        {
            return curDistribution.Where(num => num < minMoney).OrderBy(num => num).ToList();
        }

        private static List<int> GetRichAndMiddleClass(List<int> curDistribution, int minMoney)
        {
            return curDistribution.Where(num => num >= minMoney).OrderByDescending(num => num).ToList();
        }

        private static List<int> GetTheRichest(List<int> curDistribution, int minMoney)
        {
            return curDistribution.Where(val => val == curDistribution.Max()).ToList();
        }

        private static List<int> GetMiddleClass(List<int> curDistribution, int minMoney)
        {
            return curDistribution.Where(val => val >= minMoney && val < curDistribution.Max()).ToList();
        }
    }
}