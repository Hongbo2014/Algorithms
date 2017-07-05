using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class IncreasingNum
    {
        public bool IncreasingTriplet(int[] nums)
        {
            if (nums == null || nums.Length < 3)
            {
                return false;
            }

            var stack = new Stack<Pair>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (stack.Count == 0 || stack.Peek().low > nums[i])
                {
                    stack.Push(new Pair(nums[i], nums[i]));
                }
                else
                {
                    if (stack.Peek().high == nums[i] || stack.Peek().low == nums[i]) continue;
                    var last = stack.Pop();

                    if (last.high != last.low && last.high < nums[i])
                        return true;
                    
                    last.high = nums[i];
                    while (stack.Count > 0 && stack.Peek().high >= last.high)
                        stack.Pop();
                    if (stack.Count > 0 && stack.Peek().high < last.high && stack.Peek().high != stack.Peek().low)
                        return true;
                    stack.Push(last);
                }
            }

            return false;
        }

        private class Pair
        {
            public int high;
            public int low;
            public Pair(int h, int l)
            {
                high = h;
                low = l;
            }
        }
    }
}
