using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class CombinationSum
    {
        public IList<IList<int>> Get(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums == null || nums.Length == 0) return result;
            Array.Sort(nums);
            Helper(nums, target, 0, new List<int>(), result);
            return result;
        }

        private void Helper(int[] nums, int remain, int index, List<int> list, IList<IList<int>> result)
        {
            if (remain < 0 || index >= nums.Length) return;

            if (remain == 0)
            {
                result.Add(new List<int>(list));
                return;
            }

            for(int i = index; i < nums.Length; i++)
            {
                int val = remain - nums[i];
                if (val < 0) break;
                list.Add(nums[i]);
                Helper(nums, val, i, list, result);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
