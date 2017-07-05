using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FindDupNum
    {
        public IList<int> FindDuplicates(int[] nums)
        {
            IList<int> result = new List<int>();
            if (nums == null || nums.Length == 0) { return result; }

            for (int i = 0; i < nums.Length; i++)
            {
                int val = Math.Abs(nums[i]);
                if (nums[i] == val - 1) continue;
                if (nums[val - 1] < 0)
                {
                    result.Add(val);
                }
                else
                {
                    nums[val - 1] = -nums[val - 1];
                }
            }

            return result;
        }

        public IList<int> FindDuplicatesSelf(int[] nums)
        {
            IList<int> result = new List<int>();
            if (nums == null || nums.Length == 0) { return result; }

            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] == i + 1)
                {
                    i++;
                    continue;
                }
                if (nums[i] == -1)
                {
                    i++;
                    continue;
                }
                if (nums[nums[i] - 1] == nums[i])
                {
                    result.Add(nums[i]);
                    nums[i] = -1;
                    i++;
                    continue;
                }
                Swap(nums, i, nums[i] - 1);
                
             }

            return result;
        }

        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }
}
