using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class AllCombination
    {
        public List<List<int>> GetAllConbination(int[] nums, int target)
        {
            List<List<int>> result = new List<List<int>>();
            if (nums == null || nums.Length == 0)
            {
                return result;
            }

            Array.Sort(nums);
            GetConbine(result, new List<int>(), nums, 0, target);
            return result;
        }

        private void GetConbine(List<List<int>> result, List<int> list, int[] nums, int index, int remain)
        {
            if (remain == 0)
            {
                result.Add(new List<int>(list));
                return;
            }

            if (remain < 0)
            {
                return;
            }

            for (int i = index; i < nums.Length; i++)
            {
                if (i > index && nums[i] == nums[i - 1])
                {
                    continue;
                }
                list.Add(nums[i]);
                GetConbine(result, list, nums, i + 1, remain - nums[i]);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
