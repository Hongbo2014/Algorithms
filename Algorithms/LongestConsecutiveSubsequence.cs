using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class LongestConsecutiveSubsequence
    {
        public int Longest(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            HashSet<int> hash = new HashSet<int>(nums);

            int max = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[i] - 1;
                if (hash.Contains(val)) continue;
                int next = nums[i] + 1;
                while (hash.Contains(next)) next++;
                max = max > (next - nums[i]) ? max : next - nums[i];
            }

            return max;
        }

        public int LongestII(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            int max = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i])) continue;
                int left = map.ContainsKey(nums[i] - 1) ? map[nums[i] - 1] : 0;
                int right = map.ContainsKey(nums[i] + 1) ? map[nums[i] + 1] : 0;
                int sum = right + left + 1;
                map.Add(nums[i], sum);
                map[nums[i] - left] = sum;
                map[nums[i] + right] = sum;

                max = max < sum ? sum : max;
            }

            return max;
        }
    }
}
