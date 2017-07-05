using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class UniqueString
    {
        public int FindSubstringInWraproundString(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                return 0;
            }

            int[] arr = new int[26];
            int maxLen = 1;
            for (int i = 0; i < p.Length; i++)
            {
                if (i > 0 && (p[i] - p[i - 1] == 1 || p[i] == p[i - 1] - 25))
                {
                    maxLen++;
                }
                else
                {
                    maxLen = 1;
                }

                arr[p[i] - 'a'] = Math.Max(arr[p[i] - 'a'], maxLen);
            }

            int result = 0;
            for (int i = 0; i < 26; i++)
            {
                result += arr[i];
            }

            return result;
        }
    }
}
