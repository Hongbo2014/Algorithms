using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FourSum
    {
        public IList<IList<int>> GetFourSum(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (nums == null || nums.Length < 4) return result;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i - 1] == nums[i]) continue;
                int remain = target - nums[i];
                Helper(nums, i + 1, remain, result, nums[i]);
            }

            return result;
        }

        private void Helper(int[] nums, int index, int remain, IList<IList<int>> result, int cur)
        {
            for (int i = index; i < nums.Length - 2; i++)
            {
                if (i > index && nums[i - 1] == nums[i]) continue;
                int left = i + 1;
                int right = nums.Length - 1;
                int res = remain - nums[i];
                while (left < right)
                {
                    if (left > i + 1 && nums[left] == nums[left - 1])
                    {
                        left++;
                        continue;
                    }
                    if (right < nums.Length - 1 && nums[right + 1] == nums[right])
                    {
                        right--;
                        continue;
                    }
                    int val = nums[left] + nums[right];
                    if (res == val)
                    {
                        IList<int> list = new List<int>()
                        {
                            cur, nums[i],nums[left],nums[right]
                        };
                        result.Add(list);
                        left++;
                        right--;
                    }
                    else if (res > val)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
        }
    }
}
