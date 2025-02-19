using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPatterns
{
    public class TopKElements
    {
        private ITopKElementsStrategy _topKElementsStrategy;

        public TopKElements(ITopKElementsStrategy topKElementsStrategy)
        {
            _topKElementsStrategy = topKElementsStrategy;
        }

        public int[] GetTopKElements(int[] nums, int k)
        {
            return _topKElementsStrategy.TopKFrequent(nums, k);
        }
    }

    public interface ITopKElementsStrategy
    {
        public int[] TopKFrequent(int[] nums, int k);
    }

    public class HashMapTopKElementsStrategy : ITopKElementsStrategy
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> ElementDectionary = new();
            for (int i = 0; i < nums.Length; i++)
            {
                if(ElementDectionary.ContainsKey(nums[i]))
                {
                    ElementDectionary[nums[i]] = ElementDectionary[nums[i]] + 1;
                }
                else
                {
                    ElementDectionary.Add(nums[i], 1);
                }
            }

            var sortedDictionary = ElementDectionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            var result = new int[k];
            var index = 0;
            foreach(var pair in sortedDictionary)
            {
                result[index++] = pair.Key;
                if(index >= k)
                {
                    break;
                }
            }
            return result;
        }
    }
}
