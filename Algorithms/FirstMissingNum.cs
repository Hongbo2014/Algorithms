using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FirstMissingNum
    {
        public int MisingPositive(int[] nums)
        {
            if (nums == null || nums.Length < 0) { return 1; }
            int i = 0;
            for (i = 1; i < nums.Length; i++)
            {
                if (nums[i] <= 0 || nums[i] > nums.Length) continue;
                while (nums[i] != i + 1 && nums[i] > 0 && nums[i] <= nums.Length)
                {
                    int val = nums[i];
                    if (nums[i] == nums[val - 1]) break;
                    Swap(nums, val - 1, i);
                }
            }

            for (i = 0; i < nums.Length; i++)
            {
                if (i + 1 != nums[i]) return i;
            }

            return nums.Length + 1;
        }

        private void Swap(int[] nums, int i, int j )
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }
}
