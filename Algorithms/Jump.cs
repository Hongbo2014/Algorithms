using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Jump
    {
        public int JumpSetp(int[] nums)
        {
            if (nums == null || nums.Length <= 1) return 0;

            int max = nums[0];
            int cur = nums[0];
            int res = 0;
            int i = 0;
            while (i < nums.Length)
            {
                res++;
                cur = max;
                i = cur;
                for (int j = i; j <= cur; j++)
                {
                    if (j >= nums.Length) return res;
                    if (j + nums[j] > max) max = j + nums[j];
                }
                 
            }

            return 0;
        }
    }
}
