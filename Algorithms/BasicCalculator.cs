using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class BasicCalculator
    {
        //https://leetcode.com/problems/basic-calculator/#/description
        ////////////////////////////////////////////////////////////////////////////////
        //Wrong answer
        ////////////////////////////////////////////////////////////////////////////////
        //public int Calculate(string s)
        //{
        //    if (string.IsNullOrEmpty(s)) return 0;

        //    Stack<int> stack = new Stack<int>();
        //    int num = 0;
        //    bool hasVal = false;
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        char c = s[i];

        //        if (Char.IsDigit(c))
        //        {
        //            num = num * 10 + c - '0';
        //            hasVal = true;
        //            continue;
        //        }

        //        if (hasVal)
        //        {
        //            stack.Push(num);
        //            num = 0;
        //            hasVal = false;
        //            if (stack.Count == 3) CalculateCurrent(stack);
        //        }
        //        if (c == '+') stack.Push(1);
        //        if (c == '-') stack.Push(-1);
        //        if (c == '(')
        //        {
        //            var index = FindMapping(s.Substring(i));
        //            if (index == -1) throw new Exception();
        //            stack.Push(Calculate(s.Substring(i + 1, index - 1)));
        //            if (stack.Count == 3) CalculateCurrent(stack);
        //            i = i + index;
        //        }
        //    }
        //    if (num != 0) stack.Push(num);
        //    if (stack.Count == 3) CalculateCurrent(stack);
        //    return stack.Count == 0 ? 0 : stack.Pop();
        //}

        //private int FindMapping(string s)
        //{
        //    if (string.IsNullOrEmpty(s)) return -1;

        //    Stack<int> stack = new Stack<int>();
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        char c = s[i];
        //        if (stack.Count == 1 && c == ')') return i;
        //        if (c == '(') stack.Push(0);
        //        else if (c == ')') stack.Pop();
        //    }

        //    return -1;
        //}

        //private void CalculateCurrent(Stack<int> stack)
        //{
        //    if (stack.Count < 3) return;
        //    int val2 = stack.Pop() * stack.Pop();
        //    stack.Push(stack.Pop() + val2);
        //}

        public int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s)) return -1;

            Stack<int> stack = new Stack<int>();
            int result = 0;
            int sign = 1; //positive.
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (char.IsDigit(c))
                {
                    int val = c - '0';
                    while (i + 1 < s.Length && char.IsDigit(s[i + 1]))
                    {
                        val = val * 10 + s[i + 1] - '0';
                        i++;
                    }
                    result = val * sign + result;
                }
                else
                if (c == '+') sign = 1;
                else
                if (c == '-') sign = -1;
                else
                if (c == '(')
                {
                    stack.Push(result);
                    stack.Push(sign);
                    result = 0;
                    sign = 1;
                }
                else
                if (c == ')')
                {
                    result = result * stack.Pop() + stack.Pop();
                    sign = 1;
                }
            }

            return result;
        }

        public int Calculator(string s)
        {
            if (string.IsNullOrEmpty(s)) return -1;

            Stack<int> stack = new Stack<int>();
            int nums = 0;
            char sign = '+';
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == ' ') continue;
                if (char.IsDigit(c))
                {
                    nums = nums * 10 + c - '0';
                }
                if (!char.IsDigit(c) || i == s.Length - 1)
                {
                    if (sign == '+') stack.Push(nums);
                    else if (sign == '-') stack.Push(-nums);
                    else if (sign == '*') stack.Push(stack.Pop() * nums);
                    else if (sign == '/') stack.Push(stack.Pop() / nums);
                    nums = 0;
                    sign = c;
                }
            }
            int result = 0;
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }
    }
}
