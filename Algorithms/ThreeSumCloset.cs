using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ThreeSumCloset
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums == null || nums.Length < 3) return -1;
            Array.Sort(nums);
            int min = int.MaxValue;
            int closed = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                int remain = target - nums[i];
                while(left < right)
                {
                    if (nums[left] + nums[right] == remain) return target;
                    int val = remain - nums[left] - nums[right];
                    if (Math.Abs(val) < min)
                    {
                        min = Math.Abs(val);
                        closed = nums[i] + nums[left] + nums[right];
                    }
                    if (val > 0) left++;
                    if (val < 0) right--;
                }
            }

            return closed;
        }
    }
}
