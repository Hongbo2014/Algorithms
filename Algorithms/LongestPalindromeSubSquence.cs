using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class LongestPalindromeSubSquence
    {
        public int GetLongestPalindromeSubSquence(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int[,] arr = new int[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                arr[i, i] = 1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (s[i] == s[j])
                    {
                        arr[i, j] = arr[i - 1, j + 1] + 2;
                    } 
                    else
                    {
                        arr[i, j] = Math.Max(arr[i - 1, j], arr[i, j + 1]);
                    }
                }
            }

            return arr[s.Length - 1, 0];
        }
    }
}
