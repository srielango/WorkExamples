namespace CodingPatterns
{
    //Given an array of intervals, merge all the overlapping intervals into one and output the result which should have only mutually exclusive intervals
    //Example:
    //Input: arr[] = [[1, 3], [2, 4], [6, 8], [9, 10]]
    //Output: [[1, 4], [6, 8], [9, 10]]

    public class MergeIntervals
    {
        private IMergeStrategy _mergeStrategy;

        public MergeIntervals(IMergeStrategy mergeStrategy)
        {
            _mergeStrategy = mergeStrategy;
        }

        public List<int[]> MergeOverlap(int[][] intervals)
        {
            return _mergeStrategy.Merge(intervals);
        }
    }

    public interface IMergeStrategy
    {
        List<int[]> Merge(int[][] intervals);
    }

    public class SimpleStrategy : IMergeStrategy
    {
        public List<int[]> Merge(int[][] intervals)
        {
            var result = new List<int[]>();

            Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));

            for(int i = 0; i < intervals.Length; i++)
            {
                int start = intervals[i][0];
                int end = intervals[i][1];

                if(result.Count > 0 && result[result.Count - 1][1] >= end)
                {
                    continue;
                }

                for(int j = i + 1; j < intervals.Length; j++)
                {
                    //if (intervals[j][0] <= end)
                    //{
                    //    end = Math.Max(end, intervals[j][1]);
                    //}
                    if (end > intervals[j][0])
                    {
                        end = Math.Max(end, intervals[j][1]);
                    }
                }

                result.Add(new int[] {start, end});
            }

            return result;
        }
    }
}
