using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Permutation
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (nums == null || nums.Length == 0) return res;

            Array.Sort(nums);
            bool[] visited = new bool[nums.Length];
            PermutateUnique(res, new List<int>(), nums, visited);

            return res;
        }

        private void PermutateUnique(IList<IList<int>> res, List<int> list, int[] nums, bool[] visited)
        {
            if (list.Count == nums.Length)
            {
                res.Add(new List<int>(list));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (visited[i]) continue;
                if (i > 0 && nums[i] == nums[i - 1] && visited[i - 1]) continue;
                list.Add(nums[i]);
                visited[i] = true;
                PermutateUnique(res, list, nums, visited);
                visited[i] = false;
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
