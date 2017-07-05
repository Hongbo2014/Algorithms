using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class WiggleSort
    {
        //https://leetcode.com/problems/wiggle-sort-ii/#/description
        public void WiggleSortII(int[] nums)
        {
            if (nums == null || nums.Length < 2) return;
            int median = (new FindKthElement()).Find(nums, (nums.Length + 1) / 2);

            int odd = 1;
            int len = nums.Length;
            int even = len % 2 == 0 ? len - 2 : len - 1;

            int[] arr = new int[len];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > median)
                {
                    arr[odd] = nums[i];
                    odd += 2;
                }
                else if (nums[i] < median)
                {
                    arr[even] = nums[i];
                    even -= 2;
                }
            }

            while (odd < len)
            {
                arr[odd] = median;
                odd += 2;
            }

            while (even >= 0)
            {
                arr[even] = median;
                even -= 2;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                nums[i] = arr[i];
            }
        }
    }
}
