using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class IncreaseSubsequence
    {
        public IList<IList<int>> GetIncreaseSubsequence(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums == null || nums.Length < 2)
            {
                return result;
            }

            Helper(result, new List<int>(), nums, 0);

            return result;
        }

        private void Helper(IList<IList<int>> result, IList<int> list, int[] nums, int index)
        {
            if (list.Count > 1)
            {
                result.Add(new List<int>(list));
            }
            HashSet<int> hash = new HashSet<int>();
            for (int i = index; i < nums.Length; i++)
            {
                if (hash.Contains(nums[i])) continue;
                if (list.Count == 0 || list[list.Count - 1] <= nums[i])
                {
                    hash.Add(nums[i]);
                    list.Add(nums[i]);
                    Helper(result, list, nums, i + 1);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }

        public int LongestIncreasingSubsequence(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int len = nums.Length;
            int[] arr = new int[len];
            for (int i = 0; i < len; i++)
            {
                arr[i] = 1;
            }

            for (int i = 1; i < len; i++)
            {
                int max = arr[i];
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        max = Math.Max(arr[j] + 1, max);
                    }
                }
                arr[i] = max;
            }

            int val = 0;
            for (int i = 0; i < len; i++)
            {
                val = Math.Max(val, arr[i]);
            }
            return val;
        }

        public int LengthOfLIS(int[] nums)
        {
            int[] tails = new int[nums.Length];
            int size = 0;
            foreach (int x in nums)
            {
                int i = 0, j = size;
                while (i != j)
                {
                    int m = (i + j) / 2;
                    if (tails[m] < x)
                        i = m + 1;
                    else
                        j = m;
                }
                tails[i] = x;
                if (i == size) ++size;
            }
            return size;
        }
    }
}
