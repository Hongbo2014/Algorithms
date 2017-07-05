using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ComplexNumberMultiplication
    {
        public string ComplexNumberMultiply(string a, string b)
        {
            if (a == null || b == null || string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b)) return "";
            string[] arr1 = a.Split('+');
            string[] arr2 = b.Split('+');
            int v1 = ConvertToNumber(arr1[0]);
            int v2 = ConvertToNumber(arr1[1]);

            int v3 = ConvertToNumber(arr2[0]);
            int v4 = ConvertToNumber(arr2[1]);
            StringBuilder bld = new StringBuilder();
            bld.Append(v1 * v3 - v2 * v4);
            bld.Append('+');
            bld.Append(v1 * v4 + v2 * v3);
            bld.Append('i');
            return bld.ToString();
        }

        private int ConvertToNumber(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            bool isNeg = false;
            if (s[0] == '-')
            {
                isNeg = true;
                s = s.Substring(1);
            }

            int val = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'i') break;
                val = val * 10 + s[i] - '0';
            }

            return isNeg ? -1 * val : val;
        }


        public string FrequencySort(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";

            int[] hash = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                hash[i - 'a']++;
            }

            var list = new List<Helper>();
            for (int i = 0; i < 26; i++)
            {
                if (hash[i] != 0)
                {
                    list.Add(new Helper( (char)(i + 'a'), hash[i]));
                }
            }

            list.Sort((a, b) =>
            {
                if (a.i < b.i) return 1;
                else if (a.i > b.i) return -1;
                return 0;
            });

            StringBuilder bld = new StringBuilder();
            foreach (var item in list)
            {
                for (int i = 0; i < item.i; i++)
                {
                    bld.Append(item.c);
                }
            }

            return bld.ToString();
        }

        private class Helper
        {
            public char c;
            public int i;
            public Helper(char f, int v)
            {
                c = f;
                i = v;
            }
        }
    }

}
