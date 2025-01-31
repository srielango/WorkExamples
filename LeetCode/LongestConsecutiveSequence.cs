namespace LeetCode
{
    //Given an array of unsorted integer, find the length of the longest
    //Consecutive elements sequence
    public class LongestConsecutiveSequence
    {
        public int LCS(int[] nums)
        {
            var longestSequence = 1;
            var length = 1;

            if(nums.Length == 0)
            {
                return 0;
            }

            Array.Sort(nums);

            for(int i = 1;i < nums.Length;i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    continue;
                }

                if (nums[i] == nums[i - 1] + 1)
                { 
                    length++;
                }
                else
                {
                    longestSequence = Math.Max(length, longestSequence);
                    length = 1;
                }
            }

            return Math.Max(length, longestSequence);
        }
    }
}
