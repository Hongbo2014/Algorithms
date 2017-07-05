using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class TrappingRain
    {
        public int GetWater(int[] nums)
        {
            if (nums == null || nums.Length < 2) { return 0; }

            Stack<int> stack = new Stack<int>();
            int count = 0;
            int i = 0;
            while (i < nums.Length)
            {
                if (stack.Count == 0 || nums[stack.Peek()] >= nums[i])
                {
                    stack.Push(i++);
                }
                else
                {
                    int index = stack.Pop();
                    int val = (stack.Count == 0) ? 0 : ((Math.Min(nums[stack.Peek()], nums[i]) - nums[index]) * (i - stack.Peek() - 1));
                    count += val;
                }
            }

            return count;
        }
    }
}
