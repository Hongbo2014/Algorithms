using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BinarySearch
    {
        public bool Search(int[] nums, int val)
        {
            if (nums == null || nums.Length == 0) return false;

            int left = 0;
            int right = nums.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > val)
                {
                    right = mid;
                }
                else if (nums[mid] < val)
                {
                    left = mid + 1;
                }
                else
                {
                    return true;
                }
            }
            return left < nums.Length && nums[left] == val;
        }
    }
}
