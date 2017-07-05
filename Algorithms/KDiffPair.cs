using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class KDiffPair
    {
        public int Find(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0) return 0;
            if (k < 0) return 0;

            Dictionary<int, int> map = new Dictionary<int, int>();
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], 1);
                }
                else
                {
                    map[nums[i]]++;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!map.ContainsKey(nums[i])) continue;
                if (k == 0 && map.ContainsKey(nums[i]))
                {
                    count += map[nums[i]] > 1 ? 1 : 0;
                }
                else if (map.ContainsKey(nums[i] - k) && map.ContainsKey(nums[i] + k))
                {
                    count += 2;
                }
                else if (map.ContainsKey(nums[i] - k) || map.ContainsKey(nums[i] + k))
                {
                    count += 1;
                }

                map.Remove(nums[i]);
            }

            return count;
        }
    }
}
