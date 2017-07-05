using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class LongestValidParatheses
    {
        public int GetLongest(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int len = s.Length;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < len; i++)
            {
                if (s[i] == '(') stack.Push(i);
                else if (s[i] == ')' && stack.Count > 0 && s[stack.Peek()] == '(') stack.Pop();
                else
                {
                    stack.Push(i);
                }
            }

            if (stack.Count == 0) return len;

            int right = len;
            int max = 0;
            while (stack.Count > 0)
            {
                var left = stack.Peek();
                var cur = right - left - 1;
                max = max < cur ? cur : max;
                right = stack.Pop();
            }
            max = right > max ? right : max;

            return max;
        }

        public int GetLongestDP(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int[] len = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') continue;
                else if (s[i] == ')')
                {
                    if (i == 0) len[i] = 0;
                    else if (s[i - 1] == '(')
                    {
                        if (i == 1) len[i] = 2;
                        else len[i] = len[i - 2] + 2;
                    }
                    else if (s[i - 1] == ')')
                    {
                        if (i - len[i - 1] - 1 >= 0 && s[i - len[i - 1] - 1] == '(')
                        {
                            if (i - len[i - 1] - 1 > 0) len[i] = 2 + len[i - 1] + len[i - len[i - 1] - 2];
                            else len[i] = 2 + len[i - 1];
                        }
                    }
                }
            }

            int max = 0;
            for(int i = 0; i < s.Length; i++)
            {
                max = len[i] > max ? len[i] : max;
            }

            return max;
        }
    }
}
