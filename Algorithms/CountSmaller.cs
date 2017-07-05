using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class CountSmaller
    {
        public IList<int> CountSmallerAfterSelf(int[] nums)
        {
            IList<int> result = new List<int>();
            if (nums == null || nums.Length == 0)
            {
                return result;
            }

            int[] arr = new int[nums.Length];
            int size = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int val = nums[i];
                int index = BinarySearch(arr, size, val);
                result.Add(index);
                arr[index] = val;
                if (index == size) size++;
            }
            result =new List<int>(result.Reverse());
            return result;
        }

        private int BinarySearch(int[] arr, int size, int target)
        {
            if (size == 0) return 0;
            int start = 0;

            while (start < size - 1)
            {
                int mid = start + (size - start) / 2;
                if (arr[mid] >= target)
                {
                    size = mid;
                }
                else
                {
                    start = mid;
                }
            }

            if (arr[start] >= target) return start;
            return size;
        }
    }
}
