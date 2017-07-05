using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class RegularExpression
    {
        //https://leetcode.com/problems/regular-expression-matching/#/solutions
        // Another solution without dp: https://discuss.leetcode.com/topic/12289/clean-java-solution
        public bool IsMath(string s, string p)
        {
            if (s == p)
            {
                return true;
            }

            if (s == null || p == null)
            {
                return false;
            }

            bool[,] dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] == '*' && (i > 0 && dp[0, i - 1]))
                {
                    dp[0, i + 1] = true;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    if (p[j] == s[i] || p[j] == '.')
                    {
                        dp[i + 1, j + 1] = dp[i, j];
                    }
                    else if (p[j] == '*')
                    {
                        if (p[j - 1] != s[i] && p[j - 1] != '.')
                        {
                            dp[i + 1, j + 1] = dp[i + 1, j - 1];
                        }
                        else
                        {
                            dp[i + 1, j + 1] = dp[i, j + 1] || dp[i + 1, j - 1] || dp[i, j + 1];
                        }
                    }
                }
            }

            return dp[s.Length, p.Length];
        }

        public bool IsWildcardMatch(string s, string p)
        {
            if (s == p)
            {
                return true;
            }

            if (s == null || p == null)
            {
                return false;
            }

            bool[,] dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;
            for (int i = 0; i < p.Length; i++)
            {
                if ((p[i] == '*' || p[i] == '?') && dp[0, i])
                {
                    dp[0, i + 1] = true;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    if (p[j] == '*')
                    {
                        dp[i + 1, j + 1] = dp[i, j] || dp[i + 1, j] || dp[i, j + 1];
                    }
                    else if (p[j] == s[i] || p[j] == '?')
                    {
                        dp[i + 1, j + 1] = dp[i, j];
                    }
                }
            }

            return dp[s.Length, p.Length];
        }
    }
}
