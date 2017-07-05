using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FindMax
    {
        public int FindMaxForm(String[] strs, int m, int n)
        {
            int[,] dp = new int[m + 1,n + 1];
            foreach (String s in strs)
            {
                int[] count = Count(s);
                for (int i = m; i >= count[0]; i--)
                    for (int j = n; j >= count[1]; j--)
                        dp[i,j] = Math.Max(1 + dp[i - count[0],j - count[1]], dp[i,j]);
            }
            return dp[m,n];
        }

        public int[] Count(String str)
        {
            int[] res = new int[2];
            for (int i = 0; i < str.Length; i++)
                res[str[i] - '0']++;
            return res;
        }
    }
}
