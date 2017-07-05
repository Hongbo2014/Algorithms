using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class MaxAverage
    {
        public double GetMaxAverage(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || nums.Length < k)
            {
                return 0;
            }

            double max = double.MinValue;
            long sum = 0;
            int start = 0;
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                count++;
                if (count >= k)
                {
                    max = Math.Max((double)sum / (double)count, max);
                }
                
                while (count >= k && nums[start] < max)
                {
                    sum -= nums[start];
                    start++;
                    count--;
                    if (count >= k)
                    {
                        double ave = (double)sum / (double)count;
                        max = Math.Max(max, ave);
                    }
                }
            }

            return max;
        }
    }
}
