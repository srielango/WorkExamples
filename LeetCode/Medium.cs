using System.Diagnostics.SymbolStore;
using System.Text;

namespace LeetCode
{
    public class Medium
    {
        //[7,1,5,3,6,4]
        public int MaxProfit(int[] prices)
        {
            var n = prices.Length;
            if (n < 2) return 0;
            for (var i = 0; i < n - 1; i++)
                prices[i] = prices[i + 1] - prices[i];
            return prices.Where(x => x > 0).Sum() - prices[n - 1];

            //var n = prices.Length;
            //if (n == 0) return 0;
            //var profit = 0;
            //for (int i = 1; i < n; i++)
            //{
            //    if (prices[i - 1] < prices[i])
            //    {
            //        profit += prices[i] - prices[i - 1];
            //    }
            //}

            //return profit;


            //var profit = 0;
            //var buyPrice = prices[0];
            //var sellPrice = 0;

            //for(var j = 1; j < prices.Length; j++)
            //{
            //    if (prices[j - 1] > prices[j])
            //    {
            //        if(sellPrice > buyPrice)
            //        {
            //            profit += (sellPrice - buyPrice);
            //        }

            //        buyPrice = prices[j];
            //        sellPrice = 0;
            //    }
            //    else
            //    {
            //        sellPrice = prices[j];
            //    }
            //}
            //if(sellPrice > buyPrice)
            //{
            //    profit += (sellPrice - buyPrice);
            //}
            //return profit;
        }

        public int MaxSubArray(int[] nums)
        {
            //var sum = nums[0];
            //for(var i=0; i < nums.Length; i++)
            //{
            //    var temp = nums[i];
            //    if(temp > sum) sum = temp;
            //    for(var j=i+1; j < nums.Length; j++)
            //    {
            //        temp += nums[j];
            //        if (temp > sum) sum = temp;
            //    }
            //}
            //return sum;

            int sum = 0;
            int maxSum = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (nums[i] > sum)
                {
                    sum = nums[i];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
            return maxSum;
        }

        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int prev1 = 0;
            int prev2 = 0;
            foreach (var num in nums)
            {
                int tmp = prev1;
                prev1 = Math.Max(prev2 + num, prev1);
                prev2 = tmp;
            }
            return prev1;
        }

        public string CountAndSay(int n)
        {
            var result = "1";
            for (var i = 1; i < n; i++)
            {
                var temp = result;
                var count = 1;
                if (temp.Length == 1)
                {
                    result = count.ToString() + temp.ToString();
                }
                else
                {
                    result = String.Empty;
                    for (var j = 0; j < temp.Length - 1; j++)
                    {
                        if (temp[j] == temp[j + 1])
                        {
                            count++;
                        }
                        else
                        {
                            result = result + count.ToString() + temp[j].ToString();
                            count = 1;
                        }
                    }
                    result = result + count.ToString() + temp[temp.Length - 1].ToString();
                }
            }
            return result;
        }

        public int TrailingZeroes(int n)
        {
            ////decimal factorial = 1;
            ////var i = 1;
            ////while (i <= n)
            ////{
            ////    factorial *= i;
            ////    i++;
            ////}
            ////var count = 0;
            ////var factorialString = factorial.ToString();
            ////for(var j = factorialString.Length-1; j > 0; j--)
            ////{
            ////    if (factorialString[j] != '0')
            ////    {
            ////        return count;
            ////    }
            ////    count++;
            ////}
            ////return count;

            return n == 0 ? 0 : n / 5 + TrailingZeroes(n / 5);
        }

        public int StrStr(string haystack, string needle)
        {
            for (var i = 0; i <= haystack.Length - needle.Length; i++)
            {
                int j = 0;
                for (j = 0; j < needle.Length; j++)
                {
                    if (haystack[i + j] == needle[j]) continue;
                    break;
                }
                if (j == needle.Length) return i;
            }

            return -1;

            //if (haystack == needle) return 0;

            //var j = 0;
            //var index = -1;

            //while (j <= (haystack.Length - needle.Length))
            //{
            //    var i = 0;
            //    var k = j;
            //    while (i < needle.Length)
            //    {
            //        if (haystack[k] == needle[i])
            //        {
            //            if(index == -1) index = k;
            //            i++;
            //            k++;
            //        }
            //        else
            //        {
            //            index = -1;
            //            break;
            //        }
            //    }
            //    if (index > -1)
            //    {
            //        return index;
            //    }
            //    j++;
            //}
            //return -1;

            //return haystack.IndexOf(needle, StringComparison.Ordinal);
        }

        public void Rotate(int[] nums, int k)
        {
            for (var steps = 0; steps < k; steps++)
            {
                var x = nums[nums.Length - 1];
                for (var i = nums.Length - 1; i > 0; i--)
                {
                    nums[i] = nums[i - 1];
                }
                nums[0] = x;
            }
        }

        public int CountPrimes(int n)
        {
            if (n <= 2)
            {
                return 0;
            }

            var nonPrimes = new bool[n];

            int count = 0;
            nonPrimes[2] = false;

            for (int number = 2; number < n; number++)
            {
                if (!nonPrimes[number])
                {
                    //for (int i = 1; i * number < n; i++)
                    for (int i = 2; i * number < n; i++)  // keep the prime number unchanged please! June 7, 2022
                    {
                        nonPrimes[i * number] = true;
                    }

                    count++;
                }
            }

            return count;

            //if (n < 3)
            //    return 0;

            //var count = 1;

            //for(var i=3;i<n;i+=2)
            //{
            //    if (i > 5 && i % 5 == 0)
            //        continue;

            //    if (IsPrime(i))
            //    {
            //        count++;
            //    }
            //}
            //return count;
        }

        private bool IsPrime(int n)
        {
            
            for(var i=2;i*i <= n;i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        public int Reverse(int x)
        {
            var isNegative = x < 0;
            var str = Math.Abs(x).ToString();
            var res = new StringBuilder();
            for(var i=str.Length - 1;i >=0; i--)
            {
                res.Append(str[i]);
            }
            var strRes = res.ToString();
            var result = Convert.ToInt64(strRes);
            if(result > int.MaxValue)
            {
                return 0;
            }
            if(isNegative) result *= -1;
            return (int)result;
        }
    }
}
