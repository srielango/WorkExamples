using System.Collections;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[lastNonZeroIndex++] = nums[i];
                }
            }

            for (var i = lastNonZeroIndex; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
            return nums;
        }

        public bool IsAnagram(string s, string t)
        {
            return string.Concat(s.OrderBy(c => c)) == string.Concat(t.OrderBy(c => c));

            //var sArray = s.ToCharArray();
            //Array.Sort(sArray);
            //var tArray = t.ToCharArray();
            //Array.Sort(tArray);
            //return string.Join("", sArray) == string.Join("", tArray);
        }

        public bool ContainsDuplicate(int[] nums)
        {
            return new HashSet<int>(nums).Count != nums.Length;
            //var myHash = new HashSet<int>();
            //foreach(var num in nums)
            //{
            //    if(!myHash.Add(num))
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        public int FirstUniqChar(string s)
        {
            var myDictionary = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (!myDictionary.ContainsKey(c))
                {
                    myDictionary.Add(c, 1);
                }
                else
                {
                    myDictionary[c] = myDictionary[c] + 1;
                }
            }

            for (var i = 0; i < s.Length; i++)
            {
                if (myDictionary[s[i]] == 1)
                {
                    return i;
                }
            }

            return -1;
        }

        public int MissingNumber(int[] nums)
        {
            return nums.Length * (nums.Length + 1) / 2 - nums.Sum();

            //for(var i=0;i<nums.Length;i++)
            //{
            //    if(nums.Any(x => x == i))
            //    {
            //        continue;
            //    }
            //    return i;
            //}
            //return nums.Length;
        }

        public int[] IntersectionOfTwoArrays(int[] nums1, int[] nums2)
        {
            var result = new List<int>();
            var num2List = nums2.ToList();
            foreach (var num in nums1)
            {
                if (num2List.Contains(num))
                {
                    result.Add(num);
                    num2List.Remove(num);
                }
            }

            return result.ToArray();
        }

        public int MaxProfit2(int[] prices)
        {
            //O(n^2).  Times out for huge collections
            //for(int i = 0; i < prices.Length - 1; i++)
            //{
            //    for(int j = i + 1; j < prices.Length; j++)
            //    {
            //        if(maxProfit < prices[j] - prices[i])
            //        {
            //            maxProfit = prices[j] - prices[i];
            //        }
            //    }
            //}


            //var maxProfit = 0;

            //var min = prices[0];
            //var max = prices[0];

            //for(var i = 1; i < prices.Length; i++)
            //{
            //    var profit = prices[i] - min;
            //    if (profit > maxProfit)
            //    {
            //        maxProfit = profit;
            //    }

            //    if (min > prices[i])
            //    {
            //        min = prices[i];
            //        max = prices[i];
            //    }
            //    else if(max < prices[i])
            //    {
            //        max = prices[i];
            //    }
            //}
            //return maxProfit;

            if (prices.Length == 0) return 0;

            int min = int.MaxValue;
            int max = int.MinValue;

            for (int i = 0; i < prices.Length; i++)
            {
                min = Math.Min(min, prices[i]);
                max = Math.Max(max, prices[i] - min);
            }

            return max;
        }

        ////public int CountSpecialNumbers(int n)
        ////{
        ////    var count = 0;
        ////    for(int i=1;i <= n;i++)
        ////    {
        ////        var num = i;
        ////        bool[] visited = new bool[10];
        ////        while (num != 0)
        ////        {
        ////            if (visited[num % 10])
        ////                break;

        ////            visited[num % 10] = true;
        ////            num = num / 10;
        ////        }

        ////        if(num == 0)
        ////        {
        ////            count++;
        ////        }
        ////        //var str = i.ToString();
        ////        //var hashSet = new HashSet<char>();
        ////        //var isSpecial = true;
        ////        //foreach (var ch in str)
        ////        //{
        ////        //    if(hashSet.Contains(ch))
        ////        //    {
        ////        //        isSpecial = false;
        ////        //        break;
        ////        //    }
        ////        //    hashSet.Add(ch);
        ////        //}
        ////        //if(isSpecial)
        ////        //    count++;
        ////    }

        ////    return count;
        ////}

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            var newHead = new ListNode(0);
            var runnerHead = newHead;

            while (l1 != null && l2 != null)
            {
                if (l1.val >= l2.val)
                {
                    runnerHead.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    runnerHead.next = l1;
                    l1 = l1.next;
                }

                runnerHead = runnerHead.next;
            }

            if (l1 != null) runnerHead.next = l1;
            if (l2 != null) runnerHead.next = l2;

            return newHead.next;
        }

        public bool IsHappy(int n)
        {
            var num = n;
            var sum = 0;

            var myHash = new HashSet<int>();

            while (!myHash.Contains(num))
            {
                myHash.Add(num);
                while (num / 10 != 0)
                {
                    sum += (num % 10) * (num % 10);
                    num /= 10;
                }
                sum += num * num;
                if (sum == 1) return true;
                num = sum;
                sum = 0;
            }

            return false;
        }

        public IList<IList<int>> GeneratePascalTriangle(int numRows)
        {
            IList<IList<int>> list = new List<IList<int>>();

            var count = 0;
            if (numRows > 0)
            {
                list.Add(new List<int>() { 1 });
                count++;
            }

            while (count < numRows)
            {
                var tempList = new List<int>();
                var prevList = list[count - 1];
                if (prevList.Count == 1)
                {
                    tempList.Add(1);
                    tempList.Add(1);
                }
                else
                {
                    tempList.Add(1);
                    for (var i = 0; i < prevList.Count - 1; i++)
                    {
                        tempList.Add(prevList[i] + prevList[i + 1]);
                    }
                    tempList.Add(1);
                }
                list.Add(tempList);
                count++;
            }
            return list;
        }

        public int ClimbStairs(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            var firstNum = 0;
            var secondNum = 1;
            var fib = 0;

            for (var i = 1; i <= n; i++)
            {
                fib = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = fib;
            }

            return fib;
        }

        public bool IsPowerOfThree(int n)
        {
            //Times out for large numbers. Ex: 1162261468
            //if (n == 1) return true;
            //var result = 0;
            //var i = 1;
            //while (result < n)
            //{
            //    result = (int)Math.Pow(3, i++);
            //    if (result == n) return true;
            //}

            //Works well
            //if (n == 1) return true;
            //if (n == 0 || n % 3 > 0) return false;

            //var x = n;
            //while (x % 3 == 0)
            //{
            //    x /= 3;
            //}

            //return x == 1;

            //One liner
            return n > 0 && 1162261467 % n == 0;
        }

        public int HammingWeight(uint n)
        {
            return Convert.ToString(n, 2).Replace("0", "").Length;
            //var count = 0;
            //for (int i = 0; i < 32; i++)
            //{
            //    if ((n >> i & 1) == 1)
            //    {
            //        count++;
            //    }
            //}
            //return count;
        }

        public int[] PlusOne(int[] digits)
        {
            //works for small numbers within the range of integer
            ////var units = 10;
            ////var num = digits[digits.Length - 1];
            ////for(var i = digits.Length - 2; i >=0; i--)
            ////{
            ////    num += (digits[i] * units);
            ////    units *= 10;
            ////}
            ////num += 1;
            ////var result = new List<int>();
            ////var temp = num;
            ////while(temp > 0)
            ////{
            ////    result.Add(temp % 10);
            ////    temp = Convert.ToInt16(Math.Floor(Convert.ToDouble(temp / 10)));
            ////}

            ////result.Reverse();
            ////return result.ToArray();
            ///

            digits[digits.Length - 1] = digits[digits.Length - 1] + 1;
            if (digits[digits.Length - 1] < 10)
            {
                return digits;
            }
            var result = new List<int>();
            var carryForward = false;
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                if (carryForward)
                {
                    digits[i]++;
                }

                if (digits[i] == 10)
                {
                    result.Add(0);
                    carryForward = true;
                }
                else
                {
                    result.Add(digits[i]);
                    carryForward = false;
                }
            }

            if (carryForward)
            {
                result.Add(1);
            }
            result.Reverse();
            return result.ToArray();

            //Interesting solution
            ////int n = digits.length;
            ////for (int i = n - 1; i >= 0; i--)
            ////{
            ////    if (digits[i] < 9)
            ////    {
            ////        digits[i]++;
            ////        return digits;
            ////    }

            ////    digits[i] = 0;
            ////}

            ////int[] newNumber = new int[n + 1];
            ////newNumber[0] = 1;

            ////return newNumber;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            //Brute force approach
            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < nums.Length; j++)
            //    {
            //        if (nums[i] + nums[j] == target)
            //        {
            //            return new int[] { i, j };
            //        }
            //    }
            //}
            //return new int[0];

            //O(n) using Hashtable
            var hashMap = new Hashtable();
            for (var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (hashMap.Contains(target - num))
                {
                    return new int[] { Convert.ToInt16(hashMap[target - num]), i };
                }
                if (!hashMap.Contains(num))
                {
                    hashMap.Add(num, i);
                }
            }
            return new int[0];

            //Simple solution using Dictionary
            var seen = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (seen.TryGetValue(target - nums[i], out var index))
                {
                    return new[] { index, i };
                }

                seen.TryAdd(nums[i], i);
            }

            return new int[0];
        }
        public int RemoveDuplicates(int[] nums)
        {
            //nums = nums.Distinct<int>().OrderBy(x => x).ToArray();

            var i = 0;
            var count = nums.Length;
            while (i < count - 1)
            {
                if (nums[i] == nums[i + 1])
                {
                    for (var j = i; j < count - 1; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                    nums[nums.Length - 1] = 200;
                    count--;
                }
                else
                {
                    i++;
                }
            }
            return count;

            //O(N) solution
            //var i = 0;
            //foreach (int num in nums)
            //    if (nums[i] != num)
            //        nums[++i] = num;
            //return nums.Length != 0 ? i + 1 : 0;
        }

        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            foreach (var myChar in s)
            {
                switch (myChar)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(myChar);
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(')
                            return false;
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                            return false;
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                            return false;
                        break;
                }
            }
            if (stack.Count == 0) return true;
            return false;
        }

        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;

            var slow = head;
            var fast = head.next;

            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next.next;
            }

            return true;

            //HashSet<int> hashtable = new HashSet<int>();
            //while(head.next != null)
            //{
            //    if(hashtable.Contains(head.val))
            //    {
            //        return true;
            //    }
            //    hashtable.Add(head.val);
            //    head = head.next;
            //}
            //return false;
        }

        public bool IsPalindrome(ListNode head)
        {
            var myList = new List<int>();
            while (head != null)
            {
                myList.Add(head.val);
                head = head.next;
            }

            if (myList.Count == 1) return true;
            if (myList.Count < 2) return false;

            var fromPtr = 0;
            var ToPtr = myList.Count - 1;
            while (fromPtr < ToPtr)
            {
                if (myList[fromPtr] != myList[ToPtr])
                    return false;
                fromPtr++;
                ToPtr--;
            }
            return true;
        }

        public int[] Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;

            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[k] = nums1[i];
                    i--;
                }
                else
                {
                    nums1[k] = nums2[j];
                    j--;
                }
                k--;
            }

            while (j >= 0)
            {
                nums1[k] = nums2[j];
                k--;
                j--;
            }

            //var i = 0;
            //var j = 0;

            //while(i < m)
            //{
            //    while(j < n)
            //    {
            //        if (nums1[i] < nums2[j])
            //        {
            //            i++;
            //            if(i >= m)
            //            {
            //                var x = i + 1;
            //                while(x < nums1.Length)
            //                {
            //                    nums1[x++] = nums2[j++];
            //                }
            //            }
            //        }
            //        else
            //        {
            //            for(var k=m; k > i; k--)
            //            {
            //                nums1[k] = nums1[k - 1];
            //            }
            //            nums1[i] = nums2[j];
            //            j++;
            //        }
            //    }
            //}

            return nums1;
        }

        public string LongestCommonPrefix(string[] strs)
        {
            var index = 0;
            var len = strs[0].Length;
            StringBuilder sb = new StringBuilder();
            while (index < len)
            {
                var ch = strs[0][index];
                var isSame = true;
                for(var i = 1; i < strs.Length; i++)
                {
                    if (strs[i].Length <= index)
                    {
                        isSame = false;
                        break;
                    }
                    if (strs[i][index] != ch)
                    {
                        isSame = false;
                        break;
                    }
                }
                if (isSame)
                {
                    sb.Append(ch);
                }
                else
                {
                    break;
                }
                index++;
            }
            return sb.ToString();
        }

        public bool IsPalindrome(string s)
        {
            var sb = new StringBuilder();
            foreach(var ch in s.ToLower())
            {
                var x = (int)ch;
                if(x >=48 && x <= 57 || x >= 97 && x <= 122)
                {
                    sb.Append(ch);
                }
            }

            var str = sb.ToString().ToLower();
            for(int i = 0; i < str.Length / 2;i++)
            {
                if (str[i] != str[str.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        public int Search(int[] nums, int target)
        {

            return SearchArray(nums, 0, nums.Length - 1, target);
            //Linear search - O(N)
            //for(var i=0;i<nums.Length;i++)
            //{
            //    if (nums[i] == target)
            //    {
            //        return i;
            //    }
            //}
            //return -1;
        }

        private int SearchArray(int[] nums, int min, int max, int target)
        {

            while(min <= max)
            {
                var middle = (min + max) / 2;
                if(nums[middle] == target)
                    return middle;
                if (nums[middle] > target)
                {
                    max = middle - 1;
                }
                else
                {
                    min = middle + 1;
                }
            }
            return -1;

            //if (min > max)
            //{
            //    return -1;
            //}

            //var middle = (max + min) / 2;

            //if (nums[middle] == target)
            //{
            //    return middle;
            //}

            //if (nums[middle] > target)
            //{
            //    return SearchArray(nums, min + 1, middle, target);
            //}
            //else
            //{
            //    return SearchArray(nums, middle + 1, max, target);
            //}


            //if (min > max)
            //{
            //    return -1;
            //}
            //else if (nums[min] == target)
            //{
            //    return min;
            //}
            //else if (nums[max] == target)
            //{
            //    return max;
            //}

            //var middle = (max + min) / 2;
            //if (nums[middle] > target)
            //{
            //    return SearchArray(nums, min + 1, middle, target);
            //}
            //else
            //{
            //    return SearchArray(nums, middle, max - 1, target);
            //}
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0)
        {
            this.val = val;
            this.next = null;
        }
    }

}
