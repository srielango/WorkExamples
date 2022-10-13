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
    }
}
