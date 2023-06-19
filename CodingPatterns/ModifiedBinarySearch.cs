namespace CodingPatterns
{
    public class ModifiedBinarySearch
    {
        public int FindMinElement(int[] arr)
        {
            var left = 0;
            var right = arr.Length - 1;

            while(left < right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] > arr[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return arr[left];
        }
    }
}
