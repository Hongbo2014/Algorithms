using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class MinSubstring
    {
        public string GetMinSubstring(string s, string t)
        {
            if (s == null || s.Length < t.Length)
            {
                return "";
            }

            int count = t.Length;
            Queue<Helper> queue = new Queue<Helper>();
            Dictionary<char, int> hash = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                if (hash.ContainsKey(t[i]))
                {
                    hash[t[i]] += 1;
                }
                else
                {
                    hash.Add(t[i], 1);
                }
            }

            int start = -1;
            int minLength = int.MaxValue;
            for (int i = 0; i < s.Length; i++)
            {
                if (hash.ContainsKey(s[i]))
                {
                    if (hash[s[i]] == 0) continue;

                    hash[s[i]] -= 1;
                    count--;
                    queue.Enqueue(new Helper(s[i], i));
                }

                while (count == 0)
                {
                    var first = queue.Dequeue();
                    hash[first.cur] += 1;
                    count++;
                    int length = i - first.index;
                    if (length < minLength)
                    {
                        minLength = length;
                        start = first.index;
                    }
                }
            }

            return s.Substring(start, minLength + 1);
        }

        public class Helper
        {
            public char cur;
            public int index;
            public Helper(char c, int i)
            {
                cur = c;
                index = i;
            }
        }
    }
}
