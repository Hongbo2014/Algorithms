using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // https://leetcode.com/problems/longest-substring-with-at-least-k-repeating-characters/#/description
    public class LongestStringAtLeastK
    {
        public int GetLongest(string str, int k)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            return Helper(str, 0, str.Length, k);
        }

        private int Helper(string str, int start, int end, int k)
        {
            if (end - start < k) return 0;
            int[] arr = new int[26];
            for (int i = start; i < end; i++)
            {
                arr[str[i] - 'a']++;
            }

            for (int i = 0; i < 26; i++)
            {
                if (arr[i] == 0 || arr[i] >= k) continue;
                for (int j = start; j < end; j++)
                {
                    if (str[j] == i + 'a')
                    {
                        int left = Helper(str, start, j, k);
                        int right = Helper(str, j + 1, end, k);
                        return Math.Max(left, right);
                    }
                }
            }

            return end - start;
        }

        // Solution 2
        public int LongestSubstring(String s, int k)
        {
            int d = 0;

            for (int numUniqueTarget = 1; numUniqueTarget <= 26; numUniqueTarget++)
                d = Math.Max(d, LongestSubstringWithNUniqueChars(s, k, numUniqueTarget));

            return d;
        }

        private int LongestSubstringWithNUniqueChars(String s, int k, int numUniqueTarget)
        {
            int[] map = new int[128];
            int numUnique = 0; // counter 1
            int numNoLessThanK = 0; // counter 2
            int begin = 0, end = 0;
            int d = 0;

            while (end < s.Length)
            {
                if (map[s[end]]++ == 0) numUnique++; // increment map[c] after this statement
                if (map[s[end++]] == k) numNoLessThanK++; // inc end after this statement

                while (numUnique > numUniqueTarget)
                {
                    if (map[s[begin]]-- == k) numNoLessThanK--; // decrement map[c] after this statement
                    if (map[s[begin++]] == 0) numUnique--; // inc begin after this statement
                }

                // if we found a string where the number of unique chars equals our target
                // and all those chars are repeated at least K times then update max
                if (numUnique == numUniqueTarget && numUnique == numNoLessThanK)
                    d = Math.Max(end - begin, d);
            }

            return d;
        }

        private int HelperTwo(string s, int k, int count)
        {
            int[] map = new int[128];
            int start = 0;
            int end = 0;
            int unique = 0;
            int noLessThanK = 0;
            int max = 0;
            while(end < s.Length)
            {
                if (map[s[end]] == 0) unique++;
                map[s[end]]++;
                if (map[s[end]] == k) noLessThanK++;
                end++;
                while(noLessThanK >= count)
                {
                    map[s[start]]--;
                    if (map[s[start]] < k) noLessThanK--;
                    if (map[s[start]] == 0) unique--;
                    start++;
                }

                if (noLessThanK == unique && unique == count)
                {
                    max = Math.Max(max, end - start);
                }
            }

            return max;
        }
    }
}
