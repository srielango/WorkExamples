using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Easy
    {
        public string FizzBuzz(int number)
        {
            if (number == 0) return "0";
            var result = string.Empty;
            if (number % 3 == 0) result = "Fizz";
            if (number % 5 == 0) result += "Buzz";
            if (result == string.Empty) result = number.ToString();

            //var result = number.ToString();
            //if(number % 3 == 0 && number % 5 == 0)
            //{
            //    result = "FizzBuzz";
            //}
            //else if(number % 3 == 0)
            //{
            //    result = "Fizz";
            //}
            //else if(number % 5 == 0)
            //{
            //    result = "Buzz";
            //}

            return result;
        }

        public int SingleNumber(int[] nums)
        {
            Array.Sort(nums);
            var sortedNum = nums;
            var numGroup = sortedNum.GroupBy(x => x).Select(x => new { key = x.Key, val = x.Count() });
            if (numGroup.FirstOrDefault(x => x.val > 2) != null)
            {
                throw new ArgumentException("Numbers appear more than 2 times");
            }

            var singleNumGroup = numGroup.FirstOrDefault(x => x.val == 1);
            if (singleNumGroup == null)
            {
                throw new ArgumentException("No single number");
            }

            return singleNumGroup.key;
            //for (var i = 0; i < sortedNum.Length - 1; i += 2)
            //{
            //    if (sortedNum[i] != sortedNum[i + 1])
            //    {
            //        return sortedNum[i];
            //    }
            //}
            //return -1;
        }

        public int[] MoveZeroes(int[] nums)
        {
            ////var lastPointer = nums.Length - 1;
            ////for (int i = nums.Length - 1; i > 0; i--)
            ////{
            ////    if (nums[i] != 0)
            ////    {
            ////        lastPointer = i;
            ////        break;
            ////    }
            ////}

            ////var currentPointer = 0;
            ////while (currentPointer <= lastPointer)
            ////{
            ////    if (nums[currentPointer] == 0)
            ////    {
            ////        for (int j = currentPointer; j < lastPointer; j++)
            ////        {
            ////            nums[j] = nums[j + 1];
            ////        }
            ////        nums[lastPointer--] = 0;
            ////    }
            ////    else
            ////    {
            ////        currentPointer++;
            ////    }
            ////}

            var lastNonZeroIndex = 0;
            for(var i=0;i < nums.Length;i++)
            {
                if (nums[i] != 0)
                {
                    nums[lastNonZeroIndex++] = nums[i];
                }
            }

            for(var i=lastNonZeroIndex;i < nums.Length;i++)
            {
                nums[i] = 0;
            }
            return nums;
        }
    }
}
