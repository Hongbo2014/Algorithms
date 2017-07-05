using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class NextGreatValue
    {
        public int[] NextGreaterElement(int[] findNums, int[] nums)
        {
            if (findNums == null || findNums.Length == 0 || nums == null || nums.Length == 0)
            {
                return new int[0];
            }

            Dictionary<int, int> hash = new Dictionary<int, int>();
            Stack<int> stack = new Stack<int>();
            int[] result = new int[findNums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count > 0 && nums[i] > stack.Peek())
                {
                    hash.Add(stack.Peek(), nums[i]);
                }
                stack.Push(nums[i]);
            }

            for (int i = 0; i < findNums.Length; i++)
            {
                if (hash.ContainsKey(findNums[i]))
                {
                    result[i] = hash[findNums[i]];
                }
                else
                {
                    result[i] = -1;
                }
            }

            return result;
        }

        //https://leetcode.com/problems/next-greater-element-ii/#/description
        public int[] NextGreaterValueII(int[] nums)
        {
            if (nums == null || nums.Length == 0) return new int[0];

            Stack<int> stack = new Stack<int>();
            var result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = -1;
            }

            for (int i = 0; i < nums.Length * 2; i++)
            {
                while (stack.Count > 0 && nums[i % nums.Length] > nums[stack.Peek()])
                {
                    result[stack.Pop()] = nums[i];
                }
                if (i < nums.Length) stack.Push(i);
            }

            return result;
        }
    }
}
