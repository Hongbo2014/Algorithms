using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class TotalHammingNum
    {
        public int TotalHammingDistance(int[] nums)
        {
            if (nums == null || nums.Length < 2) return 0;

            int len = nums.Length;
            int max = 0;
            for (int i = 0; i < len; i++)
            {
                max = Math.Max(max, nums[i]);
            }

            int count = 0;
            for (int i = 0; (max >> i) > 0; i++)
            {
                int countOne = 0;
                for (int j = 0; j < len; j++)
                {
                    countOne += (nums[j] >> i) & 1;
                }
                count += countOne * (len - countOne);
            }

            return count;
        }
    }
}
