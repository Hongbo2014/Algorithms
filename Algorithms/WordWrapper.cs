using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class WordWrapper
    {
        int[] arr;
        int count = 0;
        public int FindSubstringInWraproundString(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                return 0;
            }

            int start = 0;
            arr = new int[p.Length];
            arr[0] = 1;
            for (int i = 1; i < p.Length; i++)
            {
                arr[i] = arr[i - 1] + i + 1;
            }

            var hash = new HashSet<String>();
            while (start < p.Length)
            {
                int next = GetSuccessiveIndex(p, start);
                var str = p.Substring(start, next);
                start = start + next;
                if (hash.Contains(str)) continue;
                else AddConbine(str, hash);
                count += arr[next - 1];
            }

            return count;
        }

        private int GetSuccessiveIndex(string p, int i)
        {
            int start = i;
            while (i < p.Length)
            {
                if (i == p.Length - 1) return p.Length - start;

                var c = p[i];
                i++;
                int val1 = c - 'a';
                int val2 = p[i] - 'a';
                if (val1 != val2 - 1 && val1 != val2 + 25) break;
            }

            return i - start;
        }

        private void AddConbine(string str, HashSet<string> hash)
        {
            for (int i = 1; i <= str.Length; i++)
            {
                for (int j = 0; j + i <= str.Length; j++)
                {
                    if (!hash.Contains(str.Substring(j, i)))
                    {
                        hash.Add(str.Substring(j, i));
                    }
                }
            }
        }
    }
}
